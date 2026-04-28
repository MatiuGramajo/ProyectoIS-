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
    public partial class FrmBitacora : Form
    {
        BLL.BITACORA GestorBitacora= new BLL.BITACORA();
        public FrmBitacora()
        {
            InitializeComponent();
        }
        public void EnlazarUsuarios()
        {
            CBXBitacoraUsuario.DataSource = null;
            CBXBitacoraUsuario.DataSource = GestorBitacora.ObtenerUsuarios();
            CBXBitacoraUsuario.DisplayMember = "Usuario";
            CBXBitacoraUsuario.SelectedIndex = -1;
        }
        public void EnlazarModulo()
        {
            CBXBitacoraModulo.DataSource = null;
            CBXBitacoraModulo.DataSource = GestorBitacora.ObtenerModulo();
            CBXBitacoraModulo.DisplayMember = "Modulo";
            CBXBitacoraModulo.SelectedIndex = -1;


        }
        public void EnlazarCriticidad()
        {
            CBXBitacoraCriticidad.DataSource = null;
            CBXBitacoraCriticidad.DataSource = GestorBitacora.ObtenerCriticidad();
            CBXBitacoraCriticidad.DisplayMember = "Criticidad";
            CBXBitacoraCriticidad.SelectedIndex = -1;

        }
        public void EnlazarBitacora()
        {
            DateTime desde = DTPBitacoraDesde.Value;
            DateTime hasta = DTPBitacoraHasta.Value;
            List<BE.BITACORA> ListaFiltrada = GestorBitacora.ObtenerHistorial(desde, hasta);
            if(CBXBitacoraUsuario.SelectedIndex !=-1)
            {
                string usuarioSeleccionado = CBXBitacoraUsuario.Text;
                List<BE.BITACORA> FiltrarUsuarios = (from l in ListaFiltrada
                                                     where l.Usuario == usuarioSeleccionado
                                                     select l).ToList();
                ListaFiltrada = FiltrarUsuarios;
            }
            if (CBXBitacoraModulo.SelectedIndex != -1)
            {
                string moduloSeleccionado = CBXBitacoraModulo.Text;
                List<BE.BITACORA> FiltrarModulo = (from m in ListaFiltrada
                                                     where m.Modulo == moduloSeleccionado
                                                     select m).ToList();
                ListaFiltrada = FiltrarModulo;
            }
            if (CBXBitacoraCriticidad.SelectedIndex != -1)
            {
                string criticidadSeleccionada = CBXBitacoraCriticidad.Text;
                List<BE.BITACORA> FiltrarCriticidad = (from c in ListaFiltrada
                                                     where c.Criticidad == int.Parse(criticidadSeleccionada)
                                                     select c).ToList();
                ListaFiltrada = FiltrarCriticidad;
            }
            DGV_BITACORA.DataSource = null;
            DGV_BITACORA.DataSource = ListaFiltrada;
        }
        public void EnlazarBitacoraTotal()
        {
            List<BE.BITACORA> ListaTotalFiltrada = GestorBitacora.ObtenerHistorialCompleto();
            if (CBXBitacoraUsuario.SelectedIndex != -1)
            {
                string usuarioSeleccionado = CBXBitacoraUsuario.Text;
                List<BE.BITACORA> FiltrarUsuarios = (from l in ListaTotalFiltrada
                                                     where l.Usuario == usuarioSeleccionado
                                                     select l).ToList();
                ListaTotalFiltrada = FiltrarUsuarios;
            }
            if (CBXBitacoraModulo.SelectedIndex != -1)
            {
                string moduloSeleccionado = CBXBitacoraModulo.Text;
                List<BE.BITACORA> FiltrarModulo = (from m in ListaTotalFiltrada
                                                   where m.Modulo == moduloSeleccionado
                                                   select m).ToList();
                ListaTotalFiltrada = FiltrarModulo;
            }
            if (CBXBitacoraCriticidad.SelectedIndex != -1)
            {
                string criticidadSeleccionada = CBXBitacoraCriticidad.Text;
                List<BE.BITACORA> FiltrarCriticidad = (from c in ListaTotalFiltrada
                                                       where c.Criticidad == int.Parse(criticidadSeleccionada)
                                                       select c).ToList();
                ListaTotalFiltrada = FiltrarCriticidad;
            }
            DGV_BITACORA.DataSource = null;
            DGV_BITACORA.DataSource = ListaTotalFiltrada;

        }
       
        private void FrmBitacora_Load(object sender, EventArgs e)
        {
            DTPBitacoraDesde.Value = DateTime.Now.AddDays(-2);
            DTPBitacoraHasta.Value = DateTime.Now;
            EnlazarCriticidad();
            EnlazarModulo();
            EnlazarUsuarios();
            EnlazarBitacora();
            checkBox1.Checked = false;
            DTPBitacoraDesde.Enabled = false;
            DTPBitacoraHasta.Enabled = false;  
            

        }

        private void BTN_CargarBitacora_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            { 
                if (DTPBitacoraHasta.Value < DTPBitacoraDesde.Value)
                {
                MessageBox.Show("La fecha final debe ser menor que la inicial.");
                return;
                }
              EnlazarBitacora();
            }
           else
            {
                EnlazarBitacoraTotal();
            }
            CBXBitacoraUsuario.SelectedIndex = -1;
            CBXBitacoraModulo.SelectedIndex = -1;
            CBXBitacoraCriticidad.SelectedIndex = -1;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DTPBitacoraDesde.Enabled = checkBox1.Checked;
            DTPBitacoraHasta.Enabled = checkBox1.Checked;
        }

        private void BTN_BitacoraVolverAlMenu_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Desea volver al menu principal?", "Atención",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();

            }
        }
    }
}
