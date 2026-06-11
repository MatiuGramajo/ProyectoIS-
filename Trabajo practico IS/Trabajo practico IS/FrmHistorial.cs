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
    public partial class FrmHistorial : Form, BE.IObserver
    {
        BLL.USUARIO gestorUsuario = new BLL.USUARIO();
        BLL.HISTORIAL_USUARIO GestorHistorialUsuario = new BLL.HISTORIAL_USUARIO();
        BLL.IDIOMA gestorIdioma = new BLL.IDIOMA();
        public FrmHistorial()
        {
            InitializeComponent();
        }

        public void ActualizarIdioma()
        {
            var traducciones = Servicios.IDIOMAS.GetInstancia().Traducciones;
            TraducirControles(this.Controls, traducciones);
            if (traducciones.TryGetValue($"{this.Name}_Titulo", out string textoTitulo)) this.Text = textoTitulo;
            if (CBXIdiomas.Items.Count > 0)
            {
                CBXIdiomas.SelectedIndexChanged -= CBXIdiomas_SelectedIndexChanged;
                CBXIdiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
                CBXIdiomas.SelectedIndexChanged += CBXIdiomas_SelectedIndexChanged;
            }
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
        private void FrmHistorial_Load(object sender, EventArgs e)
        {
            CBXUsuarios.DataSource = gestorUsuario.Listar();
            CBXUsuarios.DisplayMember = "Usuario";
            CBXUsuarios.ValueMember = "Id";
            CBXUsuarios.SelectedIndex = -1;

            Servicios.IDIOMAS.GetInstancia().Suscribir(this);
            CBXIdiomas.SelectedIndexChanged -= CBXIdiomas_SelectedIndexChanged;
            CBXIdiomas.DataSource = gestorIdioma.Listar();
            CBXIdiomas.DisplayMember = "Nombre";
            CBXIdiomas.ValueMember = "Id";
            CBXIdiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
            CBXIdiomas.SelectedIndexChanged += CBXIdiomas_SelectedIndexChanged;
            ActualizarIdioma(); // Tu método de siempre
        }

        private void CBXUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBXUsuarios.SelectedValue != null && int.TryParse(CBXUsuarios.SelectedValue.ToString(), out int idUsu))
            {
                DGVHistorial.DataSource = null;
                DGVHistorial.DataSource = GestorHistorialUsuario.ObtenerHistorial(idUsu);
            }
        }

        private void BTNrestaurar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVHistorial.CurrentRow == null) throw new Exception("Seleccione una versión para restaurar.");

                BE.HISTORIAL_USUARIO versionSeleccionada = (BE.HISTORIAL_USUARIO)DGVHistorial.CurrentRow.DataBoundItem;

                var r = MessageBox.Show($"¿Desea restaurar al usuario tal como estaba el {versionSeleccionada.FechaCambio}?", "Restaurar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (r == DialogResult.Yes)
                {
                    GestorHistorialUsuario.RestaurarUsuario(versionSeleccionada.IdHistorial);
                    MessageBox.Show("Usuario restaurado al estado seleccionado con éxito.");

                    // Recargamos la grilla para que se vea el nuevo registro "RESTAURACION"
                    CBXUsuarios_SelectedIndexChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CBXIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (CBXIdiomas.SelectedValue != null && int.TryParse(CBXIdiomas.SelectedValue.ToString(), out int idIdioma))
                {
                    BLL.IDIOMA gestorIdioma = new BLL.IDIOMA();
                    var traducciones = gestorIdioma.ObtenerTraducciones(idIdioma);

                    // Avisa a todos los formularios que cambien
                    Servicios.IDIOMAS.GetInstancia().CambiarIdioma(idIdioma, traducciones);

                    // Guarda la preferencia en la base de datos para este usuario
                    if (Servicios.SESION.GetInstancia().usuactual != null)
                    {
                        BLL.USUARIO gestorUsu = new BLL.USUARIO();
                        gestorUsu.ActualizarIdiomaUsuario(Servicios.SESION.GetInstancia().usuactual, idIdioma);
                        Servicios.SESION.GetInstancia().usuactual.IdIdioma = idIdioma;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void FrmHistorial_FormClosing(object sender, FormClosingEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);

        }


    }
}
