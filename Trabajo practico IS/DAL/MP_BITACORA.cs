using BE;
using System;
using System.Collections.Generic;
using System.Data;
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
            parametros.Add(acceso.CrearParametro("@fecha", obj.Fecha));
            parametros.Add(acceso.CrearParametro("@usuario", obj.Usuario));
            parametros.Add(acceso.CrearParametro("@modulo", obj.Modulo));
            parametros.Add(acceso.CrearParametro("@operacion", obj.Operacion));
            parametros.Add(acceso.CrearParametro("@criticidad", obj.Criticidad));
            int res = acceso.Escribir("INSERTAR_BITACORA", parametros);
            acceso.Cerrar();
        }

        public override bool Verificar(BITACORA obj)
        {
            throw new NotImplementedException();
        }
        public List<BE.BITACORA> ListarBitacora()
        {
            acceso.Abrir();
            DataTable tabla = acceso.Leer("OBTENER_BITACORA");
            acceso.Cerrar();
            List<BE.BITACORA> listalog = new List<BE.BITACORA>();
            foreach (DataRow registro in tabla.Rows)
            {
                BE.BITACORA log = new BE.BITACORA();
                log.Id = int.Parse(registro["ID_BITACORA"].ToString());
                log.Fecha = DateTime.Parse(registro["FECHA"].ToString());
                log.Usuario = registro["USUARIO"].ToString();
                log.Modulo = registro["MODULO"].ToString();
                log.Operacion = registro["OPERACION"].ToString();
                log.Criticidad = int.Parse(registro["CRITICIDAD"].ToString());
                listalog.Add(log);


            }    
            return listalog; 
        }
    }
}
