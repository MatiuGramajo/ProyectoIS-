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
    public partial class FrmCTRLUsuario : Form
    {

        BLL.USUARIO GestorUsuarios = new BLL.USUARIO();
        BLL.BITACORA GestorBitacora = new BLL.BITACORA();
        
        public FrmCTRLUsuario()
        {
            InitializeComponent();
        }

        private void FrmCTRLUsuario_Load(object sender, EventArgs e)
        {
            EnlazarUsuarios();
        }

        public void EnlazarUsuarios()
        {
            DGV_CtrlUsuUsuarios.DataSource = null;
            DGV_CtrlUsuUsuarios.DataSource = GestorUsuarios.Listar();
            DGV_CtrlUsuUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void BTNCtrlUsuAlta_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(TXT_CtrlUsuUsuario.Text) || string.IsNullOrEmpty(TXT_CtrlUsuContraseña.Text) || string.IsNullOrEmpty(TXT_CtrlUsuDNI.Text) || string.IsNullOrEmpty(TXT_CtrlUsuEmail.Text) || string.IsNullOrEmpty(CBX_CtrlUsuRol.Text)))
            {
                BE.USUARIO usuario = new BE.USUARIO();
                usuario.Usuario = TXT_CtrlUsuUsuario.Text;
                usuario.Contraseña = ENCRIPTADOR.Hashear(TXT_CtrlUsuContraseña.Text);                
                usuario.Dni = int.Parse(TXT_CtrlUsuDNI.Text);
                usuario.Email = TXT_CtrlUsuEmail.Text;
                usuario.Rol = CBX_CtrlUsuRol.SelectedItem.ToString();

                GestorUsuarios.Insertar(usuario);
                GestorBitacora.RegistrarEvento("Administracion", $"Se dio de alta al usuario {usuario.Usuario}",1);
            }
            else 
            {
                MessageBox.Show("Debe completar todos los datos");
            }
            EnlazarUsuarios();
        }

        private void BTNCtrlUsuBaja_Click(object sender, EventArgs e)
        {

        }

        private void BTNCtrlUsuModificar_Click(object sender, EventArgs e)
        {

        }

        private void BTNCtrlUsuDesbloquear_Click(object sender, EventArgs e)
        {

        }
    }
}
