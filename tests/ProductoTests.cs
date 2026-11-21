using System;
using System.IO;
using Xunit;

public class ProductoTests
{
    private static string CapturarSalida(Producto producto)
    {
        var salidaOriginal = Console.Out;
        using var sw = new StringWriter();
        Console.SetOut(sw);
        try
        {
            producto.MostrarInformacion();
            return sw.ToString();
        }
        finally
        {
            Console.SetOut(salidaOriginal);
        }
    }

    [Fact]
    public void CP01_CrearProductoConDatosSolicitados()
    {
        var producto = new Producto("P001", "Teclado", 350m, 10);

        Assert.Equal("P001", producto.Codigo);
        Assert.Equal("Teclado", producto.Nombre);
        Assert.Equal(350m, producto.Precio);
        Assert.Equal(10, producto.Existencia);
    }

    [Fact]
    public void CP02_MostrarCodigoProducto()
    {
        var producto = new Producto("P001", "Teclado", 350m, 10);
        string salida = CapturarSalida(producto);

        Assert.Contains("P001", salida);
    }

    [Fact]
    public void CP03_MostrarNombreProducto()
    {
        var producto = new Producto("P001", "Teclado", 350m, 10);
        string salida = CapturarSalida(producto);

        Assert.Contains("Teclado", salida);
    }

    [Fact]
    public void CP04_MostrarPrecioProducto()
    {
        var producto = new Producto("P001", "Teclado", 350m, 10);
        string salida = CapturarSalida(producto);

        Assert.Contains("350", salida);
    }

    [Fact]
    public void CP05_MostrarExistenciaProducto()
    {
        var producto = new Producto("P001", "Teclado", 350m, 10);
        string salida = CapturarSalida(producto);

        Assert.Contains("10", salida);
    }

    [Fact]
    public void CP06_MostrarInformacionCompleta()
    {
        var producto = new Producto("P001", "Teclado", 350m, 10);
        string salida = CapturarSalida(producto);

        Assert.Contains("P001", salida);
        Assert.Contains("Teclado", salida);
        Assert.Contains("350", salida);
        Assert.Contains("10", salida);
    }

    [Fact]
    public void CP07_CrearSegundoProductoSinConfundirDatos()
    {
        var primero = new Producto("P001", "Teclado", 350m, 10);
        var segundo = new Producto("P002", "Mouse", 180m, 5);

        Assert.Equal("P002", segundo.Codigo);
        Assert.Equal("Mouse", segundo.Nombre);
        Assert.Equal(180m, segundo.Precio);
        Assert.Equal(5, segundo.Existencia);

        Assert.NotEqual(primero.Codigo, segundo.Codigo);
        Assert.NotEqual(primero.Nombre, segundo.Nombre);
        Assert.NotEqual(primero.Precio, segundo.Precio);
        Assert.NotEqual(primero.Existencia, segundo.Existencia);
    }
}