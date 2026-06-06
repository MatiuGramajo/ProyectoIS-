using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public  class IDIOMAS: BE.IObservable
    {

        private static IDIOMAS _instancia;
        private static object _lock = new object();
        private List<BE.IObserver> _observadores = new List<BE.IObserver>();
        public Dictionary<string, string> Traducciones { get; private set; } = new Dictionary<string, string>();
        public int IdIdiomaActual { get; private set; } = 1; // Por defecto arranca en 1 (Español)
        private IDIOMAS() { }

        public static IDIOMAS GetInstancia()
        {
            if(_instancia == null)
            {
                lock(_lock)
                {
                    if (_instancia == null) _instancia = new IDIOMAS();

                }
            }
            return _instancia;
        }

        public void Desuscribir(IObserver observer)
        {

            if (_observadores.Contains(observer))
                _observadores.Remove(observer);
        }

        public void Notificar(string mensaje="")
        {
            // Recorre todos los formularios suscritos y les avisa que se actualicen
            foreach (var observer in _observadores)
            {
                observer.ActualizarIdioma();
            }
        }
        // SOBRECARGA 1: Cambiar el idioma usando directamente un ID (ideal para cuando se loguea un usuario)
        public void CambiarIdioma(int idIdioma)
        {           
            IdIdiomaActual = idIdioma;
            BLL.BLL_IDIOMA bllIdioma = new BLL.BLL_IDIOMA();

            // Reemplaza el diccionario actual en memoria con las nuevas traducciones de la BD
            Traducciones = bllIdioma.ObtenerTraducciones(idIdioma);

            // Gatilla el cambio visual inmediato en todos los formularios abiertos
            Notificar();
        }
        // SOBRECARGA 2: Cambiar idioma de forma activa por el usuario (impacta memoria + Base de Datos)
        public void CambiarIdioma(int idIdioma, int idUsuarioLogueado)
        {
            // 1. Primero cambiamos la memoria local de la app
            CambiarIdioma(idIdioma);

            // 2. Persistimos la elección del usuario en la base de datos llamando a la DAL/BLL de usuarios
            DAL.MP_USUARIO mpUsuario = new DAL.MP_USUARIO(); // O usas tu BLL correspondiente
            mpUsuario.ActualizarIdiomaUsuario(idUsuarioLogueado, idIdioma);

            // 3. Sincronizamos el objeto de la sesión actual en memoria
            if (SESION.GetInstancia().usuactual != null)
            {
                SESION.GetInstancia().usuactual.IdIdioma = idIdioma;
            }
        }

        public void Suscribir(IObserver observer)
        {
            if (!_observadores.Contains(observer))
                _observadores.Add(observer);
        }

        //public void CambiarIdioma(int nuevoIdIdioma)
        //{
        //    // 1. Aquí irías a la BLL/DAL a buscar las nuevas traducciones para este Id.
        //    // 2. Guardas el idioma actual.
        //    // 3. Notificas a todos los formularios abiertos:
        //    Notificar();
        //}
    }
}
