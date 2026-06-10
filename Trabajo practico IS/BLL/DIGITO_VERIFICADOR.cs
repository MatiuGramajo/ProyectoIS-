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
        MP_DIGITO_VERIFICADOR MapperDV = new MP_DIGITO_VERIFICADOR();
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

        public string ObtenerDVV(string nombreTabla)
        {
            return MapperDV.ObtenerDVV(nombreTabla);
        }

        // 1. EL NUEVO MÉTODO (Solo calcula y devuelve el Hash, no toca la BD)
        // Este es el que usa tu clase AUDITORIA
        public string CalcularDVV(List<string> todosLosDvh)
        {
            // Si la lista viene vacía, devolvemos el hash de una cadena vacía
            if (todosLosDvh == null || todosLosDvh.Count == 0)
            {
                return ENCRIPTADOR.Hashear("");
            }

            StringBuilder cadenaGlobal = new StringBuilder();

            foreach (string dvh in todosLosDvh)
            {
                cadenaGlobal.Append(dvh);
            }

            return ENCRIPTADOR.Hashear(cadenaGlobal.ToString());
        }

        // 2. EL MÉTODO DE GUARDADO (Reutiliza el método de arriba)
        // Este es el que usas cuando das de Alta, Baja o Modificas un usuario
        public void RecalcularYGuardarDVV(string nombreTabla, List<string> todosLosDvh)
        {
            // Reutilizamos la lógica matemática que armamos arriba
            string nuevoDvv = CalcularDVV(todosLosDvh);

            // Guardamos en la base de datos
            MapperDV.ActualizarDVV(nombreTabla, nuevoDvv);
        }
    }
}
