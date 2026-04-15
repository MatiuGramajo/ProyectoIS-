using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_practico_IS
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            bool reiniciar = true;

            while (reiniciar)
            {
                reiniciar = false;
                FrmLogIn login = new FrmLogIn();

                // Mostramos el Login como un cuadro de diálogo
                if (login.ShowDialog() == DialogResult.OK)
                {
                    // Si el login fue exitoso (pusimos DialogResult.OK en el botón ingresar)
                    Application.Run(new Form1());

                    // Al cerrarse Form1, verificamos si hay una sesión activa.
                    // Si el usuario NO cerró sesión (solo cerró la app), salimos.
                    // Si el usuario CERRÓ sesión, la variable Sesion será null.
                    if (Servicios.SESION.EstaLogeado == false)
                    {
                        reiniciar = true; // Volverá a empezar el bucle y mostrará el Login
                    }
                }
            }
        }
    }
}
