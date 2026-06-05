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
            if (!_observadores.Contains(observer))
                _observadores.Add(observer);
        }

        public void Notificar(string mensaje="")
        {
            // Recorre todos los formularios suscritos y les avisa que se actualicen
            foreach (var observer in _observadores)
            {
                observer.ActualizarIdioma();
            }
        }

        public void Suscribir(IObserver observer)
        {
            if(_observadores.Contains(observer))
                _observadores.Remove(observer);
        }

        public void CambiarIdioma(int nuevoIdIdioma)
        {
            // 1. Aquí irías a la BLL/DAL a buscar las nuevas traducciones para este Id.
            // 2. Guardas el idioma actual.
            // 3. Notificas a todos los formularios abiertos:
            Notificar();
        }
    }
}
