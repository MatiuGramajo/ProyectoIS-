using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_HISTORIAL_PRODUCTO
    {
        DAL.ACCESO acceso = new DAL.ACCESO();

        public void RegistrarEnHistorial(BE.HISTORIAL_PRODUCTO historial)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(acceso.CrearParametro("@id_producto", historial.IdProducto));
            parametros.Add(acceso.CrearParametro("@usuario_accion", historial.UsuarioAccion));
            parametros.Add(acceso.CrearParametro("@tipo_accion", historial.TipoAccion));
            parametros.Add(acceso.CrearParametro("@nombre", historial.Nombre));
            parametros.Add(acceso.CrearParametro("@precio", historial.Precio));
            parametros.Add(acceso.CrearParametro("@stock", historial.Stock));

            acceso.Escribir("INSERTAR_HISTORIAL_PRODUCTO", parametros);
            acceso.Cerrar();
        }
    }
}
