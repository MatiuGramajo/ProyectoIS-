using DAL;
using Servicios.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AUDITORIA
    {
        MP_USUARIO MapperUsuarios = new MP_USUARIO();
        MP_DIGITO_VERIFICADOR MapperDV = new MP_DIGITO_VERIFICADOR();
        BLL.DIGITO_VERIFICADOR GestorDV = new BLL.DIGITO_VERIFICADOR();

        public void AuditarSistema()
        {
            // 1. Traemos todos los usuarios tal cual están en la BD
            List<BE.USUARIO> todosLosUsuarios = MapperUsuarios.Listar();
            List<string> dvhsCalculados = new List<string>();

            // --- PASO 1: Validar el Dígito Verificador Horizontal (DVH) ---
            foreach (var usuario in todosLosUsuarios)
            {
                // Recalculamos la firma en memoria con los datos crudos
                string dvhCalculado = GestorDV.CalcularDVH(usuario);

                // Comparamos el cálculo con la firma guardada
                if (dvhCalculado != usuario.DVH)
                {
                    // ¡Falla detectada! Lanzamos la excepción personalizada
                    throw new IntegridadDatosException(
                        tabla: "USUARIO",
                        registro: $"ID: {usuario.Id} - Usuario: {usuario.Usuario}",
                        detalle: "Falla en DVH: Un campo de este registro fue modificado por fuera del sistema."
                    );
                }

                // Si el registro está íntegro, guardamos su DVH para el paso 2
                dvhsCalculados.Add(dvhCalculado);
            }

            // --- PASO 2: Validar el Dígito Verificador Vertical (DVV) ---
            // Usamos la lista de DVHs sanos para calcular la firma global
            string dvvCalculado = GestorDV.CalcularDVV(dvhsCalculados);

            // Traemos el DVV original desde la tabla DIGITO_VERIFICADOR
            string dvvBaseDatos = MapperDV.ObtenerDVV("USUARIO");

            if (dvvCalculado != dvvBaseDatos)
            {
                // ¡Falla detectada! Falta o sobra un registro
                throw new IntegridadDatosException(
                    tabla: "USUARIO",
                    registro: "Múltiples / Tabla Completa",
                    detalle: "Falla en DVV: Se detectó la inserción o eliminación de registros directamente en SQL Server."
                );
            }
        }
    }
}
