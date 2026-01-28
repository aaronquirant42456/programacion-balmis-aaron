using System.Runtime.CompilerServices;
namespace Ejercicio2;

public class Local
{
    public string Ciudad { get; }
    public string Calle { get; }
    public string NumeroPlantas { get; }
    public Dimension Dimensiones { get; }

    public Local(string ciudad, string calle, string numeroPlantas, float ancho, float largo)
    {
        Ciudad = ciudad;
        Calle = calle;
        NumeroPlantas = numeroPlantas;
        Dimensiones = new Dimension(ancho,largo);
    }

    //   Local:
    //   Ciudad: Alicante
    //   Calle: Calle de las Setas
    //   Número de plantas: 1
    //   Dimensiones: 500 m²
    public virtual string ACadena()
    {
        return $"""
                Local:
                Ciudad: {Ciudad}
                Calle: {Calle}
                Número de plantas: {NumeroPlantas}
                Dimensiones: {Dimensiones} m²
                """;
    }
}