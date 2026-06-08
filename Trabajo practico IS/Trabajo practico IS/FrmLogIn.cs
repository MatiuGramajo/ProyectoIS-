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
    public partial class FrmLogIn : Form, BE.IObserver
    {

        BLL.USUARIO GestorUsuario = new BLL.USUARIO();
        BLL.IDIOMA GestorIdioma = new BLL.IDIOMA();
        public FrmLogIn()
        {
            InitializeComponent();
        }

        public void ActualizarIdioma()
        {
            var traducciones = Servicios.IDIOMAS.GetInstancia().Traducciones;
            TraducirControles(this.Controls, traducciones);
          
        }

        private void BTN_IniciarSesion_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(TxtBoxUsuario.Text) || string.IsNullOrWhiteSpace(TxtBoxPassword.Text)) throw new Exception("Debe completar todos los campos");
                BE.USUARIO usuarioIntent = new BE.USUARIO();
                usuarioIntent.Usuario = TxtBoxUsuario.Text;
                usuarioIntent.Contraseña = TxtBoxPassword.Text;

                GestorUsuario.LogIn(usuarioIntent.Usuario, usuarioIntent.Contraseña);

                //int idIdiomaUsuario = Servicios.SESION.GetInstancia().usuactual.IdIdioma;
                int idIdiomaSeleccionado = Convert.ToInt32(CBXIdiomas.SelectedValue);

                //var traduccionesUsuario = GestorIdioma.ObtenerTraducciones(idIdiomaUsuario);
                //Servicios.IDIOMAS.GetInstancia().CambiarIdioma(idIdiomaUsuario, traduccionesUsuario);
                var traduccionesActuales = GestorIdioma.ObtenerTraducciones(idIdiomaSeleccionado);

                // 4. Forzamos al Gestor de Servicios a mantener este idioma y este diccionario activo
                Servicios.IDIOMAS.GetInstancia().CambiarIdioma(idIdiomaSeleccionado, traduccionesActuales);
                // (Opcional) Si querés que además se guarde en la BD que este usuario prefiere este idioma para el futuro:
                int idUsuarioLogueado = Servicios.SESION.GetInstancia().usuactual.Id;
                GestorUsuario.ActualizarIdiomaUsuario(idUsuarioLogueado, idIdiomaSeleccionado);

                this.DialogResult = DialogResult.OK;
                this.Hide();

                FrmMenuPrincipal frmMenu = new FrmMenuPrincipal();
                frmMenu.ShowDialog();

                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            TxtBoxUsuario.Text = "";
            TxtBoxPassword.Text = "";
        }
        private void FrmLogIn_Load(object sender, EventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Suscribir(this);
            CBXIdiomas.SelectedIndexChanged -= CBXIdiomas_SelectedIndexChanged;
            CBXIdiomas.DataSource = GestorIdioma.Listar();
            CBXIdiomas.DisplayMember = "Nombre";
            CBXIdiomas.ValueMember= "Id";
            CBXIdiomas.SelectedIndex = -1;
            CBXIdiomas.SelectedIndexChanged += CBXIdiomas_SelectedIndexChanged;

        }

        private void FrmLogIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);
            
        }

        private void CBXIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("¡El evento se está ejecutando!");
            try
            {
                if (CBXIdiomas.SelectedValue != null && int.TryParse(CBXIdiomas.SelectedValue.ToString(), out int idIdiomaSeleccionado))
                {
                    var traducciones = GestorIdioma.ObtenerTraducciones(idIdiomaSeleccionado);
                    MessageBox.Show($"Idioma ID: {idIdiomaSeleccionado}. Palabras encontradas en la BD: {traducciones.Count}");
                    Servicios.IDIOMAS.GetInstancia().CambiarIdioma(idIdiomaSeleccionado, traducciones);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la Base de Datos: " + ex.Message);
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
                if (control.HasChildren)
                {
                    TraducirControles(control.Controls, traducciones);
                }
            }
        }
    }
}
