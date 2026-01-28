using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;

public class Herramienta
{
    public Guid Id { get; }
    public string Nombre { get; }
    public string Marca { get; }
    public double Peso { get; }
    // en el padre es virtual, en el hijo es override
    public double PrecioBase { get; set; }
    public virtual double Precio => PrecioBase;

    public Herramienta(Guid id, string nombre, string marca, double peso, double precioBase)
    {
        Id = id;
        Nombre = nombre;
        Marca = marca;
        Peso = peso;
        PrecioBase = precioBase;
    }
    public virtual string Usa()
    {
        return "Depende de la herramienta";
    }
    public override string ToString()
    {
        return $"""
                {Nombre}, Marca: {Marca}, Peso: {Peso}, Precio: {PrecioBase}
                """;
    }
}