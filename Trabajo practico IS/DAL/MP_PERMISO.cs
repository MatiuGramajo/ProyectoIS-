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
    public class MP_PERMISO : MAPPER<BE.COMPONENTE>
    {
        public override void Alta(COMPONENTE permiso)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@nombre", permiso.Nombre));
            bool esCompuesto = permiso is BE.PERMISO_COMPUESTO;
            parametros.Add(acceso.CrearParametro("@esCompuesto", esCompuesto));
            int res = acceso.Escribir("INSERTAR_PERMISO", parametros);
            acceso.Cerrar();
        }

        public void GuardarRelacion(int idPadre, int idHijo)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@idPadre", idPadre));
            parametros.Add(acceso.CrearParametro("@idHijo", idHijo));
            acceso.Escribir("INSERTAR_PERMISO_PERMISO", parametros);
            acceso.Cerrar();
        }

        public override void Baja(COMPONENTE obj)
        {
            throw new NotImplementedException();
        }

        public override List<COMPONENTE> Listar()
        {
            acceso.Abrir();
            DataTable tabla = acceso.Leer("LISTAR_PERMISOS");
            acceso.Cerrar();
            List<BE.COMPONENTE> listaPermisos = new List<BE.COMPONENTE>();
            foreach (DataRow registro in tabla.Rows)
            {
                BE.COMPONENTE permiso;
                bool esCompuesto = bool.Parse(registro["EsCompuesto"].ToString());
                if (esCompuesto)
                {
                    permiso = new BE.PERMISO_COMPUESTO();
                }
                else
                {
                    permiso = new BE.PERMISO_SIMPLE();
                }
                permiso.Id = int.Parse(registro["Id"].ToString());
                permiso.Nombre = registro["Nombre"].ToString();

                listaPermisos.Add(permiso);
            }

            return listaPermisos;
        }

        public override void Modificar(COMPONENTE obj)
        {
            throw new NotImplementedException();
        }

        public override bool Verificar(COMPONENTE obj)
        {
            throw new NotImplementedException();
        }
        public DataTable ObtenerTablaRelacionesAuxiliar()
        {
            acceso.Abrir();
            DataTable dt = acceso.Leer("OBTENER_RELACIONES_PERMISOS");
            acceso.Cerrar();
            return dt;
        }
    }
}
