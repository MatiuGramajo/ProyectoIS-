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
    public class MP_USUARIO : MAPPER<BE.USUARIO>
    {
        public override void Alta(USUARIO usuario)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@usu", usuario.Usuario));
            parametros.Add(acceso.CrearParametro("@pass", usuario.Password));
            int res = acceso.Escribir("INSERTAR_USUARIO",parametros);
            acceso.Cerrar();
            
        }

        public override bool Verificar(USUARIO usuario)
        {
            acceso.Abrir();
            bool ok = false;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@usu", usuario.Usuario));
            parametros.Add(acceso.CrearParametro("@pass", usuario.Password));
            SqlDataReader reader = acceso.Read("VERIFICAR_USUARIO", parametros);
            ok = reader.HasRows;
            reader.Close();
            acceso.Cerrar();
            return ok;
        }

        public BE.USUARIO ObtenerUsuario(string username)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@usu", username));
            DataTable dt = acceso.Leer("OBTENER_USUARIO_POR_NOMBRE", parametros);
            acceso.Cerrar();

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                BE.USUARIO usuarioEncontrado = new BE.USUARIO();

                usuarioEncontrado.Id = Convert.ToInt32(row["Id"]);
                usuarioEncontrado.Usuario = row["Usuario"].ToString();
                usuarioEncontrado.Password = row["Password"].ToString(); 
                usuarioEncontrado.IntentosFallidos = Convert.ToInt32(row["IntentosFallidos"]);
                usuarioEncontrado.EstadoBloqueado = Convert.ToBoolean(row["EstadoBloqueado"]);

                return usuarioEncontrado;
            }

            return null; 
        }
        public void ActualizarUsuario(BE.USUARIO usuario)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@usu", usuario.Usuario));
            parametros.Add(acceso.CrearParametro("@intentos",usuario.IntentosFallidos));
            acceso.Escribir("ACTUALIZAR_INTENTOS_FALLIDOS", parametros);
            acceso.Cerrar();
        }
    }
}
