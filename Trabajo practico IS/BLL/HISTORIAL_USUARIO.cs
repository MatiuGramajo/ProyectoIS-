using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HISTORIAL_USUARIO
    {
        private DAL.MP_HISTORIAL_USUARIO mapperHistorial = new DAL.MP_HISTORIAL_USUARIO();

        public void RegistrarCambio(int idUsuario, string usuarioResponsable, string tipoAccion)
        {
            mapperHistorial.RegistrarEnHistorial(idUsuario, usuarioResponsable, tipoAccion);
        }

        public List<BE.HISTORIAL_USUARIO> ObtenerHistorial(int idUsuario)
        {
            return mapperHistorial.ListarHistorialPorUsuario(idUsuario);
        }

        public void RestaurarUsuario(int idHistorial)
        {
            string responsable = Servicios.SESION.GetInstancia().usuactual.Usuario;
            mapperHistorial.RestaurarVersion(idHistorial, responsable);
        }
    }
}
