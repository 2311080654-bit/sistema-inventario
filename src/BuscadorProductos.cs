using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaInventario
{
    public class BuscadorProductos
    {
        public Producto? BuscarPorCodigo(IEnumerable<Producto> productos, string codigo)
        {
            if (productos == null || string.IsNullOrWhiteSpace(codigo))
                return null;

            return productos.FirstOrDefault(p =>
                string.Equals(p.Codigo, codigo, StringComparison.OrdinalIgnoreCase));
        }

        public List<Producto> BuscarPorNombre(IEnumerable<Producto> productos, string nombre)
        {
            if (productos == null || string.IsNullOrWhiteSpace(nombre))
                return new List<Producto>();

            return productos
                .Where(p => p.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}