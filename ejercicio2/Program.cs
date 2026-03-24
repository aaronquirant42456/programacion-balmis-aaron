using System;
using System.Collections.Generic;

namespace Ejercicio2
{
    public class Principal
    {
        static void Pausa(string mensaje)
        {
            Console.Write($"\n{mensaje}\nPulsa una tecla...");
            Console.ReadKey();
            Console.Write("\n");
        }

        // TODO: Implementar el método CoincidenciasCadena_UsandoClausuras
        public static Func<List<string>, List<string>> CoincidenciasCadena_UsandoClausuras(List<string> lista) => (cadena) => lista.FindAll(item => item.Contains(cadena));
        // TODO: Implementar el método CoincidenciasCadena_SinUsarClausuras
        public static List<string> CoincidenciasCadena_SinUsarClausuras(List<string> lista, string cadenaABuscar) => lista.FindAll(cadena => cadena.Contains(cadenaABuscar));
        public static void Main()
        {
            List<String> lista = new List<String>() { "rosa", "mesa", "flor", "ventana", "blanco", "perro", "sillón", "azul", "melón" };

            Console.WriteLine("Ejercicio 2.  Coincidencia en lista de cadenas\n");
            Console.Write("Lista: ");
            lista.ForEach(x => Console.Write($"{x} "));

            Console.Write("\nIntroduce una cadena a buscar: ");
            string cadena = Console.ReadLine();

            Pausa($"Buscar coincidencias de {cadena} - Usando Clausuras");
            var busquedaClausura = CoincidenciasCadena_UsandoClausuras(lista);
            //TODO: Llamar al método CoincidenciasCadena_UsandoClausuras
            foreach (var texto in busquedaClausura(cadena))
                Console.Write($"{texto} ");

            Pausa($"Buscar coincidencias de {cadena} - Sin usar Clausuras");
            //TODO: Llamar al método CoincidenciasCadena_SinUsarClausuras con Foreach para mostrar los resultados
            var busquedaSinClausura = CoincidenciasCadena_SinUsarClausuras(lista, cadena);
            foreach (var texto in busquedaSinClausura)
            {
                Console.WriteLine(texto);
            }
            Pausa("");
        }
    }
}