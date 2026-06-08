using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_practico_IS.Utilidades
{
    public static class GES_PERMISOS_GUI
    {
        public static void AplicarPermisos(Form formulario)
        {
            BE.USUARIO usuarioActual = SESION.GetInstancia().usuactual;
            if (usuarioActual == null) return;

            // 1. Recorremos los controles normales del formulario
            ValidarControlesRecursivo(formulario.Controls, usuarioActual);

            // 2. BUSCAMOS MENUS: Si el formulario tiene un MenuStrip, lo recorremos específicamente
            foreach (Control ctrl in formulario.Controls)
            {
                if (ctrl is MenuStrip menu)
                {
                    foreach (ToolStripMenuItem item in menu.Items)
                    {
                        ValidarMenuRecursivo(item, usuarioActual);
                    }
                }
            }
        }

        // Validación para controles normales (Botones, Paneles, etc.)
        private static void ValidarControlesRecursivo(Control.ControlCollection controles, BE.USUARIO usuario)
        {
            foreach (Control ctrl in controles)
            {
                if (ctrl.Tag != null && !string.IsNullOrWhiteSpace(ctrl.Tag.ToString()))
                {
                    ctrl.Visible = usuario.TienePermiso(ctrl.Tag.ToString());
                }

                if (ctrl.HasChildren)
                {
                    ValidarControlesRecursivo(ctrl.Controls, usuario);
                }
            }
        }

        // Validación exclusiva para ítems de Menú (que no son 'Controls' de Windows Forms)
        private static void ValidarMenuRecursivo(ToolStripMenuItem item, BE.USUARIO usuario)
        {
            // Validamos el ítem actual
            if (item.Tag != null && !string.IsNullOrWhiteSpace(item.Tag.ToString()))
            {
                item.Visible = usuario.TienePermiso(item.Tag.ToString());
            }

            // Recursividad: Si este menú tiene sub-menús, los recorremos
            foreach (ToolStripItem subItem in item.DropDownItems)
            {
                if (subItem is ToolStripMenuItem subMenu)
                {
                    ValidarMenuRecursivo(subMenu, usuario);
                }
            }
        }

    }
}
