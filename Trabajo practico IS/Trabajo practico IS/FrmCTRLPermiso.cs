using BE;
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
    public partial class FrmCTRLPermiso : Form
    {
        BLL.PERMISO GestorPermisos = new BLL.PERMISO();

        public FrmCTRLPermiso()
        {
            InitializeComponent();
        }

        private void FrmCTRLPermiso_Load(object sender, EventArgs e)
        {
            CargarTreeView();
            CargarListBox();
        }

        private void CargarTreeView()
        {
            treeView1.Nodes.Clear();

            // Pedimos las raíces a la BLL
            List<BE.COMPONENTE> raices = GestorPermisos.ObtenerArbolCompleto();

            foreach (var componente in raices)
    {
                TreeNode nodoRaiz = new TreeNode(componente.Nombre);
                nodoRaiz.Tag = componente; // Guardamos el objeto en el Tag

                // Llamamos a la función recursiva para que busque los hijos, nietos, etc.
                AgregarNodosRecursivos(nodoRaiz, componente);

                treeView1.Nodes.Add(nodoRaiz);
            }
            treeView1.ExpandAll(); // Muestra el árbol desplegado
        }

        private void AgregarNodosRecursivos(TreeNode nodoPadre, BE.COMPONENTE componentePadre)
        {
            // Le preguntamos al componente cuántos hijos tiene (sin saber si es rama u hoja)
            int cantidad = componentePadre.GetCantidadHijos();

            // Iteramos de forma clásica
            for (int i = 0; i < cantidad; i++)
            {
                // Obtenemos el hijo por su índice
                BE.COMPONENTE hijo = componentePadre.GetHijo(i);

                if (hijo != null)
                {
                    TreeNode nodoHijo = new TreeNode(hijo.Nombre);
                    nodoHijo.Tag = hijo;

                    nodoPadre.Nodes.Add(nodoHijo);

                    // Recursividad
                    AgregarNodosRecursivos(nodoHijo, hijo);
                }
            }
        }

        private void CargarListBox()
        {
            listBox1.Items.Clear();
            var permisos = GestorPermisos.Listar();
            listBox1.Items.AddRange(permisos.ToArray());

        }

        private void BTNCtrlPermisoCrearRol_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TXTCtrlPermisoNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese un nombre para el Rol.");
                return;
            }

            BE.PERMISO_COMPUESTO nuevoRol = new BE.PERMISO_COMPUESTO();
            nuevoRol.Nombre = TXTCtrlPermisoNombre.Text;

            GestorPermisos.GuardarComponente(nuevoRol);

            MessageBox.Show("Rol compuesto creado con éxito.");

            TXTCtrlPermisoNombre.Text = "";
            CargarTreeView();
            CargarListBox();
        }

        private void BTNCtrlPermisoAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedItem == null)
                {
                    throw new Exception("Por favor, seleccionar un ROL o PERMISO del listbox.");
                }
                if (treeView1.SelectedNode == null)
                {
                    throw new Exception("Por favor, seleccione un ROL del treeview.");
                }

                var Padre = treeView1.SelectedNode.Tag as BE.COMPONENTE;
                var Hijo = listBox1.SelectedItem as BE.COMPONENTE;

                GestorPermisos.GuardarRelacion(Padre, Hijo);

                CargarTreeView();
                CargarListBox();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BTNCtrlPermisoDesasignar_Click(object sender, EventArgs e)
        {
            try
            {

                if (treeView1.SelectedNode == null)
                {
                    throw new Exception("Por favor, seleccione un ROL del treeview.");
                }
                if (treeView1.SelectedNode.Parent == null)
                {
                    MessageBox.Show("No puede desasignar un Rol principal (Raíz).", "Operación Inválida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                var Padre = treeView1.SelectedNode.Parent.Tag as BE.COMPONENTE;
                var Hijo = treeView1.SelectedNode.Tag as BE.COMPONENTE;

                DialogResult respuesta = MessageBox.Show($"¿Está seguro que desea quitar '{Hijo.Nombre}' del rol '{Padre.Nombre}'?", "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    GestorPermisos.BorrarRelacion(Padre, Hijo);
                }

                CargarTreeView();
                CargarListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
