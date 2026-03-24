using System;

namespace Ejercicio5
{
    public class Principal
    {
        public delegate void Action();

        public static int Suma(int n1, int n2) => n1 + n2;
        public static int CuadradoDe(int number) => number * number;
        public static double GetVelocidadParada() => 108.4;
        public static bool EsMultiploDeCinco(int n) => n % 5 == 0;
        public static double Calcula(string tipo, string nom1, string nom2)
        {
            Console.WriteLine($"Introduce {nom1}");
            string temp1 = Console.ReadLine();
            int var1 = Int32.Parse(temp1);
            Console.WriteLine($"Introduce {nom2}");
            string temp2 = Console.ReadLine();
            int var2 = Int32.Parse(temp2);
            return tipo == "Potencia" ? var1 * var2 : var1 / var2;
        }
        public static string ProcedimientoDesconocido(double[] x, int[] y, string z)
        {
            if (x.Length == y.Length)
            {
                int p = 0;
                foreach (double c in x)
                {
                    z += (c + y[p]);
                    z += " ";
                    p++;
                }
            }
            return z;
        }
        static void Main()
        {
            Console.WriteLine("Ejercicio 5. Practicando con delegados predefinidos");
            //TODO: Define el código necesario para el ejercicio

            Func<int, int, int> funcSuma = Suma;
            Console.WriteLine("Suma: " + funcSuma(15,2));

            Func<int, int> funcCuadrado = CuadradoDe;
            Console.WriteLine("Cuadrado: " + funcCuadrado(15));

            Console.WriteLine("Velocidad: " + GetVelocidadParada());

            Func<int, bool> funcMultiplo = EsMultiploDeCinco;
            Console.WriteLine("Es multiplo: " + funcMultiplo(5));

            double[] x = {1.10,2.25,3.45,4.67};
            int[] y = {1,2,3,4};
            string z = "12";
            Console.WriteLine("Procedimiento: " + ProcedimientoDesconocido(x,y,z));
;
            Func<string, string, string, double> funcCalcula = Calcula;
            Console.WriteLine("Calcula: " + funcCalcula("Potencia", "1", "2"));

            Console.WriteLine("Pulsa una tecla para continuar...");
            Console.ReadKey(true);
        }
    }
}
