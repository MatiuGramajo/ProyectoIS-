using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PERMISO_COMPUESTO : COMPONENTE
    {
        private List<COMPONENTE> _hijos;

        public override bool EsCompuesto
        {
            get { return true; }
        }

        public PERMISO_COMPUESTO()
        {
            _hijos = new List<COMPONENTE>();
        }

        public override void VaciarHijos()
        {
            _hijos = new List<COMPONENTE>();
        }
        public override void AgregarHijo(COMPONENTE c)
        {
            _hijos.Add(c);
        }

        public override void BorrarHijo(COMPONENTE c)
        {
            _hijos.Remove(c);
        
        }
        public override COMPONENTE GetHijo(int index)
        {
            if (index < 0 || index >= _hijos.Count)
                return null;

            return _hijos[index];
        }

        public override int GetCantidadHijos()
        {
            return _hijos.Count;
        }

        public override bool TienePermiso(string nombrePermiso)
        {
            if (this.Nombre.Equals(nombrePermiso, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            // 2. Si no soy yo, delego la pregunta a todos mis hijos
            // (Como estamos adentro de la clase, podemos usar nuestra lista privada _hijos sin problema)
            foreach (var hijo in _hijos)
            {
                // ¡Acá está la recursividad polimórfica!
                if (hijo.TienePermiso(nombrePermiso))
                {
                    return true;
                }
            }

            // 3. Si revisé a todos mis hijos, nietos, etc., y ninguno lo tiene...
            return false;
        }
    }
}
