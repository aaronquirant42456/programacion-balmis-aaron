using System.Diagnostics.Contracts;
using System.Formats.Asn1;
using System.Text.RegularExpressions;

internal class Program
{

    private static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 5. Recursividad con Lambdas\n");

        Func<int, int> sumatorio = default!;
        Func<int, int> sumaDigitos = default!;
        Func<string, int> cuentaVocales = default!;

        Console.Write("Sumatorio de 1 a \"5\":");
        sumatorio = n => n == 0 ? 0 : n + sumatorio!(n - 1);
        Console.WriteLine(sumatorio(5));

        Console.Write("Suma de dígitos del número \"543\":");
        sumaDigitos = n => n < 10 ? n : n % 10 + sumaDigitos(n / 10);
        Console.WriteLine(sumaDigitos(543));
        
        Console.Write("Cuenta de vocales en la cadena \"Hola MUNDO\":");
        cuentaVocales = c => c.Length <= 0 ? 0 : ("aeiou".Contains(char.ToLower(c[0])) ? 1 : 0) + cuentaVocales(c[1..]); // jaja
        Console.WriteLine(cuentaVocales("Hola MUNDO"));

        Console.ReadLine();

    }
}