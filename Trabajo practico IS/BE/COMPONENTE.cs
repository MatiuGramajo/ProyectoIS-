using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class COMPONENTE
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public abstract List<COMPONENTE> Hijos { get; }
        public abstract void AgregarHijo(COMPONENTE c);
        public abstract void VaciarHijos();
        public abstract void BorrarHijo(COMPONENTE c);
        public abstract COMPONENTE GetHijo(int index);
        public abstract bool TienePermiso(string nombrePermiso);
        public override string ToString()
        {
            return Nombre;
        }
    }
}
