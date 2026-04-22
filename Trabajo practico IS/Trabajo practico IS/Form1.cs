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
    public partial class Form1 : Form
    {

        BE.USUARIO Usuario= new BE.USUARIO();
        BLL.USUARIO GestorUsuario = new BLL.USUARIO();
        BLL.BITACORA GestorBitacora= new BLL.BITACORA();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void EnlazarBitacora()
        {
            DGV_BITACORA.DataSource = null;
            DGV_BITACORA.DataSource = GestorBitacora.ObtenerHistorial();
            DGV_BITACORA.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        
        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Atención",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                GestorBitacora.RegistrarEvento("Seguridad", "Cierre de sesión manual", 1);


                SESION.GetInstancia().CerrarSesion();


                this.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorBitacora.RegistrarEvento("Seguridad", "Cierre de sesión automatico", 1);

            SESION.GetInstancia().CerrarSesion();
        }
    }
}
