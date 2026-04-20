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
    public partial class FrmLogIn : Form
    {
        BLL.USUARIO GestorUsuario = new BLL.USUARIO();
        public FrmLogIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BE.USUARIO usuarioIntent = new BE.USUARIO();
                usuarioIntent.Usuario = TxtBoxUsuario.Text;
                usuarioIntent.Password = TxtBoxPassword.Text;

                GestorUsuario.LogIn(usuarioIntent.Usuario, usuarioIntent.Password);

                // Si llegó hasta acá sin lanzar excepción, el login fue exitoso
                //MessageBox.Show($"Bienvenido {Servicios.SESION.ObtenerSesion.Usuario.Usuario}");
                MessageBox.Show($"Bienvenido{usuarioIntent.Usuario}");



                this.DialogResult = DialogResult.OK; // Para cerrar el login y abrir el main
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
