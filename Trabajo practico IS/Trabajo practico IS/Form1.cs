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
        SESION sesion;
        BE.USUARIO Usuario= new BE.USUARIO();
        BLL.USUARIO GestorUsuario = new BLL.USUARIO();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //using (FrmLogIn frmLogin = new FrmLogIn())
            //{
            //    
            //    if (frmLogin.ShowDialog() == DialogResult.OK)
            //    {
            //        sesion = SESION.ObtenerSesion;
            //        //Usuario = frmLogin.Usuario;
            //        string user = sesion.Usuario.Usuario;
            //        MessageBox.Show("USUARIO: " + user);
            //        
            //    }
            //    else
            //    {
            //        Application.Exit();
            //    }
            //}
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Atención",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 2. Ejecutar LogOut de tu capa de servicios
                Servicios.SESION.LogOut();

                // 3. Cerrar este formulario
                this.Close();
            }
        }
    }
}
