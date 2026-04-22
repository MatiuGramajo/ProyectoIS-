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
        //SESION sesion;
        MP_BITACORA mapper = new MP_BITACORA();
        public void RegistrarEvento(string modulo, string operacion, int criticidad)
        {
            BE.BITACORA log = new BE.BITACORA();
            log.Fecha = DateTime.Now;
            log.Modulo = modulo;
            //log.Usuario = usuario;
            log.Operacion = operacion;
            log.Criticidad = criticidad;
            log.Usuario = SESION.GetInstancia().usuactual.Usuario;
            mapper.Alta(log);
        }
        public List<BE.BITACORA> ObtenerHistorial()
        {
            return mapper.ListarBitacora();
        }
    }
}
