using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Ejercicio
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Ejercicio 2.  Coincidencia en lista de cadenas");

            List<double> reales = new List<double> { 0.5, 1.6, 2.8, 3.9, 4.1, 5.2, 6.3, 7.4, 8.1, 9.2 };

            string texto = "Elementos: ";
            reales.ForEach(n => texto = $"{texto} {n}");
            Console.WriteLine(texto);

            int cuentaParteDecimalMenorA05 = CuentaParteDecimalMenorA05(reales);
            Console.Write($"\nNúmero elementos con parte decimal < 0,5 = {cuentaParteDecimalMenorA05}\n");

            double sumaElemParteEnteraMultiploDe3 = SumaElemParteEnteraMultiploDe3(reales);
            Console.Write($"\nSuma elementos con parte entera múltiplo de 3 = {sumaElemParteEnteraMultiploDe3}\n");

            double maximoCuyaParteDecimalMayorA05 = MaximoCuyaParteDecimalMayorA05(reales);
            Console.Write($"\nMáximo cuya parte decimal > 0,5 = {maximoCuyaParteDecimalMayorA05}\n");

            texto = "Elementos parte entera es primo: ";
            List<double> primos = ElementosParteEnteraEsPrimo(reales);
            primos.ForEach(n => texto = $"{texto} {n}");
            Console.WriteLine(texto);
            Console.WriteLine("Pulsa una tecla para finalizar...");
            Console.ReadKey();
        }

        public static int CuentaParteDecimalMenorA05(List<double> reales) => reales
            .Select(real => Math.Floor(real) - real)
            .Where(real => real < 0.5)
            .Aggregate(0, (contador, valor) => (int)(contador + valor));

        public static double SumaElemParteEnteraMultiploDe3(List<double> reales) => reales
            .Select(real => new {e = Math.Floor(real), r = real})
            .Where(real => real.e % 3 == 0)
            .Aggregate(0, (contador, real) => (int)(contador + real.r));

        public static double MaximoCuyaParteDecimalMayorA05(List<double> reales) => 
        reales
            .Select(real => new {d = Math.Floor(real) - real, r = real})
            .Where(real => real.d > 0.5)
            .Max(real => real.r);

        public static List<double> ElementosParteEnteraEsPrimo(List<double> reales) => 
        reales
            .Select(real => new {e = (int)Math.Floor(real), r = real})
            .Where(real => real.e > 1)
            .Where(real => !Enumerable.Range(2, real.e - 2)
                .Any(n => real.e % n == 0))
            .Select(real => real.r)
            .ToList();
    }
}

