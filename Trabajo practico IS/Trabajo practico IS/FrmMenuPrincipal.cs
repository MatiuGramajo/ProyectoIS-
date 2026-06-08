using BE;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_practico_IS
{
    public partial class FrmMenuPrincipal : Form, BE.IObserver
    {

        BE.USUARIO UsuarioActual = SESION.GetInstancia().usuactual;
        BLL.USUARIO GestorUsuario = new BLL.USUARIO();
        BLL.BITACORA GestorBitacora = new BLL.BITACORA();

        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Suscribir(this);
            ActualizarIdioma();
        }
        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Atención",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                GestorBitacora.RegistrarEvento("Seguridad", "Cierre de sesión manual", 1);

                SESION.GetInstancia().Desasignar();

                UsuarioActual = null;
                this.Close();

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);
            if (UsuarioActual != null)
            {
                GestorBitacora.RegistrarEvento("Seguridad", "Cierre de sesión automatico", 1);
                SESION.GetInstancia().Desasignar();
            }

        }

        public void AbrirForm<T>() where T : Form, new()
        {
            this.Hide();

            using (T frm = new T())
            {
                frm.ShowDialog();
            }

            this.Show();
        }

        private void BitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            FrmBitacora FrmBitacora = new FrmBitacora();
            FrmBitacora.ShowDialog();

            this.Show();
        }

        private void controlDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            FrmCTRLUsuario FrmAdminCtrlUsuario = new FrmCTRLUsuario();
            FrmAdminCtrlUsuario.ShowDialog();

            this.Show();
        }

        private void controlDePermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            FrmCTRLPermiso FrmAdminCtrPermiso = new FrmCTRLPermiso();
            FrmAdminCtrPermiso.ShowDialog();

            this.Show();
        }

        public void ActualizarIdioma()
        {
            var traducciones = Servicios.IDIOMAS.GetInstancia().Traducciones;
            TraducirControles(this.Controls, traducciones);
            if (traducciones.TryGetValue($"{this.Name}_LBLbienvenida", out string textoBienvenida))
            {
                // string.Format agarra el texto de la BD ("Welcome: {0}") y reemplaza el {0} por el nombre
                LBLbienvenida.Text = string.Format(textoBienvenida, UsuarioActual.Usuario);
            }
            else
            {
                // Si no encuentra la traducción, ponemos un texto por defecto para que no quede en blanco
                LBLbienvenida.Text = $"Bienvenido: {UsuarioActual.Usuario}";
            }
            if (traducciones.TryGetValue($"{this.Name}_Titulo", out string textoTitulo))
            {
                this.Text = textoTitulo;
            }

        }
        public void TraducirControles(Control.ControlCollection controles, Dictionary<string, string> traducciones)
        {
            foreach (Control control in controles)
            {
                string clave = $"{this.Name}_{control.Name}";
                if (traducciones.TryGetValue(clave, out string textoTraducido))
                {
                    control.Text = textoTraducido;
                }
                if (control is MenuStrip menuStrip)
                {
                    foreach (ToolStripItem item in menuStrip.Items)
                    {
                        TraducirItemMenu(item, traducciones);
                    }
                }
                if (control.HasChildren)
                {
                    TraducirControles(control.Controls, traducciones);
                }
            }
        }
        private void TraducirItemMenu(ToolStripItem item, Dictionary<string, string> traducciones)
        {
            // Forma la clave igual que siempre
            string clave = $"{this.Name}_{item.Name}";
            if (traducciones.TryGetValue(clave, out string textoTraducido))
            {
                item.Text = textoTraducido;
            }

            // Si este ítem tiene "hijitos" (un menú desplegable), entramos recursivamente
            if (item is ToolStripMenuItem menuItem && menuItem.DropDownItems.Count > 0)
            {
                foreach (ToolStripItem subItem in menuItem.DropDownItems)
                {
                    TraducirItemMenu(subItem, traducciones);
                }
            }
        }
    }
}
