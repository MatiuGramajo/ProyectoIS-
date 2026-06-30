using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PRODUCTO
    {
        MP_PRODUCTO mapper = new MP_PRODUCTO();
        BLL.BITACORA GestorBitacora = new BLL.BITACORA();

        public void Insertar(BE.PRODUCTO producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new Exception("El nombre del producto no puede estar vacío.");

            if (producto.Precio <= 0)
                throw new Exception("El precio debe ser mayor a cero.");

            if (producto.Stock < 0)
                throw new Exception("El stock no puede ser negativo.");

            var todos = mapper.Listar();
            if (todos.Any(p => p.Nombre.Equals(producto.Nombre, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Ya existe un producto con ese nombre.");

            mapper.Alta(producto);

            GestorBitacora.RegistrarEvento("Inventario", $"Se dio de alta el producto {producto.Nombre}", 2);
        }

        public void Borrar(BE.PRODUCTO producto)
        {
            mapper.Baja(producto);
            GestorBitacora.RegistrarEvento("Inventario", $"Se dio de baja el producto {producto.Nombre}", 2);

        }

        public void Modificar(BE.PRODUCTO producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre))
            {
                throw new Exception("El nombre del producto no puede estar vacío.");
            }

            if (producto.Precio <= 0)
            {
                throw new Exception("El precio del producto debe ser mayor a cero.");
            }

            if (producto.Stock < 0)
            {
                throw new Exception("El stock no puede ser un número negativo.");
            }

            List<BE.PRODUCTO> todosLosProductos = mapper.Listar();

            bool nombreRepetido = todosLosProductos.Any(p => p.Id != producto.Id && p.Nombre.Equals(producto.Nombre, StringComparison.OrdinalIgnoreCase));

            if (nombreRepetido)
            {
                throw new Exception("Ya existe otro producto registrado con ese mismo nombre.");
            }

            mapper.Modificar(producto);
            GestorBitacora.RegistrarEvento("Inventario", $"Se modificó el producto {producto.Nombre}", 2);
        }

        public List<BE.PRODUCTO> Listar()
        {
            return mapper.Listar();
        }

    }
}
