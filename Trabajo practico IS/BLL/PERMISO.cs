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

        public void Modificar(BE.COMPONENTE componente)
        {
            mapperPermiso.Modificar(componente);
        }

        public void Baja(BE.COMPONENTE componente)
        {
            // 1. REGLA DE NEGOCIO: ¿Es una hoja? (No permitimos borrar permisos base)
            if (!componente.EsCompuesto)
            {
                throw new Exception("Por seguridad del sistema, no se pueden eliminar las acciones base, solo los roles.");
            }

            // 2. REGLA DE NEGOCIO: ¿El rol está siendo usado por algún usuario?
            if (mapperPermiso.ValidarRolEnUso(componente.Id))
            {
                // ¡El control lo hace el programa! Lanzamos la excepción en C#
                throw new Exception("Acción denegada: Hay usuarios que tienen este rol asignado. Desvincule a los usuarios primero.");
            }

            mapperPermiso.Baja(componente);
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
                if (ExisteReferenciaCircular(padre.Id, hijo.Id))
                {
                    throw new Exception("Acción denegada: Asignar este rol generaría una referencia circular infinita.");
                }
                padre.AgregarHijo(hijo);
                
                mapperPermiso.GuardarRelacion(padre.Id, hijo.Id);

            }
            catch(Exception ex)
            {
                throw;
            }
            
        }

        private bool ExisteReferenciaCircular(int idPadreDestino, int idHijoAAgregar)
        {
            // Obtenemos la tabla cruda de relaciones de la BD
            DataTable tablaRelaciones = mapperPermiso.ObtenerTablaRelacionesAuxiliar();

            // Iniciamos la búsqueda recursiva: ¿Está el Padre metido en algún lugar adentro del Hijo?
            return BuscarCicloRecursivo(idHijoAAgregar, idPadreDestino, tablaRelaciones);
        }

        // Método recursivo privado que navega la tabla de relaciones
        private bool BuscarCicloRecursivo(int idActual, int idBuscado, DataTable relaciones)
        {
            // Filtramos los hijos directos del nodo actual (Fijate de usar el nombre exacto de tu columna, ej: "Id_Padre")
            var hijos = from DataRow fila in relaciones.Rows
                        where int.Parse(fila["Id_Padre"].ToString()) == idActual
                        select int.Parse(fila["Id_Hijo"].ToString());

            foreach (int idHijo in hijos)
            {
                // Si el hijo es exactamente el padre que queremos asignar... ¡Encontramos un bucle!
                if (idHijo == idBuscado)
                {
                    return true;
                }

                // Si no es, seguimos bajando un nivel más en el árbol
                if (BuscarCicloRecursivo(idHijo, idBuscado, relaciones))
                {
                    return true;
                }
            }

            return false;
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

        public List<BE.COMPONENTE> ObtenerPermisosUsuario(int idUsuario)
        {
            // 1. Armamos el árbol completo en memoria (usando tu método existente)
            List<BE.COMPONENTE> rootNodes = ObtenerArbolCompleto();

            // Como ObtenerArbolCompleto solo devuelve raíces, para poder buscar libremente 
            // nos conviene listar todos los componentes planos primero.
            List<BE.COMPONENTE> todosLosPermisosPlanos = mapperPermiso.Listar();
            // Volvemos a armar los enlaces para la lista plana temporal rápida
            // (O podés modificar tu BLL para tener una lista de "todos" accesible).

            // 2. Traemos los IDs que tiene asignados el usuario
            List<int> idsAsignados = mapperPermiso.ObtenerIdsPermisosUsuario(idUsuario);

            List<BE.COMPONENTE> permisosDelUsuario = new List<BE.COMPONENTE>();

            // 3. Buscamos los objetos reales correspondientes a esos IDs
            // Nota: Es crucial usar la misma instancia de objetos que ya fue enlazada en el árbol
            // para conservar las referencias en memoria.
            List<BE.COMPONENTE> arbolHidratadoCompleto = mapperPermiso.Listar();
            // Para simplificar y asegurar que tengan sus hijos enlazados, podemos re-utilizar la lógica 
            // de armado sobre la lista completa de la BD:
            DataTable tablaRelaciones = mapperPermiso.ObtenerTablaRelacionesAuxiliar();
            foreach (var nodo in arbolHidratadoCompleto)
            {
                var filasHijos = from DataRow fila in tablaRelaciones.Rows
                                 where int.Parse(fila["Id_Padre"].ToString()) == nodo.Id
                                 select fila;
                foreach (DataRow fila in filasHijos)
                {
                    int idHijo = int.Parse(fila["Id_Hijo"].ToString());
                    BE.COMPONENTE hijo = arbolHidratadoCompleto.Find(p => p.Id == idHijo);
                    if (hijo != null) { try { nodo.AgregarHijo(hijo); } catch { } }
                }
            }

            foreach (int id in idsAsignados)
            {
                BE.COMPONENTE componenteEncontrado = arbolHidratadoCompleto.Find(p => p.Id == id);
                if (componenteEncontrado != null)
                {
                    permisosDelUsuario.Add(componenteEncontrado);
                }
            }

            return permisosDelUsuario;
        }
    }
}
