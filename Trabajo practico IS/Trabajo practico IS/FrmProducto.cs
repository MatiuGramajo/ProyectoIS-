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
    public partial class FrmProducto : Form, BE.IObserver
    {
        BLL.PRODUCTO GestorProductos = new BLL.PRODUCTO();
        BLL.IDIOMA GestorIdioma = new BLL.IDIOMA();
        BLL.BITACORA GestorBitacora = new BLL.BITACORA();
        BE.PRODUCTO productoSeleccionado = null;
        public FrmProducto()
        {
            InitializeComponent();
        }
        private void FrmProducto_Load(object sender, EventArgs e)
        {
            EnlazarProductos();
        }

        public void EnlazarProductos()
        {
            List<BE.PRODUCTO> ListaProductos = GestorProductos.Listar();
            DGV_Productos.DataSource = null;
            DGV_Productos.DataSource = ListaProductos;
            DGV_Productos.Columns["Id"].Visible = false;

        }
        public void LimpiarControles()
        {
            TXT_ProductoNombre.Text = "";
            NUD_PrecioProd.Value = 0;
            NUD_StockProd.Value = 0;
        }
        private void BTN_ProductoAlta_Click(object sender, EventArgs e)
        {
            try
            {
                BE.PRODUCTO nuevoProducto = new BE.PRODUCTO();
                nuevoProducto.Nombre = TXT_ProductoNombre.Text;
                nuevoProducto.Precio = NUD_PrecioProd.Value;
                nuevoProducto.Stock = (int)NUD_StockProd.Value;

                GestorProductos.Insertar(nuevoProducto);

                EnlazarProductos();
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BTN_ProductoBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (productoSeleccionado != null)
                {
                    var result = MessageBox.Show($"Esta seguro que desea borrar: {productoSeleccionado.Nombre}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        GestorProductos.Borrar(productoSeleccionado);
                        EnlazarProductos();
                        LimpiarControles();
                        productoSeleccionado = null;
                    }
                }
                else
                {
                    throw new Exception("Seleccione un producto para borrar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BTN_ProductoModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (productoSeleccionado != null)
                {
                    productoSeleccionado.Nombre = TXT_ProductoNombre.Text;
                    productoSeleccionado.Precio = NUD_PrecioProd.Value;
                    productoSeleccionado.Stock = (int)NUD_StockProd.Value;

                    GestorProductos.Modificar(productoSeleccionado);
                    GestorBitacora.RegistrarEvento("Inventario", $"Se modificó el producto: {productoSeleccionado.Nombre}", 3);

                    EnlazarProductos();
                    LimpiarControles();
                    productoSeleccionado = null;
                }
                else
                {
                    MessageBox.Show("Seleccione un producto para modificar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                EnlazarProductos();
            }
        }

        private void DGV_Productos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                productoSeleccionado = DGV_Productos.Rows[e.RowIndex].DataBoundItem as BE.PRODUCTO;
                TXT_ProductoNombre.Text = productoSeleccionado.Nombre;
                NUD_PrecioProd.Value = productoSeleccionado.Precio;
                NUD_StockProd.Value = productoSeleccionado.Stock;
            }
        }

        public void ActualizarIdioma()
        {
            throw new NotImplementedException();
        }
    }
}
