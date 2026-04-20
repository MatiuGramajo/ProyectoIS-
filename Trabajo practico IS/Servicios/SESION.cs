using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class SESION
    {
        private static SESION Sesion;
        public static bool EstaLogeado => Sesion != null;
        private static SESION _instancia;
        public USUARIO usuactual { get; set; }
        private static object _lock = new object();
        private SESION() { }

        public static SESION GetInstancia()
        {
            if (_instancia == null)
            {
                lock (_lock)
                {
                    if (_instancia == null)
                    {
                        _instancia = new SESION();
                    }

                }
            }
            return _instancia;
        }

        public void IniciarSesion(USUARIO usuario)
        {
            if (usuactual != null)
            {
                throw new Exception("Ya hay una sesion activa.");
            }
            usuactual = usuario;
        }
        public void CerrarSesion()
        {
            usuactual = null;
        }
        //private static object _Lock = new object();
        //private static SESION Sesion;

        //public USUARIO Usuario { get; set; }
        //public DateTime Fecha { get; set; }

        //public static bool EstaLogeado => Sesion != null;
        //private SESION()
        //{

        //}
        //public static SESION ObtenerSesion
        //{
        //    get
        //    {
        //        if (Sesion == null) throw new Exception("Sesion no iniciada");
        //        return Sesion;
        //    }
        //}

        //public static void LogIn(USUARIO usuario)
        //{
        //    lock (_Lock)
        //    {
        //        if (Sesion == null)
        //        {
        //            Sesion = new SESION();
        //            Sesion.Usuario = usuario;
        //            Sesion.Fecha = DateTime.Now;
        //        }
        //        else
        //        {
        //            throw new Exception("Sesion ya iniciada");
        //        }
        //    }
        //}

        //public static void LogOut()
        //{
        //    lock (_Lock)
        //    {
        //        if (Sesion != null)
        //        {
        //            Sesion = null;
        //        }
        //        else
        //        {
        //            throw new Exception("Sesion no iniciada");
        //        }
        //    }
        //}



    }
}
