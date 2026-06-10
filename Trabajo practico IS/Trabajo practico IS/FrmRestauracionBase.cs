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
    public partial class FrmRestauracionBase : Form
    {
        BLL.RESTAURACION GestorRestauracion = new BLL.RESTAURACION();
        public FrmRestauracionBase(string mensajeError)
        {
            InitializeComponent();
            LBMensajeError.Text = mensajeError;
        }

        private void FrmRestauracionBase_Load(object sender, EventArgs e)
        {

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

                    Application.Exit();
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show($"Ocurrió un error al intentar recalcular las firmas:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
