
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ejercicio2
{
	//TODO: Crea las clases necesarias para implementar el código que se pide en los ejercicios
	public class Program
	{
		public static void GestionCines()
		{
			List<Cine> cines;

			Console.WriteLine("=== Creando y mostrando cines ===");
			Console.WriteLine();
			Cine c1 = new Cine("Alicante", "Calle de las Setas", "1", 25, 25, "Cinesa", "12345", 200);	
			Cine c2 = new Cine("Madrid", "Gran vía", "3", 40, 40, "Yelmo Cines", "67890", 350);
			Cine c3 = new Cine("Valencia", "Plaza del Ayuntamiento", "2", 25, 25, "Kinépolis", "54321", 450);

			Console.WriteLine("--- Cine 1 ---");
			Console.WriteLine(c1.ACadena());
			Console.WriteLine();

			Console.WriteLine("--- Cine 2 ---");			
			Console.WriteLine(c2.ACadena());
			Console.WriteLine();
			
			Console.WriteLine("--- Cine 3 ---");
			Console.WriteLine(c3.ACadena());
			Console.WriteLine();
		}

		static void Main(string[] args)
		{
			GestionCines();
			Console.WriteLine("\nPresiona cualquier tecla para salir...");
			Console.ReadKey();
		}

		//TODO: Implementa el método GestionCines
	}
}

	  