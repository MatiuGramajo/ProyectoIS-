using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class USUARIO
    {
        MP_USUARIO mapper = new MP_USUARIO();

        public void Insertar(BE.USUARIO usuario)
        {
            mapper.Alta(usuario);
        }

        public void LogIn(BE.USUARIO usuario)
        {
            // 1. Validaciones básicas de entrada
            if (string.IsNullOrWhiteSpace(usuario.Usuario) || string.IsNullOrWhiteSpace(usuario.Password))
                throw new Exception("Por favor, complete todos los campos.");

            // 2. Llamada al Mapper
            BE.USUARIO usuarioValido = mapper.ObtenerUsuario(usuario.Usuario, usuario.Password);

            // 3. Verificación de resultado e inicio de sesión
            if (usuarioValido != null)
            {
                Servicios.SESION.LogIn(usuarioValido);
            }
            else
            {
                throw new Exception("Nombre de usuario o contraseña incorrectos.");
            }
        }
    }
}
