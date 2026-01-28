namespace Ejercicio2;

public class LocalComercial : Local
{
    public string RazonSocial { get; }
    public string NumeroLicencia { get; }

    public LocalComercial(string ciudad, string calle, string numeroPlantas, float ancho, float largo, string razonSocial, string numeroLicencia) : base(ciudad, calle, numeroPlantas, ancho, largo)
    {
        RazonSocial = razonSocial;
        NumeroLicencia = numeroLicencia;
    }
    public override string ToString()
    {
        return $"""
                Local comercial:
                  Razón social: {RazonSocial}
                  Número de licencia: {NumeroLicencia}
                """;
    }
}