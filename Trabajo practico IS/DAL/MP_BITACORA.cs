using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_BITACORA : MAPPER<BE.BITACORA>
    {
        public override void Alta(BITACORA obj)
        {
            acceso.Abrir();
            List<SqlParameter>parametros= new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id_bitacora", obj.Id));
            parametros.Add(acceso.CrearParametro("@fecha", obj.Fecha));
            parametros.Add(acceso.CrearParametro("@usu", obj.Usuario));
            parametros.Add(acceso.CrearParametro("@modulo", obj.Modulo));
            parametros.Add(acceso.CrearParametro("@operacion", obj.Operacion));
            parametros.Add(acceso.CrearParametro("@criticidad", obj.Criticidad));
            int res = acceso.Escribir("INSERTAR_NUEVOLOG", parametros);
            acceso.Cerrar();
        }

        public override bool Verificar(BITACORA obj)
        {
            throw new NotImplementedException();
        }
    }
}
