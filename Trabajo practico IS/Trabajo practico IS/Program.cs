using Servicios;
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
            //Application.Run(new FrmLogIn());
            bool continuarSistema = true;

            while (continuarSistema)
            {
                // 1. Mostramos el Login como un cuadro de diálogo (ShowDialog)
                FrmLogIn login = new FrmLogIn();

                if (login.ShowDialog() == DialogResult.OK)
                {
                    // 2. Si el login fue exitoso, ejecutamos el Form Principal
                    // El Application.Run se queda "trabado" acá hasta que cierres el Form1
                    Application.Run(new Form1());

                    // 3. Al salir de Form1, verificamos: 
                    // ¿Se salió porque se cerró la sesión (usuario es null)? 
                    // ¿O porque cerraron el programa con la X?
                    if (SESION.GetInstancia().usuactual == null)
                    {
                        continuarSistema = true; // Volver al inicio del bucle (Login)
                    }
                    else
                    {
                        continuarSistema = false; // Salir definitivamente del programa
                    }
                }
                else
                {
                    // Si el usuario cerró el Login o canceló, salimos del bucle
                    continuarSistema = false;
                }
            }

        }
    }
}
