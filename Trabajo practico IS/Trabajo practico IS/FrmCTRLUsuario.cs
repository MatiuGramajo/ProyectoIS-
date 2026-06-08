using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_practico_IS
{
    public partial class FrmCTRLUsuario : Form,BE.IObserver
    {

        BLL.USUARIO GestorUsuarios = new BLL.USUARIO();
        BLL.BITACORA GestorBitacora = new BLL.BITACORA();
        BLL.PERMISO GestorPermisos = new BLL.PERMISO();
        BE.USUARIO usuario;

        public FrmCTRLUsuario()
        {
            InitializeComponent();
        }

        private void FrmCTRLUsuario_Load(object sender, EventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Suscribir(this);
            ActualizarIdioma();
            EnlazarUsuarios();
            CargarComboBoxRoles();
        }

        public void EnlazarUsuarios()
        {
            List<BE.USUARIO> ListaCompleta = GestorUsuarios.Listar();
            List<BE.USUARIO> ListaDesbloqueados;
            if (CKXmostrarbloqueados.Checked==false)
            {
            ListaDesbloqueados=(from d in ListaCompleta
                                where d.EstadoBloqueado==false
                                select d).ToList();
            }
            else
            {
                ListaDesbloqueados = ListaCompleta;
            }

            DGV_CtrlUsuUsuarios.DataSource = null;
            DGV_CtrlUsuUsuarios.DataSource = ListaDesbloqueados;
            DGV_CtrlUsuUsuarios.ReadOnly = true;
            DGV_CtrlUsuUsuarios.Columns["Id"].Visible = false;
            DGV_CtrlUsuUsuarios.Columns["Contraseña"].Visible = false;
            DGV_CtrlUsuUsuarios.Columns["IntentosFallidos"].Visible = false;

        }

        private void BTNCtrlUsuAlta_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(TXT_CtrlUsuUsuario.Text) || string.IsNullOrEmpty(TXT_CtrlUsuContraseña.Text) || string.IsNullOrEmpty(TXT_CtrlUsuDNI.Text) || string.IsNullOrEmpty(TXT_CtrlUsuEmail.Text)))
            {
                BE.USUARIO usuario = new BE.USUARIO();

                usuario.Usuario = TXT_CtrlUsuUsuario.Text;
                usuario.Contraseña = ENCRIPTADOR.Hashear(TXT_CtrlUsuContraseña.Text);
                usuario.Dni = int.Parse(TXT_CtrlUsuDNI.Text);
                usuario.Email = TXT_CtrlUsuEmail.Text;

                GestorUsuarios.Insertar(usuario);
                GestorBitacora.RegistrarEvento("Administracion", $"Se dio de alta al usuario {usuario.Usuario}", 2);
                EnlazarUsuarios();
                LimpiarControles();
            }
            else
            {
                MessageBox.Show("Debe completar todos los datos");
            }

        }
        public void LimpiarControles()
        {
            TXT_CtrlUsuUsuario.Text = "";
            TXT_CtrlUsuContraseña.Text = "";
            TXT_CtrlUsuDNI.Text = "";
            TXT_CtrlUsuEmail.Text = "";
        }
        private void BTNCtrlUsuBaja_Click(object sender, EventArgs e)
        {
            if (usuario != null)
            {
                var result = MessageBox.Show($"Esta seguro que desea borrar a: {usuario.Usuario}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    GestorUsuarios.Borrar(usuario);
                    GestorBitacora.RegistrarEvento("Administracion", $"Se dio de baja al usuario {usuario.Usuario}", 4);
                    EnlazarUsuarios();
                    LimpiarControles();
                    usuario = null;
                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para borrar.");
            }

        }

        private void BTNCtrlUsuModificar_Click(object sender, EventArgs e)
        {
            if (usuario != null && !(string.IsNullOrEmpty(TXT_CtrlUsuUsuario.Text) || string.IsNullOrEmpty(TXT_CtrlUsuDNI.Text) || string.IsNullOrEmpty(TXT_CtrlUsuEmail.Text)))
            {
                usuario.Usuario = TXT_CtrlUsuUsuario.Text;
                if(!string.IsNullOrEmpty(TXT_CtrlUsuContraseña.Text))
                {
                    usuario.Contraseña = ENCRIPTADOR.Hashear(TXT_CtrlUsuContraseña.Text);

                }
                usuario.Dni = int.Parse(TXT_CtrlUsuDNI.Text);
                usuario.Email = TXT_CtrlUsuEmail.Text;
                GestorUsuarios.Modificar(usuario);
                EnlazarUsuarios();
                GestorBitacora.RegistrarEvento("Administracion", $"Se modificó al usuario: {usuario.Usuario}", 3);
                LimpiarControles();
            }
            else
            {
                MessageBox.Show("Seleccione un campo para modificar.");
            }
        }

        private void BTNCtrlUsuDesbloquear_Click(object sender, EventArgs e)
        {
            if (usuario != null)
            {
                if (usuario.EstadoBloqueado == true)
                {
                    usuario.EstadoBloqueado = false;
                    usuario.IntentosFallidos = 0;
                    GestorUsuarios.DesbloquearUsuario(usuario);
                    GestorBitacora.RegistrarEvento("Administracion", $"Se desbloqueó manualmente al usuario {usuario.Usuario}", 3);
                    MessageBox.Show($"El usuario {usuario.Usuario} ha sido desbloqueado con éxito.");
                    EnlazarUsuarios();
                }
                else
                {
                    MessageBox.Show("El usuario seleccionado no se encuentra bloqueado.");
                }
            }
            else
            {
                MessageBox.Show("Primero seleccione un usuario para desbloquearlo.");
            }
        }

        private void BTNCtrlUsuVolverMenu_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Desea volver al menu principal?", "Atención",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();

            }
        }

        private void DGV_CtrlUsuUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                usuario=DGV_CtrlUsuUsuarios.Rows[e.RowIndex].DataBoundItem as BE.USUARIO;
                TXT_CtrlUsuUsuario.Text = usuario.Usuario;
                TXT_CtrlUsuContraseña.Text = "";
                TXT_CtrlUsuDNI.Text = usuario.Dni.ToString();
                TXT_CtrlUsuEmail.Text = usuario.Email;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            EnlazarUsuarios();
            LimpiarControles();
            usuario = null;
        }

        private void CargarComboBoxRoles()
        {
            // 1. Traemos TODOS los permisos de la base de datos
            List<BE.COMPONENTE> todosLosPermisos = GestorPermisos.Listar();

            // 2. Filtramos con LINQ para quedarnos SOLAMENTE con los roles (compuestos)
            List<BE.COMPONENTE> soloRoles = todosLosPermisos.Where(p => p is BE.PERMISO_COMPUESTO).ToList();

            // 3. Enlazamos la lista al ComboBox
            Cb_CTRLUsuarioRol.DataSource = soloRoles;
            Cb_CTRLUsuarioRol.DisplayMember = "Nombre"; // Propiedad que lee el usuario
        }

        public void ActualizarIdioma()
        {
            var traducciones = Servicios.IDIOMAS.GetInstancia().Traducciones;
            TraducirControles(this.Controls, traducciones);
            if (traducciones.TryGetValue($"{this.Name}_Titulo", out string textoTitulo)) this.Text = textoTitulo;
        }
        public void TraducirControles(Control.ControlCollection controles, Dictionary<string, string> traducciones)
        {
            foreach (Control control in controles)
            {
                string clave = $"{this.Name}_{control.Name}";
                if (traducciones.TryGetValue(clave, out string textoTraducido)) control.Text = textoTraducido;
                if (control.HasChildren) TraducirControles(control.Controls, traducciones);
            }
        }

        private void FrmCTRLUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);
        }
    }
}
