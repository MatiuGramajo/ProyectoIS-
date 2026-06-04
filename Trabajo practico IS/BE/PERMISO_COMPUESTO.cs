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

        public PERMISO_COMPUESTO()
        {
            _hijos = new List<COMPONENTE>();
        }

        public override List<COMPONENTE> Hijos
        {
            get
            {
                return _hijos;
            }

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


    }
}
