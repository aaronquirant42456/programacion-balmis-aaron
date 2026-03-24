 using System;
using System.Collections.Generic;
using System.Transactions;

namespace Ejercicio3
{
    public class Principal
    {
        static void Pausa(string mensaje)
        {
            Console.Write($"\n{mensaje}\nPulsa una tecla...");
            Console.ReadKey();
            Console.Write("\n");
        }

        //TODO: Implementar el método EsMultiploDe_ConClausura
        /*
        public static Func<int, List<int>> EsMultiploDe_ConClausura(List<int > lista) => (x) => lista.Where(y => y % x == 0).ToList();
        */
        public static Func<List<int>, List<int>> EsMultiploDe_ConClausura(int entero) => (lista) => lista.Where(y => y % entero == 0).ToList();
        // TODO: Implementar el método EsMultiploDe_SinClausura
        // public delegate List<int> Multiplos(List<int> lista, int numero);
        public static List<int> EsMultiploDe_SinClausura(List<int> lista, int numero) => lista.Where(n => n % numero == 0).ToList(); // el where devuelve un IEnumerable que se puede convertir en array o lista
        // {
        //     List<int> multiplos = new();
        //     lista.ForEach(n =>
        //     {
        //         if(n % numero == 0) multiplos.Add(n);
        //     });
        //     return multiplos;
        // }
        public static void Main()
        {
            List<int> lista = new List<int>() { 2, 4, 12, 3, 18, 4, 7, 6, 21, 33, 17, 30, 27 };

            Console.WriteLine("Ejercicio 3.  Múltiplos en lista de números\n");
            Console.Write("Lista: ");
            lista.ForEach(x => Console.Write($"{x} "));

            Console.Write("\nIntroduce un número: ");
            int n = int.Parse(Console.ReadLine());

            Pausa($"Múltiplos de {n} - Usando Clausuras");
            // foreach (int x in lista)
            // {
            //     var check = EsMultiploDe_ConClausura(x);
            //     Console.Write(check(n) ? $"{x} " : "");
            // }
            var multiplos = EsMultiploDe_ConClausura(n);
            Console.WriteLine(string.Join(" - ", multiplos(lista)));

            Pausa($"Múltiplos de {n} - Sin usar Clausuras");
            // lista.ForEach(x => Console.Write((EsMultiploDe_SinClausura(x, n) ? $"{x} " : "")));
            var multiplo2 = EsMultiploDe_SinClausura(lista, n);
            Console.WriteLine(string.Join(" - ", multiplo2));

            Pausa("");
        }
    }
}