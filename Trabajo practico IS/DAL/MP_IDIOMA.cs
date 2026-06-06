using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_IDIOMA : MAPPER<BE.IDIOMA>
    {
        public override void Alta(IDIOMA obj)
        {
            throw new NotImplementedException();
        }

        public override void Baja(IDIOMA obj)
        {
            throw new NotImplementedException();
        }

        public override List<BE.IDIOMA> Listar()
        {
            acceso.Abrir();
            DataTable tabla = acceso.Leer("LISTAR_IDIOMAS");
            acceso.Cerrar();
            List<BE.IDIOMA> idiomas=new List<BE.IDIOMA>();
            foreach(DataRow registro in tabla.Rows)
            {
                BE.IDIOMA idio=new BE.IDIOMA();
                idio.Id = int.Parse(registro["id_idioma"].ToString());
                idio.Nombre = registro["nombre"].ToString();
                idio.EstaDisponible = bool.Parse(registro["estadisponible"].ToString());
                idiomas.Add(idio);
            }
            return idiomas;
        }

        public Dictionary<string, string> ObtenerTraducciones(int idIdioma)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id_idioma", idIdioma));
            DataTable tabla = acceso.Leer("OBTENER TRADUCCIONES", parametros);
            acceso.Cerrar();
            Dictionary<string, string> diccionario = new Dictionary<string, string>();
            foreach (DataRow fila in tabla.Rows)
            {
                string form = fila["nombre_formulario"].ToString();
                string control = fila["nombre_control"].ToString();
                string texto = fila["texto_traducido"].ToString();

                // Armamos la clave combinada tal como charlamos: "NombreFormulario_NombreControl"
                string clave = $"{form}_{control}";

                if (!diccionario.ContainsKey(clave))
                {
                    diccionario.Add(clave, texto);
                }
            }
            return diccionario;
        }

        public override void Modificar(IDIOMA obj)
        {
            throw new NotImplementedException();
        }

        public override bool Verificar(IDIOMA obj)
        {
            throw new NotImplementedException();
        }
    }
}
