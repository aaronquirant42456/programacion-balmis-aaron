using Estadistica;

internal class Program
{
    private static void Main(string[] args)
    {
        double[] datos = {1,5,3,9,7,4,6};

        System.Console.WriteLine(String.Join(",", datos));

        System.Console.WriteLine("Media: " + Promedio.Media(datos));
        System.Console.WriteLine("Meidana: " + Promedio.Mediana(datos));

        double moda = default;
        bool existeModa = Promedio.Moda(datos, out moda);

        if(existeModa)
            System.Console.WriteLine("Moda: " + moda);
        else
            System.Console.WriteLine("Moda: no existe");
        
        System.Console.WriteLine("Rango: " + Promedio.Rango(datos));

    }
}