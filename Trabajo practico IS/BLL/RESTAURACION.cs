using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RESTAURACION
    {
        MP_BACKUP MapperBackUp = new MP_BACKUP();
        BLL.USUARIO GestorUsuarios = new BLL.USUARIO();
        BLL.DIGITO_VERIFICADOR GestorDv = new BLL.DIGITO_VERIFICADOR();
        BLL.BITACORA GestorBitacora = new BLL.BITACORA();

        public void RestaurarBackup(string rutaArchivo)
        {
            MapperBackUp.RestaurarBaseDeDatos(rutaArchivo);
            GestorBitacora.RegistrarEvento("Administracion", "Restauración de base de datos desde archivo .bak", 1);
        }

        public void CrearBackup(string rutaDestino)
        {
            // Aquí podrías agregar lógica extra, como registrar en la Bitácora 
            // que el administrador acaba de exportar la base de datos.
            MapperBackUp.CrearBackup(rutaDestino);
            GestorBitacora.RegistrarEvento("Administracion", "Generación de Backup manual de la base de datos", 2);
        }

        public void RecalcularTodosLosDigitos()
        {
            // 1. Obtenemos todos los usuarios (y cualquier otra tabla que tengas protegida)
            List<BE.USUARIO> usuarios = GestorUsuarios.Listar();
            List<string> nuevosDvhs = new List<string>();

            // 2. Recalculamos el DVH para cada fila
            foreach (var usu in usuarios)
            {
                string nuevoDvh = GestorDv.CalcularDVH(usu);
                GestorUsuarios.ActualizarSoloDVH(usu.Id, nuevoDvh); // Requiere un UPDATE en SQL solo para el campo DVH
                nuevosDvhs.Add(nuevoDvh);
            }

            // 3. Con la lista de todos los nuevos DVHs, calculamos el DVV global de la tabla
            GestorDv.RecalcularYGuardarDVV("USUARIO", nuevosDvhs);

            GestorBitacora.RegistrarEvento("Seguridad", "Se recalcularon las firmas DVH y DVV de la tabla USUARIO (Operación de Emergencia)", 1);
        }
    }
}
