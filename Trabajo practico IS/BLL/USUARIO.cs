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
        BLL.AUDITORIA Auditoria = new BLL.AUDITORIA();
        BLL.HISTORIAL_USUARIO gestorHistorial = new BLL.HISTORIAL_USUARIO();

        public void Insertar(BE.USUARIO usuario)
        {
            List<BE.USUARIO> todosLosUsuarios = mapper.Listar();

            if (todosLosUsuarios.Any(u => u.Usuario.Equals(usuario.Usuario, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception("El nombre de usuario ya se encuentra registrado en el sistema.");
            }

            if (todosLosUsuarios.Any(u => u.Dni == usuario.Dni))
            {
                throw new Exception("El DNI ingresado ya pertenece a un usuario registrado.");
            }

            if (todosLosUsuarios.Any(u => u.Email.Equals(usuario.Email, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception("El correo electrónico ya se encuentra registrado.");
            }

            usuario.DVH = GestorDV.CalcularDVH(usuario);
            mapper.Alta(usuario);
            ActualizarDvvUsuarios();
            string responsable;
            if (Servicios.SESION.GetInstancia().usuactual != null)
            {
                responsable = Servicios.SESION.GetInstancia().usuactual.Usuario;
            }
            else
            {
                responsable = "SISTEMA";
            }
            gestorHistorial.RegistrarCambio(usuario.Id, responsable, "ALTA");
        }

        public void Borrar(BE.USUARIO usuario)
        {
            mapper.Baja(usuario);
            ActualizarDvvUsuarios();
        }

        public void Modificar(BE.USUARIO usuario)
        {
            List<BE.USUARIO> todosLosUsuarios = mapper.Listar();

            if (todosLosUsuarios.Any(u => u.Id != usuario.Id && u.Usuario.Equals(usuario.Usuario, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception("El nombre de usuario ya está siendo utilizado por otra cuenta.");
            }

            if (todosLosUsuarios.Any(u => u.Id != usuario.Id && u.Dni == usuario.Dni))
            {
                throw new Exception("El DNI ingresado ya pertenece a otro usuario en el sistema.");
            }

            if (todosLosUsuarios.Any(u => u.Id != usuario.Id && u.Email.Equals(usuario.Email, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception("El correo electrónico ya está asignado a otro usuario.");
            }
            usuario.DVH = GestorDV.CalcularDVH(usuario);
            mapper.Modificar(usuario);
            ActualizarDvvUsuarios();
            string responsable;
            if (Servicios.SESION.GetInstancia().usuactual != null)
            {
                responsable = Servicios.SESION.GetInstancia().usuactual.Usuario;
            }
            else
            {
                responsable = "SISTEMA";
            }
            gestorHistorial.RegistrarCambio(usuario.Id, responsable, "MODIFICACION");
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
            string responsable;

            if (Servicios.SESION.GetInstancia().usuactual != null)
            {
                responsable = Servicios.SESION.GetInstancia().usuactual.Usuario;
            }
            else
            {
                responsable = "SISTEMA";
            }
            gestorHistorial.RegistrarCambio(usuario.Id, responsable, "DESBLOQUEO");
        }
        public void ActualizarIdiomaUsuario(BE.USUARIO usuario, int idIdioma)
        {
            usuario.IdIdioma = idIdioma;
            usuario.DVH = GestorDV.CalcularDVH(usuario);

            mapper.ActualizarIdiomaUsuario(usuario);

            ActualizarDvvUsuarios();
            string responsable;

            if (Servicios.SESION.GetInstancia().usuactual != null)
            {
                responsable = Servicios.SESION.GetInstancia().usuactual.Usuario;
            }
            else
            {
                responsable = "SISTEMA";
            }
            gestorHistorial.RegistrarCambio(usuario.Id, responsable, "CAMBIO_IDIOMA");

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
                Auditoria.AuditarSistema();

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
            usuariovalido.Permisos = gestorPermisos.ObtenerPermisosUsuario(usuariovalido.Id);
            SESION.GetInstancia().AsignarUsuario(usuariovalido);

            Auditoria.AuditarSistema();

            if (usuariovalido.IntentosFallidos > 0)
            {
                usuariovalido.IntentosFallidos = 0;
                usuariovalido.DVH = GestorDV.CalcularDVH(usuariovalido);

                mapper.ActualizarIntentosFallidos(usuariovalido);
                ActualizarDvvUsuarios();
            }

            gestorBitacora.RegistrarEvento("Seguridad", "Inicio de sesión exitoso", 1);

        }

        public void ActualizarDvvUsuarios()
        {
            List<string> todosDvh = mapper.ObtenerTodosLosDVH();
            GestorDV.RecalcularYGuardarDVV("USUARIO", todosDvh);
        }

        public void ActualizarSoloDVH(int idUsuario, string nuevoDvh)
        {
            mapper.ActualizarSoloDVH(idUsuario, nuevoDvh);
        }
    }
}
