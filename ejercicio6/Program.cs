using System;

namespace Ejercicio6
{
    public class Program
    {
        public static bool IgualQue(float a, float b) => a == b;
        public static bool MayorQue(float a, float b) => a > b;
        public static bool MenorQue(float a, float b) => a < b;
        public static float ObtenMaxima(TemperaturasXProvincia p) => p.TemperaturaMaxima;
        public static float ObtenMinima(TemperaturasXProvincia p) => p.TemperaturaMinima;
        public static float MediaTemperaturas(TemperaturasXProvincia[] temperaturasPorProvincia, Func<TemperaturasXProvincia, float> obtenTemperatura)
        {
            float media = 0;
            for (int i = 0; i < temperaturasPorProvincia.Length; i++)
                media += obtenTemperatura(temperaturasPorProvincia[i]);

            return media / temperaturasPorProvincia.Length;
        }
        public static void MuestraProvincias(TemperaturasXProvincia[] temperaturasPorProvincia, float media, Func<TemperaturasXProvincia, float> obtenTemperatura, Func<float, float, bool> cumplePredicado)
        {
            foreach (var tempProv in temperaturasPorProvincia)
            {
                float temp = obtenTemperatura(tempProv);
                if (cumplePredicado(temp, media))
                    Console.WriteLine(tempProv.Provincia);
            }
        }
        static void Main()
        {
            Console.WriteLine("Ejercicio 6. Delegados genéricos con múltiples parámetros\n");

            // TODO: Define el código necesario para el ejercicio

            var temperaturas = new TemperaturasXProvincia[]
            {
                new TemperaturasXProvincia("Madrid", 35.2f, 15.3f),
                new TemperaturasXProvincia("Barcelona", 30.5f, 18.0f),
                new TemperaturasXProvincia("Valencia", 33.1f, 20.2f),
                new TemperaturasXProvincia("Sevilla", 38.0f, 22.1f),
                new TemperaturasXProvincia("Bilbao", 28.7f, 16.5f),
                new TemperaturasXProvincia("Zaragoza", 36.2f, 19.0f)
            };
            
            Console.WriteLine("Rcogiendo temperaturas de provuncias: ");
            foreach(var t in temperaturas)
                Console.WriteLine(t);
            Console.WriteLine();

            float mediaMax = MediaTemperaturas(temperaturas, ObtenMaxima);
            Console.WriteLine($"Provincias con temperatura máxima superior a la media ({mediaMax:F2}):");
            MuestraProvincias(temperaturas, mediaMax, ObtenMaxima, MayorQue);
            Console.WriteLine();

            float mediaMin = MediaTemperaturas(temperaturas, ObtenMinima);
            Console.WriteLine($"Provincias con temperatura mínima inferior a la media ({mediaMin:F2}):");
            MuestraProvincias(temperaturas, mediaMin, ObtenMinima, MenorQue);
            Console.WriteLine();

            Console.WriteLine($"Provincias con temperatura mínima igual a la media ({mediaMin:F2}):");
            MuestraProvincias(temperaturas, mediaMin, ObtenMinima, IgualQue);

            Console.WriteLine("\nPulsa una tecla para finalizar...");
            Console.ReadKey(true);
        }
    }
}
