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

        public override bool Verficar(USUARIO usuario)
        {
            acceso.Abrir();
            bool ok = false;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@usu", usuario.Usuario));
            parametros.Add(acceso.CrearParametro("@con", usuario.Password));
            SqlDataReader reader = acceso.Read("VERIFICAR_USUARIO", parametros);
            ok = reader.HasRows;
            reader.Close();
            acceso.Cerrar();
            return ok;
        }

        public BE.USUARIO ObtenerUsuario(string username, string password)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@usu", username));
            parametros.Add(acceso.CrearParametro("@pass", password));

            // Usamos el método Leer que ya tenés en ACCESO para obtener un DataTable
            DataTable dt = acceso.Leer("VERIFICAR_USUARIO", parametros);
            acceso.Cerrar();

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                BE.USUARIO usuarioEncontrado = new BE.USUARIO();

                // Mapeo manual de las columnas a la entidad
                usuarioEncontrado.Id = Convert.ToInt32(row["Id"]);
                usuarioEncontrado.Usuario = row["Usuario"].ToString();
                // No mapeamos la password por seguridad, o la dejamos si es necesario

                return usuarioEncontrado;
            }

            return null; // Si no hay filas, las credenciales son incorrectas
        }
    }
}
