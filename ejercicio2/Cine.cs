namespace Ejercicio2;
public class Cine : LocalComercial

{
    public int AforoSala { get; }

    public Cine(string ciudad, string calle, string numeroPlantas, float ancho, float largo, string razonSocial, string numeroLicencia, int aforoSala) : base(ciudad, calle, numeroPlantas, ancho, largo, razonSocial, numeroLicencia)
    {
        AforoSala = aforoSala;
    }

    public string ACadena()
    {
        return $"""
                Local:
                  Ciudad: {Ciudad}
                  Calle: {Calle}
                  Número de plantas: {NumeroPlantas}
                  Dimensiones: {Dimensiones} m²
                Local comercial:
                  Razón social: {RazonSocial}
                  Número de licencia: {NumeroLicencia}
                Cine:
                  Aforo de la sala: {AforoSala} personas
                """;
    }
}