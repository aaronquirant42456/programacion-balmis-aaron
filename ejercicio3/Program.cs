using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ejercicio3
{
    public record LineaPedido(string Producto, int Cantidad);
    public record Pedido(int Id, string Cliente, List<LineaPedido> Lineas);
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("\nEjercicio 3. Auditoría de Pedidos");
            //TODO: Completar el código del ejercicio aquí

            List<Pedido> pedidos = new()
            {
                new Pedido(
                    1,
                    "Juan Cuesta",
                    new List<LineaPedido>
                        {
                            new LineaPedido("Monitor", 2),
                            new LineaPedido("Ratón", 1)
                        }
                ),
                new Pedido(
                    2,
                    "Mariano Delgado",
                    new List<LineaPedido>
                        {
                            new LineaPedido("Teclado", 1)
                        }
                ),
                new Pedido(
                    3,
                    "Andrés Guerra",
                    new List<LineaPedido>
                        {
                            new LineaPedido("Impresora", 1),
                            new LineaPedido("Toner", 4)
                        }
                )
            };

            // pso 1
            var aplanado = pedidos
                .SelectMany(pedido => pedido.Lineas
                    .Select(linea => new
                    {
                        IdPedido = pedido.Id,
                        Producto = linea.Producto,
                        Cantidad = linea.Cantidad
                    })
                );

            /* Console.WriteLine($"\nLineas de pedido ({pedidos.Count()}):");
            foreach(var ap in aplanado) Console.WriteLine(ap); */

            // paso 2
            // AUD-001 AUD-002 ...
            var generarCodigos = Enumerable.Range(1, aplanado.Count())
                .Zip(aplanado, (contador, pedido) => new
                {
                    Codigo = $"AUD-{contador:D3}",    
                    pedido.IdPedido,
                    pedido.Producto,
                    pedido.Cantidad
                });
            
            /* Console.WriteLine("\nCódigos generados para cada lúinea: ");
            foreach(var codigo in generarCodigos)
                Console.WriteLine(codigo); */

            // paso 3
            foreach(var pedido in generarCodigos)
                Console.WriteLine($"{pedido.Codigo}: Pedido {pedido.IdPedido} - {pedido.Producto} ({pedido.Cantidad} uds)");

            Console.WriteLine("\nPulsa una tecla para finalizar...");
            // Console.ReadKey();
        }
    }
}