using DAL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BITACORA
    {
        MP_BITACORA mapper = new MP_BITACORA();
        public void RegistrarEvento(string modulo, string operacion, int criticidad, string usuarioIntento=null)
        {
            BE.BITACORA log = new BE.BITACORA();
            log.Fecha = DateTime.Now;
            log.Modulo = modulo;
            log.Operacion = operacion;
            log.Criticidad = criticidad;
            if(!string.IsNullOrEmpty(usuarioIntento) )
            {
                log.Usuario= usuarioIntento;
            }
           else  if (SESION.GetInstancia().usuactual != null)
            {
                log.Usuario = SESION.GetInstancia().usuactual.Usuario;
            }
            else
            {
                log.Usuario = "Usuario no autenticado";
            }
            mapper.Alta(log);
        }
        public List<BE.BITACORA> ObtenerHistorial()
        {
            return mapper.ListarBitacora();
        }
    }
}
