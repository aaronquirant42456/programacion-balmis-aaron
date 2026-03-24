public class TemperaturasXProvincia
{
    public string Provincia { get; }
    public float TemperaturaMaxima { get; }
    public float TemperaturaMinima { get; }
    public TemperaturasXProvincia(string provincia, 
                float temperaturaMaxima, 
                float temperaturaMinima)
    {
        Provincia = provincia;
        TemperaturaMaxima = temperaturaMaxima;
        TemperaturaMinima = temperaturaMinima;
    }
    override public string ToString()
    {
        return $"Provincia: {Provincia} - Temperatura máxima:" +
               $"{TemperaturaMaxima}ºC - Temperatura mínima: {TemperaturaMinima}ºC.";
    }
}