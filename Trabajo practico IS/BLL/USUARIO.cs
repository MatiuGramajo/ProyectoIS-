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
        BLL.BITACORA gestorBitacora= new BLL.BITACORA();

        public void Insertar(BE.USUARIO usuario)
        {
            mapper.Alta(usuario);
        }

        public void Borrar(BE.USUARIO usuario)
        {
            mapper.Baja(usuario);
        }

        public void Modificar(BE.USUARIO usuario)
        {
            mapper.Modificar(usuario);
        }

        public List<BE.USUARIO> Listar()
        {
            return mapper.Listar();
        }

        public void LogIn(string nombreUsuario, string contraseñaIngresada)
        {
            string hashingresado = ENCRIPTADOR.Hashear(contraseñaIngresada);
            BE.USUARIO usuariovalido = mapper.ObtenerUsuario(nombreUsuario);

            if (usuariovalido == null)
            {
                gestorBitacora.RegistrarEvento("Seguridad", "Intento de acceso con usuario inexistente:", 2) ;
                throw new Exception("Usuario o contraseña incorrectos.");

            }
            if (usuariovalido.EstadoBloqueado)
            {
                gestorBitacora.RegistrarEvento("Seguridad", "Intento de acceso de cuenta bloqueada: ", 2, nombreUsuario);
                throw new Exception("El usuario se encuentra bloqueado. Contacte al administrador.");
            }


            if (usuariovalido.Contraseña != hashingresado)
            {
                usuariovalido.IntentosFallidos++;
                if (usuariovalido.IntentosFallidos >= 3)
                {
                    usuariovalido.EstadoBloqueado = true;
                    mapper.ActualizarIntentosFallidos(usuariovalido);
                    mapper.ActualizarEstadoBloqueado(usuariovalido);
                    gestorBitacora.RegistrarEvento("Seguridad", "Usuario bloqueado por múltiples intentos fallidos: ", 3, nombreUsuario);
                    throw new Exception("Usuario bloqueado por superar el límite de 3 intentos fallidos.");
                }
                else
                {
                    mapper.ActualizarIntentosFallidos(usuariovalido);
                    throw new Exception($"Contraseña incorrecta. Intentos restantes: {3 - usuariovalido.IntentosFallidos}");
                }

            }
            usuariovalido.IntentosFallidos = 0;
            mapper.ActualizarIntentosFallidos(usuariovalido);  
            SESION.GetInstancia().IniciarSesion(usuariovalido);
            gestorBitacora.RegistrarEvento("Seguridad", "Inicio de sesión exitoso", 1);
        }
    }
}
