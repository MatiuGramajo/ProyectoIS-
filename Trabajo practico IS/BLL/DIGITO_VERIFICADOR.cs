using BE;
using DAL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DIGITO_VERIFICADOR
    {
        MP_DIGITO_VERIFICADOR MapperDVV = new MP_DIGITO_VERIFICADOR();
        public string CalcularDVH(BE.USUARIO usuario)
        {
            string cadenaAHashear = $"{usuario.Id}" +
                                    $"{usuario.Usuario}" +
                                    $"{usuario.Contraseña}" +
                                    $"{usuario.EstadoBloqueado}" +
                                    $"{usuario.IntentosFallidos}" +
                                    $"{usuario.Dni}" +
                                    $"{usuario.Email}" +
                                    $"{usuario.IdIdioma}";

            return ENCRIPTADOR.Hashear(cadenaAHashear);
        }

        public string CalcularDVV(List<string> todosLosDvh)
        {
            StringBuilder sb = new StringBuilder();

            // Es vital que la lista venga siempre ordenada por el ID de la base de datos
            foreach (var dvh in todosLosDvh)
            {
                sb.Append(dvh);
            }

            // Reutilizamos TU clase ENCRIPTADOR nuevamente
            return ENCRIPTADOR.Hashear(sb.ToString());
        }

        public void RecalcularYGuardarDVV(string nombreTabla, List<string> todosLosDvh)
        {
            // Usa el método interno para generar el nuevo DVV
            string nuevoDvv = CalcularDVV(todosLosDvh);

            // Lo manda directo a la base de datos a través del DAL
            MapperDVV.ActualizarDVV(nombreTabla, nuevoDvv);
        }
    }
}
