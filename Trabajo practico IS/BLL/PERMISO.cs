using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PERMISO
    {
        DAL.MP_PERMISO mapperPermiso = new DAL.MP_PERMISO();

        public void GuardarComponente(BE.COMPONENTE componente)
        {
            mapperPermiso.Alta(componente);
        }
        public void GuardarRelacion(BE.COMPONENTE padre, BE.COMPONENTE hijo)
        {
            try
            {
                if (padre.Id == hijo.Id)
                {
                    throw new Exception("Un componente no puede ser hijo de sí mismo.");
                }
                if (padre.TienePermiso(hijo.Nombre))
                {
                    throw new Exception("Este componente ya existe dentro del rol");
                }

                padre.AgregarHijo(hijo);
                
                mapperPermiso.GuardarRelacion(padre.Id, hijo.Id);

            }
            catch(Exception ex)
            {
                throw;
            }
            
        }

        public void BorrarRelacion(BE.COMPONENTE padre, BE.COMPONENTE hijo)
        {
            try
            {
                // Opcional, pero buena práctica: Lo removemos en memoria usando el método que armamos antes
                padre.BorrarHijo(hijo);

                // Lo borramos de la base de datos
                mapperPermiso.BorrarRelacion(padre.Id, hijo.Id);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        

        public List<BE.COMPONENTE> Listar()
        {
            return mapperPermiso.Listar();
        }

        public List<BE.COMPONENTE> ObtenerArbolCompleto()
        {
            // Paso A: Traemos TODOS los permisos planos (Lego desarmados) desde el Mapper
            List<BE.COMPONENTE> todosLosPermisos = mapperPermiso.Listar();

            // Paso B: Traemos la tabla puente completa que dice quién es hijo de quién
            // (Asumimos que tu clase de acceso a datos DAL tiene una forma de leer esta tabla, 
            // abajo te muestro cómo procesarla mediante un DataTable auxiliar rápido)
            DataTable tablaRelaciones = mapperPermiso.ObtenerTablaRelacionesAuxiliar();
            foreach (var nodo in todosLosPermisos)
            {
                // Buscamos si este nodo (sea el que sea) tiene hijos en la base de datos
                var filasHijos = from DataRow fila in tablaRelaciones.Rows
                                 where int.Parse(fila["Id_Padre"].ToString()) == nodo.Id
                                 select fila;

                // Si es un Permiso Simple, 'filasHijos' estará vacío y este foreach ni se ejecuta.
                // Si es un Permiso Compuesto, entrará al foreach y agregará a sus hijos.
                foreach (DataRow fila in filasHijos)
                {
                    int idHijo = int.Parse(fila["Id_Hijo"].ToString());

                    BE.COMPONENTE hijoEncontrado = (from p in todosLosPermisos
                                                    where p.Id == idHijo
                                                    select p).FirstOrDefault();

                    if (hijoEncontrado != null)
                    {
                        // ACÁ ESTÁ EL POLIMORFISMO PURO:
                        // Le decimos "Agregá un hijo" a ciegas. El propio objeto sabe cómo hacerlo.
                        nodo.AgregarHijo(hijoEncontrado);
                    }
                }
            }

            // Paso D: Devolvemos las raíces (También quitamos el 'is' de aquí)
            List<BE.COMPONENTE> raices = new List<BE.COMPONENTE>();
            foreach (var p in todosLosPermisos)
            {
                bool esHijoDeAlguien = (from DataRow fila in tablaRelaciones.Rows
                                        where int.Parse(fila["Id_Hijo"].ToString()) == p.Id
                                        select fila).Any();

                // Si no es hijo de nadie, es una raíz (no nos importa si es simple o compuesto)
                if (!esHijoDeAlguien)
                {
                    raices.Add(p);
                }
            }

            return raices;

        }
    }
}
