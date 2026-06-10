using BLL;
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
        private bool idiomaCambiadoManualmente = false;
        public FrmLogIn()
        {
            InitializeComponent();
        }

        public void ActualizarIdioma()
        {
            var traducciones = Servicios.IDIOMAS.GetInstancia().Traducciones;
            TraducirControles(this.Controls, traducciones);
            if (CBXIdiomas.Items.Count > 0)
            {
                // Desenganchamos el evento temporalmente para que C# no intente ir a la BD 
                // mientras movemos la aguja del ComboBox por código
                CBXIdiomas.SelectedIndexChanged -= CBXIdiomas_SelectedIndexChanged;

                // Obligamos al combo a seleccionar visualmente el idioma que esté activo en la RAM global
                CBXIdiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;

                // Volvemos a enganchar el evento para que escuche los clics del usuario
                CBXIdiomas.SelectedIndexChanged += CBXIdiomas_SelectedIndexChanged;
            }

        }

        private void BTN_IniciarSesion_Click_1(object sender, EventArgs e)
        {
            try
            {
                // PASO 1: Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(TxtBoxUsuario.Text) || string.IsNullOrWhiteSpace(TxtBoxPassword.Text))
                    throw new Exception("Debe completar todos los campos");

                // PASO 2: Validar credenciales en la base de datos (y cargar la Sesión)
                GestorUsuario.LogIn(TxtBoxUsuario.Text, TxtBoxPassword.Text);

                // PASO 3: Lógica de prioridad de idioma (Combo vs Base de Datos)
                int idIdiomaFinalAAplicar = idiomaCambiadoManualmente ? Convert.ToInt32(CBXIdiomas.SelectedValue) : Servicios.SESION.GetInstancia().usuactual.IdIdioma;

                if (idiomaCambiadoManualmente)
                {
                    GestorUsuario.ActualizarIdiomaUsuario(Servicios.SESION.GetInstancia().usuactual, idIdiomaFinalAAplicar);
                    Servicios.SESION.GetInstancia().usuactual.IdIdioma = idIdiomaFinalAAplicar;
                }

                // PASO 4: Inyectar el idioma ganador en la memoria RAM
                var traduccionesUsuario = GestorIdioma.ObtenerTraducciones(idIdiomaFinalAAplicar);
                Servicios.IDIOMAS.GetInstancia().CambiarIdioma(idIdiomaFinalAAplicar, traduccionesUsuario);

                // PASO 5: Ocultar el Login y abrir el Menú Principal
                this.DialogResult = DialogResult.OK;
                this.Hide();

                FrmMenuPrincipal frmMenu = new FrmMenuPrincipal();
                frmMenu.ShowDialog();

                ProcesarPostLogout();
            }
            catch (Servicios.Excepciones.IntegridadDatosException ex)
            {
                ManejarFallaIntegridad(ex);

            }
            catch (Exception ex)
            {
                // Mostramos cualquier error (ej. Contraseña incorrecta)
                MessageBox.Show(ex.Message);
            }
            finally
            {
                TxtBoxUsuario.Text = "";
                TxtBoxPassword.Text = "";
            }
        }

        private void ManejarFallaIntegridad(Servicios.Excepciones.IntegridadDatosException ex)
        {
            var usuActual = Servicios.SESION.GetInstancia().usuactual;
            bool puedeRestaurarBD = false;

            // 1. Recorremos el Composite preguntando por la ACCIÓN ESPECÍFICA
            if (usuActual != null && usuActual.Permisos != null)
            {
                foreach (var permiso in usuActual.Permisos)
                {
                    // Preguntamos por el permiso puntual, no importa en qué rol esté guardado
                    if (permiso.TienePermiso("RESTAURACION_BASE"))
                    {
                        puedeRestaurarBD = true;
                        break;
                    }
                }
            }

            string msjError = $"¡ALERTA CRÍTICA DE SEGURIDAD!\n\n" +
                      $"Tabla Corrupta: {ex.TablaCorrupta}\n" +
                      $"Registro Afectado: {ex.RegistroAfectado}\n" +
                      $"Detalle Técnico: {ex.DetalleTecnico}";

            // 2. Tomamos la decisión en base a la acción
            if (puedeRestaurarBD)
            {
                MessageBox.Show(msjError, "Consola de Emergencia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Hide();

                FrmRestauracionBase frmEmergencia = new FrmRestauracionBase(msjError);
                frmEmergencia.ShowDialog();

                // B. Volvemos a hacer visible el formulario de Login
                //this.Show();
            }
            else
            {
                MessageBox.Show("El sistema se encuentra inhabilitado temporalmente debido a fallas técnicas graves de consistencia.\n\n" +
                        "Por favor, comuníquese con el administrador de seguridad para restablecer el servicio.",
                        "Error Fatal de Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                Application.Exit();
            }
        }

        private void ProcesarPostLogout()
        {
            try
            {
                // 1. Reseteamos la bandera para el próximo usuario que intente ingresar
                idiomaCambiadoManualmente = false;

                // 2. Por estandarización de UX, devolvemos el Login a su idioma base (Español = ID 1)
                int idEspañol = 1;
                var traduccionesEspañol = GestorIdioma.ObtenerTraducciones(idEspañol);

                // El Observer se encarga de disparar la actualización visual de este formulario
                Servicios.IDIOMAS.GetInstancia().CambiarIdioma(idEspañol, traduccionesEspañol);
            }
            catch (Exception)
            {
                // Silenciador de seguridad por si el motor de BD llega a fallar o desconectarse al salir
            }

            // 3. Desenganchamos y re-enganchamos el evento para refrescar la lista de idiomas de forma limpia
            CBXIdiomas.SelectedIndexChanged -= CBXIdiomas_SelectedIndexChanged;
            CBXIdiomas.DataSource = GestorIdioma.Listar();
            CBXIdiomas.SelectedIndexChanged += CBXIdiomas_SelectedIndexChanged;

            // 4. Volvemos a mostrar la pantalla de Login en el centro del escritorio, reluciente para el próximo ciclo
            this.Show();
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
            //MessageBox.Show("¡El evento se está ejecutando!");
            try
            {
                idiomaCambiadoManualmente = true;
                if (CBXIdiomas.SelectedValue != null && int.TryParse(CBXIdiomas.SelectedValue.ToString(), out int idIdiomaSeleccionado))
                {
                    var traducciones = GestorIdioma.ObtenerTraducciones(idIdiomaSeleccionado);
                    //MessageBox.Show($"Idioma ID: {idIdiomaSeleccionado}. Palabras encontradas en la BD: {traducciones.Count}");
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
