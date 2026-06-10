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
        }
        private void FrmRestauracionBase_Load(object sender, EventArgs e)
        {
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
    }
}
