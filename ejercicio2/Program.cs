using System;

namespace Ejercicio2
{
    public static class ReglasDescuento
    {
        public static double DescuentoPorCantidad(double importe, int cantidad, bool esVip)
        {
            if (cantidad > 10) return 15;
            else if (cantidad > 5) return 5;
            else return 0;
        }
        public static double DescuentoVip(double importe, int cantidad, bool esVip)
        {
            if (esVip) return 20;
            return 0;
        }
        public static double DescuentoCombinado(double importe, int cantidad, bool esVip)
        {
            if (esVip && cantidad > 5) return 25;
            else if (esVip) return 15;
            else if (cantidad > 5) return 10;
            return 0;
        }
    }
    public class Program
    {
        public delegate double CalculoDescuento(double importe, int cantidad, bool esVip);
        public static void ProcesaPedido(double importe, int cantidad, bool esVip, CalculoDescuento calcDesc)
        {
            double descuento = calcDesc(importe, cantidad, esVip);
            double total = importe - descuento;
            Console.WriteLine($"Descuento aplicado: {descuento} (Precio final: {total})");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 2. Delegados tradicionales\n");

            // Caso 1: VIP, mucha cantidad
            double importe1 = 1000;
            int cantidad1 = 12;
            bool esVip1 = true;

            Console.WriteLine($"\nPedido 1: Importe={importe1}, Cantidad={cantidad1}, VIP={esVip1}");
            ProcesaPedido(importe1, cantidad1, esVip1, ReglasDescuento.DescuentoPorCantidad);
            ProcesaPedido(importe1, cantidad1, esVip1, ReglasDescuento.DescuentoVip);
            ProcesaPedido(importe1, cantidad1, esVip1, ReglasDescuento.DescuentoCombinado);

            // Caso 2: No VIP, poca cantidad
            double importe2 = 500;
            int cantidad2 = 3;
            bool esVip2 = false;

            Console.WriteLine($"\nPedido 2: Importe={importe2}, Cantidad={cantidad2}, VIP={esVip2}");
            ProcesaPedido(importe2, cantidad2, esVip2, ReglasDescuento.DescuentoPorCantidad);
            ProcesaPedido(importe2, cantidad2, esVip2, ReglasDescuento.DescuentoCombinado);

            Console.WriteLine("\nPulsar una tecla para finalizar...");
            Console.ReadKey(true);
        }
    }
}