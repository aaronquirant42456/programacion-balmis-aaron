using Ejercicio1;

namespace BibliotecaExtensions
{
    public static class BibliotecaExtensiones
    {
        // Esta clase incluirá el método de extensión ISBNS que devolverá un array con los ISBN de los libros en nuestra biblioteca ordenados

        // public static string[] ISBNS(this Libro[] libros) => libros.Select(libro => libro.ISBN).OrderBy(isbn => isbn).ToArray();
        public static string[] ISBNS(this List<Libro> libros) => libros.Select(libro => libro.ISBN).OrderBy(isbn => isbn).ToArray();
    }
}