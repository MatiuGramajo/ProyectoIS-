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


        private void BTN_IniciarSesion_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(TxtBoxUsuario.Text) || string.IsNullOrWhiteSpace(TxtBoxPassword.Text)) throw new Exception("Debe completar todos los campos");
                BE.USUARIO usuarioIntent = new BE.USUARIO();
                usuarioIntent.Usuario = TxtBoxUsuario.Text;
                usuarioIntent.Contraseña = TxtBoxPassword.Text;

                GestorUsuario.LogIn(usuarioIntent.Usuario, usuarioIntent.Contraseña);

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
    }
}
