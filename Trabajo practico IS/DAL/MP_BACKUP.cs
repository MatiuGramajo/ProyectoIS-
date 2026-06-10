using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_BACKUP
    {
        public void RestaurarBaseDeDatos(string rutaBackup)
        {
            // OJO: Nos conectamos a 'master', NO a 'BASE'
            string connectionStringMaster = "Initial Catalog=master;Data Source=.;Integrated Security=SSPI";

            using (SqlConnection conexionMaster = new SqlConnection(connectionStringMaster))
            {
                conexionMaster.Open();

                // 1. SINGLE_USER expulsa a cualquiera conectado (incluyendo tu propia app si quedó un hilo colgado)
                // 2. RESTORE pisa los datos.
                // 3. MULTI_USER la vuelve a habilitar.
                string queryRestore = @"
                    ALTER DATABASE [BASE] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                    RESTORE DATABASE [BASE] FROM DISK = @ruta WITH REPLACE;
                    ALTER DATABASE [BASE] SET MULTI_USER;";

                using (SqlCommand cmd = new SqlCommand(queryRestore, conexionMaster))
                {
                    cmd.Parameters.AddWithValue("@ruta", rutaBackup);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CrearBackup(string rutaDestino)
        {
            // Al igual que con el Restore, es buena práctica conectarse a master 
            // para tareas administrativas que involucran la base completa.
            string connectionStringMaster = "Initial Catalog=master;Data Source=.;Integrated Security=SSPI";

            using (SqlConnection conexionMaster = new SqlConnection(connectionStringMaster))
            {
                conexionMaster.Open();

                // El comando BACKUP DATABASE. [BASE] es el nombre de tu base de datos.
                string queryBackup = @"BACKUP DATABASE [BASE] TO DISK = @ruta WITH FORMAT, MEDIANAME = 'SQLServerBackups', NAME = 'Copia de seguridad completa de BASE';";

                using (SqlCommand cmd = new SqlCommand(queryBackup, conexionMaster))
                {
                    cmd.Parameters.AddWithValue("@ruta", rutaDestino);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
