using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PERMISO_SIMPLE : COMPONENTE
    {
        public override List<COMPONENTE> Hijos
        {
            get
            {
                return new List<COMPONENTE>();
            }

        }

        public override void AgregarHijo(COMPONENTE c)
        {
            throw new NotImplementedException();
        }

        public override void GetHijos(int index)
        {
            throw new NotImplementedException();
        }

        public override void VaciarHijos()
        {
            throw new NotImplementedException();
        }
    }
}
