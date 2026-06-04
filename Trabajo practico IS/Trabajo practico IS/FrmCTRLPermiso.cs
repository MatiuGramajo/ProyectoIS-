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
        BLL.PERMISO GestorPermiso = new BLL.PERMISO();

        public FrmCTRLPermiso()
        {
            InitializeComponent();
        }

        private void FrmCTRLPermiso_Load(object sender, EventArgs e)
        {
            CargarTreeView();
        }

        private void CargarTreeView()
        {
            BLL.PERMISO gestorPermisos = new BLL.PERMISO();
            treeView1.Nodes.Clear();

            // Pedimos las raíces a la BLL
            List<BE.COMPONENTE> raices = gestorPermisos.ObtenerArbolCompleto();

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
            foreach (var hijo in componentePadre.Hijos)
            {
                TreeNode nodoHijo = new TreeNode(hijo.Nombre);
                nodoHijo.Tag = hijo;

                nodoPadre.Nodes.Add(nodoHijo);

                // Volvemos a llamarnos a nosotros mismos por si el hijo tiene más hijos
                AgregarNodosRecursivos(nodoHijo, hijo);
            }
        }
    }
}
