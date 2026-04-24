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
    public partial class FrmBitacora : Form
    {
        BLL.BITACORA GestorBitacora= new BLL.BITACORA();
        public FrmBitacora()
        {
            InitializeComponent();
            EnlazarBitacora();
        }
        public void EnlazarBitacora()
        {
            DGV_BITACORA.DataSource = null;
            DGV_BITACORA.DataSource = GestorBitacora.ObtenerHistorial();
            DGV_BITACORA.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void FrmBitacora_Load(object sender, EventArgs e)
        {

        }

        private void BTN_CargarBitacora_Click(object sender, EventArgs e)
        {
            try
            {
                EnlazarBitacora();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la bitácora: " + ex.Message);
            }
        }
    }
}
