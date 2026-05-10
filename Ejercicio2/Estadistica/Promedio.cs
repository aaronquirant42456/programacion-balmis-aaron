namespace Estadistica
{
    // static porque es recomendable con las utiliddaes matematicas
    public static class Promedio
    {
        public static double Media(double[] datos)
        {
            return datos.Average();
        }
        public static double Mayor(double[] datos)
        {
            return datos.Max();
        }
        public static double Menor(double[] datos)
        {
            return datos.Min();
        }
        public static double Rango(double[] datos)
        {
            return datos.Max() - datos.Min();
        }
        public static double Mediana(double[] datos)
        {
            var ordenados = datos.OrderBy(n => n).ToArray();
            int n = ordenados.Length;

            if(n % 2 == 0)
                return (ordenados[n / 2 - 1] + ordenados[n / 2]) / 2.0;
            else
                return ordenados[n / 2];
        } 
        public static bool Moda(double[] datos, out double moda) // out permite devolver mas de un valor
        {
            Dictionary<double, int> frecuencias = new();

            foreach (var n in datos)
            {
                if(frecuencias.ContainsKey(n))
                    frecuencias[n]++;
                else
                    frecuencias[n] = 1;
            }   

            int maxFrecuencia = frecuencias.Values.Max();

            if(maxFrecuencia == 1)
            {
                moda = 0;
                return false;
            }

            moda = frecuencias.First(x => x.Value == maxFrecuencia).Key;
            return true;
        }
    }
}