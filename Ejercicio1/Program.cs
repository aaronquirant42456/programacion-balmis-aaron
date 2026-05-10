using System.Globalization;
using System.Runtime.CompilerServices;
using Spectre.Console;

public class Datos
{
    public string TimeStamp { get;set; }
    public double Temperatura { get;set; }
    public double Humedad { get;set; }
    public double VelocidadViento { get;set; }
    public double Direccion { get;set; }
}

internal class Program
{
    private static void Main(string[] args)
    {
        string ruta = "datos.csv";

        List<Datos> datos = new();
        var linea = File.ReadAllLines(ruta);

        for (int i = 1; i < linea.Length; i++)
        {
            var valor = linea[i].Split(',');

            datos.Add(new Datos
            {
                TimeStamp = FormatTimestamp(valor[0]),
                Temperatura = double.Parse(valor[1]),
                Humedad = double.Parse(valor[2]),
                VelocidadViento = double.Parse(valor[3]),
                Direccion = double.Parse(valor[4])
            });
        }   

        MostrarTabla(datos);
        MostrarTemperatura(datos);
        MostrarVelocidadViento(datos);
    }
    public static string FormatTimestamp(string timeStamp)
    {
        DateTime tiempo = DateTime.ParseExact(timeStamp, "yyyyMMdd'T'HHmm", CultureInfo.InvariantCulture); // ignora la regnion
        
        return tiempo.ToString("MM/dd/yyyy HH:mm");
    }
    public static void MostrarTabla(List<Datos> datos)
    {
        var tabla = new Table(); // crear la tabla

        tabla.Border(TableBorder.Rounded);

        // añadri las columnas de la tabla
        tabla.AddColumn("[blue]timestamp[/]"); // resalta el color de la palabra timestamp
        tabla.AddColumn("[blue]Temperatura[/]");
        tabla.AddColumn("[blue]Humedad[/]");
        tabla.AddColumn("[blue]VelocidadViento[/]");
        tabla.AddColumn("[blue]Dirección[/]");

        foreach(var d in datos)
        {
            tabla.AddRow(
                d.TimeStamp.ToString(),
                d.Temperatura.ToString(),
                d.Humedad.ToString(),
                d.VelocidadViento.ToString(),
                d.Direccion.ToString()
            );
        }
        // clase prinicpal de la libreria
        AnsiConsole.Write(tabla);
    }
    public static void MostrarTemperatura(List<Datos> datos)
    {
        AnsiConsole.WriteLine();
        // crear el garfico
        var garfico = new BarChart().Width(60)
                                    .Label("[green]Temperatura[/]")
                                    .CenterLabel(); // como css?
        foreach(var d in datos)
        {
            garfico.AddItem(
                d.TimeStamp,
                d.Temperatura, // si la temp es > 2 es amairllo sino es azul
                d.Temperatura >= 3 ? Color.Yellow : Color.Blue
            );
        }

        AnsiConsole.Write(garfico);
    }
    public static void MostrarVelocidadViento(List<Datos> datos)
    {
        AnsiConsole.WriteLine();

        var grafico = new BarChart().Width(60)
                                    .Label("[green]Velocidad VelocidadViento[/]")
                                    .CenterLabel();
        foreach(var d in datos)
        {
            Color color = 
                d.VelocidadViento < 20 ? Color.Green :
                d.VelocidadViento < 35 ? Color.Yellow :
                d.VelocidadViento < 45 ? Color.Orange1 :
                Color.Red;
            
            grafico.AddItem(
                d.TimeStamp,
                d.VelocidadViento,
                color
            );
        }

        AnsiConsole.Write(grafico);
    }
}