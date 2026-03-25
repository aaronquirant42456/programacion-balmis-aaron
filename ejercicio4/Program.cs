using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ejercicio4.tests")]

namespace Ej5_ConsultasProductos
{
    public class Producto
    {
        public string CodArticulo { get; init; }
        public string Descripcion { get; init; }
        public string Categoria { get; init; }
        public string[] Colores { get; init; }
        public Dimensiones Dimensiones { get; init; }
        public double Precio { get; init; }
    }
    public class Dimensiones
    {
        public int Largo { get; init; }
        public int Ancho { get; init; }
        public int Espesor { get; init; }
        public override string ToString() => $"L:{Largo} x A:{Ancho} x E:{Espesor}";
    }

    public static class Datos
    {
        public static IEnumerable<Producto> Productos
        {
            get
            {
                yield return new()
                {
                    CodArticulo = "A01",
                    Descripcion = "Uno",
                    Categoria = "C1",
                    Colores = new string[] { "blanco", "negro", "gris" },
                    Dimensiones = new()
                    {
                        Largo = 4,
                        Ancho = 4,
                        Espesor = 3
                    },
                    Precio = 15.05
                };
                yield return new()
                {
                    CodArticulo = "A02",
                    Descripcion = "Dos",
                    Categoria = "C1",
                    Colores = new string[] { "blanco", "gris", "rojo" },
                    Dimensiones = new()
                    {
                        Largo = 4,
                        Ancho = 10,
                        Espesor = 2
                    },
                    Precio = 25.95
                };
                yield return new()
                {
                    CodArticulo = "A03",
                    Descripcion = "Tres",
                    Categoria = "C1",
                    Colores = new string[] { "rojo", "gris", "verde" },
                    Dimensiones = new()
                    {
                        Largo = 5,
                        Ancho = 5,
                        Espesor = 3
                    },
                    Precio = 30.25
                };
                yield return new()
                {
                    CodArticulo = "A04",
                    Descripcion = "Cuatro",
                    Categoria = "C2",
                    Colores = new string[] { "verde", "rojo" },
                    Dimensiones = new()
                    {
                        Largo = 6,
                        Ancho = 8,
                        Espesor = 4
                    },
                    Precio = 18.45
                };
            }
        }

        class Principal
        {
            static void Main()
            {
                Console.WriteLine("Ejercicio 5. Consultas sobre lista de productos\n");
                string SeparadorConsulta = "\n" + new string('-', 80) + "\n";

                Console.WriteLine(SeparadorConsulta);
                Console.WriteLine(
                    "Consulta 1: Usando las funciones Where y Select.\n" +
                    "Mostrar CodArticulo, Descripcion y Precio .\n" +
                    "de productos con Precio entre 10 y 30 euros\n");
                var consulta1 = Productos.Where(p => p.Precio >= 10 && p.Precio <= 30)
                                         .Select(p => new
                                         {
                                             CodArticulo = p.CodArticulo,
                                             Descripcion = p.Descripcion,
                                             Precio = p.Precio
                                         });
                Console.WriteLine(string.Join("\n", consulta1));

                Console.WriteLine(SeparadorConsulta);
                Console.WriteLine(
                    "Consulta 2: Usando las funciones Select, OrderByDescending y Take.\n" +
                    "Muestra CodArticulo, Descripcion y Precio de los 3 productos.\n" +
                    "más caros (ordenando por Precio descendente)\n");
                var consulta2 = Productos
                    .OrderByDescending(p => p.Precio)
                    .Take(3)
                    .Select(producto => new
                    {
                        producto.CodArticulo,
                        producto.Descripcion,
                        producto.Precio
                    });
                Console.WriteLine(string.Join("\n", consulta2));

                Console.WriteLine(SeparadorConsulta);
                Console.WriteLine(
                    "Consulta 3: Usando las funciones GroupBy, OrderBy y First.\n" +
                    "Muestra el precio más barato por categoría\n");
                var consulta3 = Productos
                    .OrderBy(producto => producto.Precio)
                    .GroupBy(producto => producto.Categoria, (categoria, precioMasBaratoPorCategoria) => new
                    {
                        Categoria = categoria,
                        Precio = precioMasBaratoPorCategoria.Min(prod => prod.Precio)
                    })
                    .First();
                Console.WriteLine(string.Join("\n", consulta3));

                Console.WriteLine(SeparadorConsulta);
                Console.WriteLine(
                    "Consulta 4: Usando las funciones GroupBy, Count.\n" +
                    "¿Cuántos productos hay de cada categoría?\n");
                var consulta4 = Productos
                    .GroupBy(producto => producto.Categoria)
                    .Select(producto => producto.Count());
                Console.WriteLine(string.Join("\n", consulta4));

                Console.WriteLine(SeparadorConsulta);
                Console.WriteLine(
                    "Consulta 5: Usando las funciones GroupBy, Count, Where y Select\n" +
                    "Mostrar las categorías que tengan más de 2 productos\n");
                var consulta5 = Productos
                    .GroupBy(producto => producto.Categoria)
                    .Where(productosCategoria => productosCategoria.Count() > 2)
                    // Cuando usas GroupBy en LINQ, cada grupo que se genera es un IGrouping<TKey, TElement>, donde .Key representa la clave del grupo, es decir, el valor por el que agrupaste (por ejemplo, la categoría), y los elementos que pertenecen al grupo están dentro del propio IGrouping. Por eso usamos .Key para acceder al valor que define el grupo y poder mostrarlo o procesarlo; en pocas palabras, .Key es “el nombre del grupo” que identifica sus elementos.
                    .Select(cat => new { Categoria = cat.Key });
                Console.WriteLine(string.Join("\n", consulta5));

                Console.WriteLine(SeparadorConsulta);
                Console.WriteLine(
                    "Consulta 6: Usando la función Select\n" +
                    "Mostrar CodArticulo, Descripcion, Precio y Descuento redondeado a 2 decimales,\n" +
                    "siendo Descuento el 10% del Precio\n");
                var consulta6 = Productos
                    .Select(producto => new
                    {
                        Codigo = producto.CodArticulo,
                        Descripcion = producto.Descripcion,
                        Precio = Math.Round(producto.Precio, 2),
                        Descuento = 10.00
                    });
                Console.WriteLine(string.Join("\n", consulta6));

                Console.WriteLine(SeparadorConsulta);
                Console.WriteLine(
                    "Consulta 7: Usando las funciones Where, Contains y Select.\n" +
                    "Mostrar CodArticulo, Descripcion y Colores\n" +
                    "de los productos de color verde o rojo\n" +
                    "(es decir, que contengan alguno de los dos)\n");
                var consulta7 = Productos
                    .Where(producto => producto.Colores.Contains("verde") || producto.Colores.Contains("rojo"))
                    .Select(producto => new
                    {
                        Codigo = producto.CodArticulo,
                        Descripcion = producto.Descripcion,
                        Colores = String.Join(", ", producto.Colores)
                    });
                Console.WriteLine(string.Join("\n", consulta7));

                Console.WriteLine(SeparadorConsulta);
                Console.WriteLine(
                    "Consulta 8: Usando las funciones Where, Count y Select.\n" +
                    "Mostrar CodArticulo, Descripcion y Colores.\n" +
                    "de los productos que se fabrican en tres Colores\n");
                var consulta8 = Productos
                    .Where(producto => producto.Colores.Count() == 3)
                    .Select(producto => new
                    {
                        Codigo = producto.CodArticulo,
                        Descripcion = producto.Descripcion,
                        Colores = String.Join(", ", producto.Colores)
                    });
                Console.WriteLine(string.Join("\n", consulta8));

                Console.WriteLine(SeparadorConsulta);
                Console.WriteLine(
                    "Consulta 9: Usando las funciones Where, Select.\n" +
                    "Mostrar CodArticulo, Descripcion y Dimensiones\n" +
                    "de los productos con espesor de 3 cm\n");
                var consulta9 = Productos
                    .Where(producto => producto.Dimensiones.Espesor == 3)
                    .Select(producto => new
                    {
                        Codigo = producto.CodArticulo,
                        Descripcion = producto.Descripcion,
                        DimesionEspesor = producto.Dimensiones.Espesor
                    });
                Console.WriteLine(string.Join("\n", consulta9));

                Console.WriteLine(SeparadorConsulta);
                Console.WriteLine(
                    "Consulta 10: Usando las funciones SelectMany, Distinct y OrderBy.\n" +
                    "Mostrar los colores de productos ordenados y sin repeticiones\n");
                var consulta10 = Productos
                    .SelectMany(prod => prod.Colores)
                    .Distinct()
                    .OrderBy(colroes => colroes);
                Console.WriteLine(string.Join("\n", consulta10));


                Console.WriteLine(SeparadorConsulta);
                Console.WriteLine(
                    "Consulta 11: Usando las funciones SelectMany, GroupBy, OrderByDescending.\n" +
                    "Mostrar TotalProductos que hay de cada Color ordenando de mayor a menor cantidad\n");
                var consulta11 = Productos
                    .SelectMany(producto => producto.Colores, (producto, color) => new 
                    { 
                        Producto = producto.CodArticulo, 
                        Color = color 
                    })
                    .GroupBy(productos => productos.Color)
                    .OrderByDescending(prodcutos => prodcutos.Count())
                    .Select(producto => new
                    {
                        Color = producto.Key,
                        TotalProducto = producto.Count()
                    });
                Console.WriteLine(string.Join("\n", consulta11));

                Console.WriteLine("\nPulsa una tecla para finalizar...");
                //  Console.ReadKey();
            }
        }
    }
}