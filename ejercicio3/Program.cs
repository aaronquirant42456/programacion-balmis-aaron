using System;

namespace Ejercicio3
{
    public class Principal
    {
        //TODO: Define el código necesario para el ejercicio 
        public delegate bool Delegado<T>(T p);
        public static void Mostrar<T>(T[][] array)
        {
            foreach(var ar in array)
            {
                foreach(var a in ar)
                    Console.Write($"{a, 7}");
                Console.WriteLine();
                // Console.Write($"{ar, 5}");
            }
        }
        public static void Main()
        {
            float[][] mNumeros = new float[][] { new float[] { 3, 4, 5 }, new float[] { 2.4f, 4.4f, 5 } };
            String[][] mPalabras = new String[][] { new String[] { "SAL", "AGUA", "AZUCAR", "VINO" }, new String[] { "COLA", "CAFE", "ZUMO", "LECHE" } };

            Console.WriteLine("Ejercicio 3. Delegado genérico Comparador\n");


            Action<float[][]> Numeros = Mostrar;
            Action<string[][]> Palabras = Mostrar;
            
            Palabras(mPalabras);
            Console.WriteLine();
            Numeros(mNumeros);

            //TODO: Define el código necesario para el ejercicio
            Console.WriteLine("Pulsar una tecla para finalizar...");
            Console.ReadKey(true);

        }
    }
}
