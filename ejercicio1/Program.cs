
using System;
using System.Net.WebSockets;

namespace Ejercicio1
{
	//TODO: Crea las clases necesarias para implementar el enunciado del ejercicio
	public class Program
	{
		public static void GestionHerramientas()
		{
			Console.WriteLine("Creando herramientas ....");
			Console.WriteLine();

			Herramienta m = new Herramienta(Guid.NewGuid(), "Martillo", "Stanley", 0.5, 25);
			Console.WriteLine(m.ToString());
			Taladro t = new Taladro(Guid.NewGuid(), "Taladro Percutor", "Bosch", 2.3, 89.25, 750, 3000);
			Console.WriteLine(t.ToString());
		}

		static void Main(string[] args)
		{
			GestionHerramientas();
			Console.WriteLine("\nPresiona cualquier tecla para salir...");
			Console.ReadKey();
		}

		//TODO: Implementa el método GestionHerramientas
	}

	
}