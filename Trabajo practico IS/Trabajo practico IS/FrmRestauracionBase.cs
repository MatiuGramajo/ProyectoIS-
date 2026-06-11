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
    public partial class FrmRestauracionBase : Form, BE.IObserver
    {
        BLL.RESTAURACION GestorRestauracion = new BLL.RESTAURACION();
        BLL.IDIOMA GestorIdioma = new BLL.IDIOMA();
        private bool _esEmergencia = true;
        private bool _reiniciando = false;
        public FrmRestauracionBase(string mensajeError)
        {
            InitializeComponent();
            LBMensajeError.Text = mensajeError;
            _esEmergencia = true;
            BTNHacerBackUp.Enabled = false;
        }

        public FrmRestauracionBase()
        {
            InitializeComponent();
            LBMensajeError.Text = "Estado: Base de datos íntegra. Acceso manual de administración.";
            _esEmergencia = false;
            BTNHacerBackUp.Enabled = true;
            BTNRecalcularDigito.Visible = false;
        }
        private void FrmRestauracionBase_Load(object sender, EventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Suscribir(this);
            CBXidiomas.SelectedIndexChanged -= CBXidiomas_SelectedIndexChanged;
            CBXidiomas.DataSource = GestorIdioma.Listar();
            CBXidiomas.DisplayMember = "Nombre";
            CBXidiomas.ValueMember = "Id";
            CBXidiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
            CBXidiomas.SelectedIndexChanged += CBXidiomas_SelectedIndexChanged;
            ActualizarIdioma();
            OFDBackUp.Filter = "Archivos de Backup SQL (*.bak)|*.bak";
            OFDBackUp.Title = "Seleccionar Copia de Seguridad para Restaurar";

            SFDBackUp.Filter = "Archivos de Backup SQL (*.bak)|*.bak";
            SFDBackUp.Title = "Guardar Nueva Copia de Seguridad";
            SFDBackUp.FileName = $"Backup_BASE_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
        }

        private void BTNRecalcularDigito_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "ADVERTENCIA DE SEGURIDAD:\n\nEsta operación computará nuevas firmas digitales (DVH y DVV) basándose en el estado actual de los registros.\nSi la base de datos fue alterada maliciosamente, esta acción 'legalizará' dichos cambios.\n\n¿Desea continuar con el recálculo total?",
                "Confirmar Recálculo de Emergencia",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    // Llamada al método de la BLL que orquesta la actualización y el registro en Bitácora
                    GestorRestauracion.RecalcularTodosLosDigitos();

                    Cursor = Cursors.Default;

                    MessageBox.Show("Los dígitos verificadores han sido regenerados con éxito. La base de datos vuelve a ser consistente.\n\nEl sistema se cerrará para aplicar los cambios de seguridad.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _reiniciando = true;
                    Application.Restart();
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show($"Ocurrió un error al intentar recalcular las firmas:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void ActualizarIdioma()
        {
            var traducciones = Servicios.IDIOMAS.GetInstancia().Traducciones;
            TraducirControles(this.Controls, traducciones);
            if (traducciones.TryGetValue($"{this.Name}_Titulo", out string textoTitulo)) this.Text = textoTitulo;
            if (CBXidiomas.Items.Count > 0)
            {
                CBXidiomas.SelectedIndexChanged -= CBXidiomas_SelectedIndexChanged;
                CBXidiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
                CBXidiomas.SelectedIndexChanged += CBXidiomas_SelectedIndexChanged;
            }

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

        private void BTNRestauracionVolverMenu_Click(object sender, EventArgs e)
        {
            if (_esEmergencia)
            {
                Application.Exit(); // Cierra todo si el sistema está corrupto
            }
            else
            {
                this.Close(); // Solo cierra esta ventana y vuelve al menú principal
            }
        }

        private void FrmRestauracionBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);

            if (_esEmergencia && !_reiniciando)
            {
                Application.Exit();
            }
        }

        private void BTNHacerBackUp_Click(object sender, EventArgs e)
        {
            if (SFDBackUp.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    // Llama a la BLL pasándole la ruta absoluta elegida por el usuario
                    GestorRestauracion.CrearBackup(SFDBackUp.FileName);

                    Cursor = Cursors.Default;

                    MessageBox.Show($"Copia de seguridad generada con éxito en:\n\n{SFDBackUp.FileName}", "Backup Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show($"Ocurrió un error al generar la copia de seguridad:\n\n{ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BTNExaminarBackUp_Click(object sender, EventArgs e)
        {
            if (OFDBackUp.ShowDialog() == DialogResult.OK)
            {
                TXTRutaBackUp.Text = OFDBackUp.FileName;
            }
        }

        private void BTNRestaurarBase_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TXTRutaBackUp.Text))
            {
                MessageBox.Show("Por favor, seleccione un archivo de copia de seguridad (.bak) utilizando el botón Examinar antes de continuar.");
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Está absolutamente seguro de que desea restaurar la base de datos?\n\n" +
                                                        "Esta acción reemplazará toda la información actual por la contenida en el archivo de respaldo.",
                                                        "Confirmar Restauración Crítica",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    // 4. INVOCACIÓN A LA CAPA DE NEGOCIO (BLL)
                    // Despacha la ruta absoluta hacia el Mapper de la DAL
                    GestorRestauracion.RestaurarBackup(TXTRutaBackUp.Text);

                    // 5. RESTABLECER ENTORNO VISUAL
                    Cursor = Cursors.Default;

                    MessageBox.Show("La base de datos ha sido restaurada con éxito.\n\n" +
                                    "El sistema se reiniciará automáticamente para validar la integridad de los nuevos datos.",
                                    "Restauración Exitosa",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    // 6. CONTROL DE TRANSICIÓN: Activamos la bandera protectora
                    // Esto le avisa al evento FormClosed que el cierre es intencional y legítimo.
                    _reiniciando = true;

                    // 7. PURGA DE MEMORIA: Destruye el Pool de conexiones viejo de ADO.NET, 
                    // limpia los Singletons y vuelve a lanzar el FrmLogIn totalmente limpio.
                    Application.Restart();
                }
                catch (Exception ex)
                {
                    // En caso de que falle (ej: archivo .bak corrupto o sin permisos de lectura en el disco)
                    // nos aseguramos de devolver el mouse a la normalidad y mostrar el mensaje técnico.
                    Cursor = Cursors.Default;
                    MessageBox.Show($"Ocurrió un error crítico durante el proceso de restauración:\n\n{ex.Message}",
                                    "Falla de Sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void CBXidiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CBXidiomas.SelectedValue != null && int.TryParse(CBXidiomas.SelectedValue.ToString(), out int idIdioma))
                {
                    BLL.IDIOMA gestorIdioma = new BLL.IDIOMA();
                    var traducciones = gestorIdioma.ObtenerTraducciones(idIdioma);

                    // Avisa a todos los formularios que cambien
                    Servicios.IDIOMAS.GetInstancia().CambiarIdioma(idIdioma, traducciones);

                    // Guarda la preferencia en la base de datos para este usuario
                    if (Servicios.SESION.GetInstancia().usuactual != null)
                    {
                        BLL.USUARIO gestorUsu = new BLL.USUARIO();
                        gestorUsu.ActualizarIdiomaUsuario(Servicios.SESION.GetInstancia().usuactual, idIdioma);
                        Servicios.SESION.GetInstancia().usuactual.IdIdioma = idIdioma;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
