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
            CBX_Entidad.SelectedIndexChanged -= CBX_Entidad_SelectedIndexChanged;

            CBX_Entidad.Items.Clear();
            CBX_Entidad.Items.Add("Usuarios");
            CBX_Entidad.Items.Add("Productos");

            CBX_Entidad.SelectedIndexChanged += CBX_Entidad_SelectedIndexChanged;
            CBX_Entidad.SelectedIndex = 0;

            //CBXUsuarios.DataSource = gestorUsuario.Listar();
            //CBXUsuarios.DisplayMember = "Usuario";
            //CBXUsuarios.ValueMember = "Id";
            //CBXUsuarios.SelectedIndex = -1;

            Servicios.IDIOMAS.GetInstancia().Suscribir(this);
            CBXIdiomas.SelectedIndexChanged -= CBXIdiomas_SelectedIndexChanged;
            CBXIdiomas.DataSource = gestorIdioma.Listar();
            CBXIdiomas.DisplayMember = "Nombre";
            CBXIdiomas.ValueMember = "Id";
            CBXIdiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
            CBXIdiomas.SelectedIndexChanged += CBXIdiomas_SelectedIndexChanged;
            ActualizarIdioma(); 
        }

        private void CBXUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (CBXUsuarios.SelectedValue != null && int.TryParse(CBXUsuarios.SelectedValue.ToString(), out int idUsu))
            //{
            //    DGVHistorial.DataSource = null;
            //    DGVHistorial.DataSource = GestorHistorialUsuario.ObtenerHistorial(idUsu);
            //}
            //if (DGVHistorial.Columns.Count > 0)
            //{
            //    DGVHistorial.Columns["Id"].Visible = false;           
            //    DGVHistorial.Columns["IdHistorial"].Visible = false; 
            //    DGVHistorial.Columns["Contraseña"].Visible = false;   
            //    DGVHistorial.Columns["DVH"].Visible = false;
            //    DGVHistorial.Columns["IntentosFallidos"].Visible = false; 

            //    DGVHistorial.Columns["UsuarioAccion"].HeaderText = "Responsable";
            //    DGVHistorial.Columns["TipoAccion"].HeaderText = "Acción Realizada";
            //}
        }

        private void BTNrestaurar_Click(object sender, EventArgs e)
        {
            try
            {
                //if (DGVHistorial.CurrentRow == null) throw new Exception("Seleccione una versión para restaurar.");

                //BE.HISTORIAL_USUARIO versionSeleccionada = (BE.HISTORIAL_USUARIO)DGVHistorial.CurrentRow.DataBoundItem;

                //var r = MessageBox.Show($"¿Desea restaurar al usuario tal como estaba el {versionSeleccionada.FechaCambio}?", "Restaurar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                //if (r == DialogResult.Yes)
                //{
                //    GestorHistorialUsuario.RestaurarUsuario(versionSeleccionada.IdHistorial);
                //    MessageBox.Show("Usuario restaurado al estado seleccionado con éxito.");
                //    CBXUsuarios_SelectedIndexChanged(null, null);
                //}
                if (CBXUsuarios.SelectedValue == null || !int.TryParse(CBXUsuarios.SelectedValue.ToString(), out int idUsu))
                {
                    throw new Exception("Primero debe seleccionar un usuario para ver su historial.");
                }
                var historialCompleto = GestorHistorialUsuario.ObtenerHistorial(idUsu);
                if (historialCompleto.Count <= 1)
                {
                    throw new Exception("Este usuario no tiene modificaciones previas. No hay un estado anterior para recomponer.");
                }
                BE.HISTORIAL_USUARIO estadoAnterior = historialCompleto[1];

                var r = MessageBox.Show($"¿Desea recomponer TODOS los atributos del usuario al estado inmediatamente anterior (del día {estadoAnterior.FechaCambio})?", "Deshacer Último Cambio", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    // Ejecutamos la restauración usando el ID del estado anterior, ignorando qué tocó en la grilla
                    GestorHistorialUsuario.RestaurarUsuario(estadoAnterior.IdHistorial);
                    MessageBox.Show("Se han recompuesto todos los atributos al estado anterior con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargamos la grilla para que se vea la nueva fila "RESTAURACION"
                    CBXUsuarios_SelectedIndexChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Servicios.IDIOMAS.GetInstancia().CambiarIdioma(idIdioma, traducciones);
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

        private void BTNvolveralmenu_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Desea volver al menu principal?", "Atención",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();

            }
        }

        private void CBX_Entidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBX_Entidad.SelectedItem == null) return;

            // Guardamos la cadena de texto de la opción elegida ("Usuarios" o "Productos")
            string entidadSeleccionada = CBX_Entidad.SelectedItem.ToString();

            // 1. Llamamos al método que descarga los datos en la grilla general
            CargarGrillaGeneral(entidadSeleccionada);

            // 2. Llamamos al método que actualiza en cascada el segundo combo de filtros
            CargarComboFiltroEspecifico(entidadSeleccionada);
        }

        private void CargarComboFiltroEspecifico(string entidadSeleccionada)
        {
            // Desvinculamos el evento temporalmente para que no se dispare mientras cargamos
            CBX_Filtro.SelectedIndexChanged -= CBX_Filtro_SelectedIndexChanged;
            CBX_Filtro.DataSource = null;

            if (entidadSeleccionada == "Usuarios")
            {
                BLL.USUARIO gestorUsu = new BLL.USUARIO();
                CBX_Filtro.DataSource = gestorUsu.Listar();
                CBX_Filtro.DisplayMember = "Usuario"; // O como se llame la propiedad de nombre
                CBX_Filtro.ValueMember = "Id";
            }
            else if (entidadSeleccionada == "Productos")
            {
                BLL.PRODUCTO gestorProd = new BLL.PRODUCTO();
                CBX_Filtro.DataSource = gestorProd.Listar();
                CBX_Filtro.DisplayMember = "Nombre";
                CBX_Filtro.ValueMember = "Id";
            }

            CBX_Filtro.SelectedIndex = -1; // Lo dejamos en blanco por defecto
            CBX_Filtro.SelectedIndexChanged += CBX_Filtro_SelectedIndexChanged;
        }

        private void CargarGrillaGeneral(string entidad)
        {
            try
            {
                // Limpiamos por completo el DataSource para que el DataGridView regenere las columnas
                DGVHistorial.DataSource = null;

                if (entidad == "Usuarios")
                {
                    BLL.HISTORIAL_USUARIO gestorHistUsu = new BLL.HISTORIAL_USUARIO();
                    List<BE.HISTORIAL_USUARIO> listaUsuarios = gestorHistUsu.Listar();

                    DGVHistorial.DataSource = listaUsuarios;
                }
                else if (entidad == "Productos")
                {
                    BLL.HISTORIAL_PRODUCTO gestorHistProd = new BLL.HISTORIAL_PRODUCTO();
                    List<BE.HISTORIAL_PRODUCTO> listaProductos = gestorHistProd.Listar();

                    DGVHistorial.DataSource = listaProductos;
                }

                // --- Configuración e Integridad Visual de la Grilla ---
                DGVHistorial.ReadOnly = true; // Súper importante en auditoría para que no se altere el log
                DGVHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selecciona la fila completa

                // Ocultamos las claves primarias técnicas del historial que no le aportan valor al usuario
                if (DGVHistorial.Columns["IdHistorial"] != null)
                {
                    DGVHistorial.Columns["IdHistorial"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar el historial de {entidad}: {ex.Message}",
                                "Error de Arquitectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CBX_Filtro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBX_Filtro.SelectedItem == null || CBX_Entidad.SelectedItem == null) return;

            try
            {
                string entidadActiva = CBX_Entidad.SelectedItem.ToString();
                int idSeleccionado = (int)CBX_Filtro.SelectedValue;

                if (entidadActiva == "Usuarios")
                {
                    BLL.HISTORIAL_USUARIO gestorHistUsu = new BLL.HISTORIAL_USUARIO();
                    var historialCompleto = gestorHistUsu.Listar();

                    // FILTRO LINQ: Traemos solo los historiales donde el Id coincide
                    var historialFiltrado = historialCompleto.Where(h => h.Id == idSeleccionado).ToList();

                    DGVHistorial.DataSource = null;
                    DGVHistorial.DataSource = historialFiltrado;
                }
                else if (entidadActiva == "Productos")
                {
                    BLL.HISTORIAL_PRODUCTO gestorHistProd = new BLL.HISTORIAL_PRODUCTO();
                    var historialCompleto = gestorHistProd.Listar();

                    // FILTRO LINQ: Traemos solo los historiales de ese producto
                    var historialFiltrado = historialCompleto.Where(h => h.IdProducto == idSeleccionado).ToList();

                    DGVHistorial.DataSource = null;
                    DGVHistorial.DataSource = historialFiltrado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al filtrar");
            }
        }

        private void BTN_LimpiarFiltrosHist_Click(object sender, EventArgs e)
        {
            CBX_Filtro.SelectedIndex = -1;

            // Volvemos a cargar la grilla completa
            if (CBX_Entidad.SelectedItem != null)
            {
                CargarGrillaGeneral(CBX_Entidad.SelectedItem.ToString());
            }
        }
    }
}
