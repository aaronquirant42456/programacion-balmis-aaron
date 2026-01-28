
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Ejercicio4
{
    //TODO: Implementa las clases necesarias para cumplimentar el ejercicio4
    public class Program
    {
        //TODO: Crea el método GestionHerramientasPolimorfismo
        public static void GestionHerramientasPolimorfismo()
        {
            List<Herramienta> inventario = new();
            {
                inventario.Add(new Herramienta(Guid.NewGuid(), "Martillo", "Stanley", 0.5, 25));
                inventario.Add(new Taladro(Guid.NewGuid(), "Taladro Percutor", "Bosch", 2.3, 105, 750, 3000));
                inventario.Add(new SierraElectrica(Guid.NewGuid(), "Sierra Circular", "Makita", 4.1, 120, 1400, 185));
                inventario.Add(new Lijadora(Guid.NewGuid(), "Lijadora Orbital", "Dewalt", 1.8, 53, 9000, 125));
            }

            Console.WriteLine("Creando inventario...");
            Console.WriteLine();

            foreach(Herramienta h in inventario)
                Console.WriteLine(h.ToString());
            
            Console.WriteLine();
            Console.WriteLine("Mostrando usos...");
            Console.WriteLine();

            foreach(Herramienta h in inventario)
                Console.WriteLine($"{h.Nombre}: {h.Usa()}");
            
            Console.WriteLine();
            Console.WriteLine("Accediendo a métodos específicos:");
            Console.WriteLine();

            foreach(Herramienta h in inventario)
            {
                switch(h)
                {
                    case Taladro t:
                        Console.WriteLine($"Taladro => {t.Perfora(8,60)}");
                        break;
                    case SierraElectrica s:
                        Console.WriteLine($"Sierra => {s.Corta("Madera", 18)}");
                        break;
                    case Lijadora l:
                        Console.WriteLine($"Lijadora => Pulir(2.5 m2) tarda {l.Pule(2.5):F2}s");
                        break;
                }
            }
        }
        
        static void Main(string[] args)
        {
            GestionHerramientasPolimorfismo();
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
