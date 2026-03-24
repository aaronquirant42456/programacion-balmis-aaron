using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Linq;


namespace Ejercicio5
{
    public class Program
    {
        // Escribe un método AplicaIva, que devuelva un Delegado con el precio total de un producto, a partir de aplicar un IVA al precio inicial.
        public static Func<double, double, double> AplicaIVA() => (precio, iva) => precio * (1 + iva / 100); //forumal:  precio * (1 + iva / 100);
        // Escribe un método AplicaDescuento, que devuelva un Delegado con el precio total de un producto a partir de aplicar un descuento a un precio inicial.
        public static Func<double, double, double> AplicaDescuento() => (precio, descuento) => precio * (1 - descuento / 100);
        // Escribe un método CarritoCompra, que devuelva un Delegado con el precio total de una lista de la compra.
        // La lista de la compra se recibirá como una lista de tuplas o pares de valores
        public static Func<List<(double precio, double porcentaje)>, Func<double, double, double>, double> CarritoCompra() => (lista, operacion) => lista.Sum(l => operacion(l.precio, l.porcentaje));

        public static void Main()
        {

            Console.WriteLine("Ejercicio 5. Carrito compra con Lambdas\n");
            
            var calcularIva = AplicaIVA();
            var calcularDescuento = AplicaDescuento();

            Console.WriteLine($"Para un precio de 4 euros y un IVA de 3% el total final será: {calcularIva(3, 4)}");
            Console.WriteLine($"Para un precio de 4 euros y un descuento de 3% el total final será: {calcularDescuento(3, 4)}");

            // Calculando el precio del carrito
            // Lista simulada: (Precio, Porcentaje)
            var cesta = new List<(double precio, double porcentaje)>
            {
                (10, 1),
                (20, 2),
                (30, 3)
            };

            var procesarCarrito = CarritoCompra();
            
            // Usando Descuentos
            // 10->9.9, 20->19.6, 30->29.1 => Total 58.6
            double totalDescuento = procesarCarrito(cesta, calcularDescuento);
            Console.WriteLine($"El total del carrito con descuentos es: {totalDescuento:F2}");

            Console.WriteLine("Pulsa una tecla para finalizar...");
            Console.ReadLine();
        }
    }
}