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
    public partial class FrmMenuPrincipal : Form
    {

        BE.USUARIO UsuarioActual = SESION.GetInstancia().usuactual;
        BLL.USUARIO GestorUsuario = new BLL.USUARIO();
        BLL.BITACORA GestorBitacora= new BLL.BITACORA();

        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = $"Bienvenido: {UsuarioActual.Usuario}";
        }
        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Atención",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                GestorBitacora.RegistrarEvento("Seguridad", "Cierre de sesión manual", 1);

                SESION.GetInstancia().CerrarSesion();
                
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
            if (UsuarioActual != null)
            {
                GestorBitacora.RegistrarEvento("Seguridad", "Cierre de sesión automatico", 1);
                SESION.GetInstancia().CerrarSesion();
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
            AbrirForm<FrmBitacora>();
        }

        private void controlDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm<FrmCTRLUsuario>();
        }
    }
}
