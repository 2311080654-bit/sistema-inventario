using System;

/// <summary>
/// Representa un producto disponible en el inventario.
/// </summary>
public class Producto
{
    public string Codigo { get; }
    public string Nombre { get; }
    public decimal Precio { get; }
    public int Existencia { get; }

    public Producto(string codigo, string nombre, decimal precio, int existencia)
    {
        if (string.IsNullOrWhiteSpace(codigo))
        {
            throw new ArgumentException("El código del producto es obligatorio.", nameof(codigo));
        }

        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ArgumentException("El nombre del producto es obligatorio.", nameof(nombre));
        }

        if (precio < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(precio), "El precio no puede ser negativo.");
        }

        if (existencia < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(existencia), "La existencia no puede ser negativa.");
        }

        Codigo = codigo;
        Nombre = nombre;
        Precio = precio;
        Existencia = existencia;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Código: {Codigo}");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Precio: {Precio:F2}");
        Console.WriteLine("Producto registrado");
    }
}
