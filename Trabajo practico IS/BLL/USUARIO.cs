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
        BLL.PERMISO gestorPermisos = new BLL.PERMISO();
        BLL.DIGITO_VERIFICADOR GestorDV = new BLL.DIGITO_VERIFICADOR();

        public void Insertar(BE.USUARIO usuario)
        {
            usuario.DVH = GestorDV.CalcularDVH(usuario);
            mapper.Alta(usuario);
            ActualizarDvvUsuarios();
        }

        public void Borrar(BE.USUARIO usuario)
        {
            mapper.Baja(usuario);
            ActualizarDvvUsuarios();
        }

        public void Modificar(BE.USUARIO usuario)
        {
            usuario.DVH = GestorDV.CalcularDVH(usuario);
            mapper.Modificar(usuario);
            ActualizarDvvUsuarios();
        }

        public List<BE.USUARIO> Listar()
        {
            return mapper.Listar();
        }
        public void DesbloquearUsuario(BE.USUARIO usuario)
        {
            usuario.DVH = GestorDV.CalcularDVH(usuario);

            mapper.ActualizarEstadoBloqueado(usuario);
            ActualizarDvvUsuarios();
        }
        public void ActualizarIdiomaUsuario(BE.USUARIO usuario, int idIdioma)
        {

            usuario.IdIdioma = idIdioma;
            usuario.DVH = GestorDV.CalcularDVH(usuario);

            mapper.ActualizarIdiomaUsuario(usuario); // Asegúrate que tu mapper reciba el BE completo

            List<string> todosLosDvhs = mapper.ObtenerTodosLosDVH();

            GestorDV.RecalcularYGuardarDVV("USUARIO", todosLosDvhs);
        }

        public void LogIn(string nombreUsuario, string contraseñaIngresada)
        {
            string hashingresado = ENCRIPTADOR.Hashear(contraseñaIngresada);
            BE.USUARIO usuariovalido = mapper.ObtenerUsuario(nombreUsuario);

            if (usuariovalido == null)  
            {
                gestorBitacora.RegistrarEvento("Seguridad", "Intento de acceso con usuario inexistente:", 3) ;
                throw new Exception("Usuario o contraseña incorrectos.");

            }
            if (usuariovalido.EstadoBloqueado)
            {
                gestorBitacora.RegistrarEvento("Seguridad", "Intento de acceso de cuenta bloqueada: ", 4, nombreUsuario);
                throw new Exception("El usuario se encuentra bloqueado. Contacte al administrador.");
            }


            if (usuariovalido.Contraseña != hashingresado)
            {
                usuariovalido.IntentosFallidos++;
                if (usuariovalido.IntentosFallidos >= 3)
                {
                    usuariovalido.EstadoBloqueado = true;
                    usuariovalido.DVH = GestorDV.CalcularDVH(usuariovalido);
                    mapper.ActualizarIntentosFallidos(usuariovalido);
                    mapper.ActualizarEstadoBloqueado(usuariovalido);
                    ActualizarDvvUsuarios();

                    gestorBitacora.RegistrarEvento("Seguridad", "Usuario bloqueado por múltiples intentos fallidos: ", 4, nombreUsuario);
                    throw new Exception("Usuario bloqueado por superar el límite de 3 intentos fallidos.");
                }
                else
                {
                    usuariovalido.DVH = GestorDV.CalcularDVH(usuariovalido);
                    mapper.ActualizarIntentosFallidos(usuariovalido);
                    ActualizarDvvUsuarios();

                    throw new Exception($"Contraseña incorrecta. Intentos restantes: {3 - usuariovalido.IntentosFallidos}");
                }

            }
            usuariovalido.IntentosFallidos = 0;
            usuariovalido.DVH = GestorDV.CalcularDVH(usuariovalido);
            mapper.ActualizarIntentosFallidos(usuariovalido);
            
            usuariovalido.Permisos = gestorPermisos.ObtenerPermisosUsuario(usuariovalido.Id);
            SESION.GetInstancia().AsignarUsuario(usuariovalido);

            gestorBitacora.RegistrarEvento("Seguridad", "Inicio de sesión exitoso", 1);
        }

        private void ActualizarDvvUsuarios()
        {
            // Extraemos la lista de la BD
            List<string> todosDvh = mapper.ObtenerTodosLosDVH();

            // Delegamos el recálculo
            GestorDV.RecalcularYGuardarDVV("USUARIO", todosDvh);
        }

        public void ActualizarSoloDVH(int idUsuario, string nuevoDvh)
        {
            mapper.ActualizarSoloDVH(idUsuario, nuevoDvh);
        }
    }
}
