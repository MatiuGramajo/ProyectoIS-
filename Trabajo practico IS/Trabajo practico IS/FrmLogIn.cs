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
        BLL.AUDITORIA Auditoria = new BLL.AUDITORIA();
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

                BE.USUARIO usuarioIntent = new BE.USUARIO();
                usuarioIntent.Usuario = TxtBoxUsuario.Text;
                usuarioIntent.Contraseña = TxtBoxPassword.Text;

                // PASO 2: Validar credenciales en la base de datos (y cargar la Sesión)
                GestorUsuario.LogIn(usuarioIntent.Usuario, usuarioIntent.Contraseña);

                Auditoria.AuditarSistema();

                // PASO 3: Lógica de prioridad de idioma (Combo vs Base de Datos)
                int idIdiomaFinalAAplicar;

                if (idiomaCambiadoManualmente)
                {
                    // GANA EL COMBOBOX: El usuario movió el combo manualmente.
                    idIdiomaFinalAAplicar = Convert.ToInt32(CBXIdiomas.SelectedValue);

                    // Actualizamos su perfil en la BD para recordarlo en el futuro
                    GestorUsuario.ActualizarIdiomaUsuario(Servicios.SESION.GetInstancia().usuactual, idIdiomaFinalAAplicar);
                    Servicios.SESION.GetInstancia().usuactual.IdIdioma = idIdiomaFinalAAplicar;
                }
                else
                {
                    // GANA LA BD: El usuario no tocó el combo. Respetamos su historial.
                    idIdiomaFinalAAplicar = Servicios.SESION.GetInstancia().usuactual.IdIdioma;
                }

                // PASO 4: Inyectar el idioma ganador en la memoria RAM
                var traduccionesUsuario = GestorIdioma.ObtenerTraducciones(idIdiomaFinalAAplicar);
                Servicios.IDIOMAS.GetInstancia().CambiarIdioma(idIdiomaFinalAAplicar, traduccionesUsuario);

                // PASO 5: Ocultar el Login y abrir el Menú Principal
                this.DialogResult = DialogResult.OK;
                this.Hide();

                FrmMenuPrincipal frmMenu = new FrmMenuPrincipal();
                frmMenu.ShowDialog();

                // PASO 6: POST-LOGOUT (Se ejecuta cuando cierran el Menú Principal)
                try
                {
                    idiomaCambiadoManualmente = false; // Reseteamos la bandera para el próximo usuario

                    int idEspañol = 1; // 1 = Español (Idioma por defecto)
                    var traduccionesEspañol = GestorIdioma.ObtenerTraducciones(idEspañol);
                    Servicios.IDIOMAS.GetInstancia().CambiarIdioma(idEspañol, traduccionesEspañol);
                }
                catch (Exception)
                {
                    // Silenciador de seguridad por si falla la BD al salir
                }
                CBXIdiomas.SelectedIndexChanged -= CBXIdiomas_SelectedIndexChanged;
                CBXIdiomas.DataSource = GestorIdioma.Listar();
                CBXIdiomas.SelectedIndexChanged += CBXIdiomas_SelectedIndexChanged;
                // Mostramos el Login de nuevo (limpio y en español)
                this.Show();
            }
            catch (Servicios.Excepciones.IntegridadDatosException ex)
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

                // 2. Tomamos la decisión en base a la acción
                if (puedeRestaurarBD)
                {
                    string msjError = $"¡ALERTA CRÍTICA!\n\nTabla: {ex.TablaCorrupta}\nRegistro: {ex.RegistroAfectado}\nDetalle: {ex.DetalleTecnico}";
                    MessageBox.Show(msjError, "Consola de Emergencia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.Hide();

                    //FrmMenuPrincipal frmMenu = new FrmMenuPrincipal();
                    //frmMenu.ShowDialog();
                    FrmRestauracionBase frmEmergencia = new FrmRestauracionBase(msjError);
                    frmEmergencia.ShowDialog();


                    // B. Volvemos a hacer visible el formulario de Login
                    //this.Show();

                }
                else
                {
                    MessageBox.Show("El sistema se encuentra inhabilitado debido a problemas técnicos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }

            }
            catch (Exception ex)
            {
                // Mostramos cualquier error (ej. Contraseña incorrecta)
                MessageBox.Show(ex.Message);
            }

            // PASO 7: Limpiar las cajas de texto de usuario y contraseña
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
