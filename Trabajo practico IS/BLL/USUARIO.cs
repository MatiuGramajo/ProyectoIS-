using DAL;
using Servicios;
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

        public void LogIn(string nombreUsuario, string contraseñaIngresada)
        {
            string hashingresado = ENCRIPTADOR.Hashear(contraseñaIngresada);
            BE.USUARIO usuariovalido = mapper.ObtenerUsuario(nombreUsuario);

            if (usuariovalido == null)
            {
                throw new Exception("Usuario o contraseña incorrectos.");
            }
            if (usuariovalido.EstadoBloqueado)
            {
                throw new Exception("El usuario se encuentra bloqueado. Contacte al administrador.");
            }

            if (usuariovalido.Password != hashingresado)
            {
                usuariovalido.IntentosFallidos++;
                if (usuariovalido.IntentosFallidos >= 3)
                {
                    usuariovalido.EstadoBloqueado = true;
                    mapper.ActualizarUsuario(usuariovalido);
                    throw new Exception("Usuario bloqueado por superar el límite de 3 intentos fallidos.");
                }
                else
                {
                    mapper.ActualizarUsuario(usuariovalido);
                    throw new Exception($"Contraseña incorrecta. Intentos restantes: {3 - usuariovalido.IntentosFallidos}");

                }

            }
            usuariovalido.IntentosFallidos = 0;
            mapper.ActualizarUsuario(usuariovalido);  
            SESION.GetInstancia().IniciarSesion(usuariovalido);
        }
    }
}
