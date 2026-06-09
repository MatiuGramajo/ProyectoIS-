using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class IDIOMA
    {
      
            private DAL.MP_IDIOMA mapper = new DAL.MP_IDIOMA();

            public List<BE.IDIOMA> Listar()
            {
                return mapper.Listar();
            }

            public Dictionary<string, string> ObtenerTraducciones(int idIdioma)
            {
                return mapper.ObtenerTraducciones(idIdioma);
            }
        
        public void CrearIdioma(string nombreIdioma, string sufijo)
        {
            mapper.AltaIdioma(nombreIdioma, sufijo);
        }
    }
}
