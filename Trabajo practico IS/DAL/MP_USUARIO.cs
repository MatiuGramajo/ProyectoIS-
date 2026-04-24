using BE;
using Microsoft.Win32;
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
            parametros.Add(acceso.CrearParametro("@contra", usuario.Contraseña));
            parametros.Add(acceso.CrearParametro("@dni", usuario.Dni));
            parametros.Add(acceso.CrearParametro("@email", usuario.Email));
            parametros.Add(acceso.CrearParametro("@rol", usuario.Rol));
            int res = acceso.Escribir("INSERTAR_USUARIO",parametros);
            acceso.Cerrar();
            
        }
        

        public override bool Verificar(USUARIO usuario)
        {
            acceso.Abrir();
            bool ok = false;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@usu", usuario.Usuario));
            parametros.Add(acceso.CrearParametro("@contra", usuario.Contraseña));
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
                usuarioEncontrado.Contraseña = row["Contraseña"].ToString();
                usuarioEncontrado.IntentosFallidos = Convert.ToInt32(row["IntentosFallidos"]);
                usuarioEncontrado.EstadoBloqueado = Convert.ToBoolean(row["EstadoBloqueado"]);


                return usuarioEncontrado;
            }

            return null; 
        }
        public void ActualizarIntentosFallidos(BE.USUARIO usuario)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@usu", usuario.Usuario));
            parametros.Add(acceso.CrearParametro("@intentos",usuario.IntentosFallidos));
            acceso.Escribir("ACTUALIZAR_INTENTOS_FALLIDOS", parametros);
            acceso.Cerrar();
        }
        public void ActualizarEstadoBloqueado(BE.USUARIO usuario)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@usu", usuario.Usuario));
            parametros.Add(acceso.CrearParametro("@estadobloqueado", usuario.EstadoBloqueado));
            acceso.Escribir("ACTUALIZAR_ESTADOBLOQUEADO", parametros);
            acceso.Cerrar();

        }

        public override void Baja(USUARIO usuario)
        {
            acceso.Abrir();
            List<SqlParameter>parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id", usuario.Id));
            acceso.Escribir("BORRAR_USUARIO", parametros);
            acceso.Cerrar();

        }

        public override void Modificar(USUARIO usuario)
        {
            acceso.Abrir();
            List<SqlParameter>parametros= new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id",usuario.Id));
            parametros.Add(acceso.CrearParametro("@usu", usuario.Usuario));
            parametros.Add(acceso.CrearParametro("@contra", usuario.Contraseña));
            parametros.Add(acceso.CrearParametro("@dni", usuario.Dni));
            parametros.Add(acceso.CrearParametro("@email", usuario.Email));
            parametros.Add(acceso.CrearParametro("@rol", usuario.Rol));
            int res = acceso.Escribir("MODIFICAR_USUARIO", parametros);
            acceso.Cerrar();
        }
        public override List<USUARIO> Listar()
        {
            acceso.Abrir();
            DataTable tabla = acceso.Leer("OBTENER_USUARIOS");
            acceso.Cerrar();
            List<BE.USUARIO> usuarios = new List<USUARIO>();
            foreach(DataRow registro in tabla.Rows)
            {
                BE.USUARIO usu= new BE.USUARIO();
                usu.Id = int.Parse(registro["ID"].ToString());
                usu.Usuario = registro["USUARIO"].ToString();
                usu.Contraseña = registro["CONTRASEÑA"].ToString();
                usu.EstadoBloqueado = bool.Parse(registro["ESTADOBLOQUEADO"].ToString());
                usu.IntentosFallidos = int.Parse(registro["INTENTOSFALLIDOS"].ToString());
                usu.Dni = int.Parse(registro["DNI"].ToString());
                usu.Email= registro["EMAIL"].ToString();
                usu.Rol = registro["ROL"].ToString();
                usuarios.Add(usu);
            }
            return usuarios;
        }
    }
}
