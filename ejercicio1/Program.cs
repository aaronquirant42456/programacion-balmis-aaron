using System.Text.Json;
using System.Text.Json.Serialization;

namespace ejercicio1
{
    public record class Usuario(
        [property: JsonPropertyName("nombre")]
        string Nombre,
        [property: JsonPropertyName("edad")]
        int edad,
        [property: JsonPropertyName("activo")]
        bool Activo);

    public class Program
    {
        public static string nombreFichero = "usuario.json";

        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 1. Serialización Básica de un Objeto\n");
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n--- MENÚ USUARIOS ---");
                Console.WriteLine("1. Añadir usuario");
                Console.WriteLine("2. Leer todos los usuarios");
                Console.WriteLine("3. Salir");
                Console.Write("Elige una opción: ");
                
                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AnadeUsuario();
                        break;
                    case "2":
                        LeeFichero();
                        break;
                    case "3":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }

            Console.WriteLine("\nPulse una tecla para seguir...");
            Console.ReadKey();
        }

        static void AnadeUsuario()
        {
            Console.WriteLine("Creando nuevo usuario...");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine() ?? string.Empty;
            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("¿Está activo? (s/n): ");
            char activo = char.Parse(Console.ReadLine() ?? "n");
            bool esActivo;
            if (activo == 's' || activo == 'S')
                esActivo = true;
            else
                esActivo = false;

            Usuario usuario = new Usuario(nombre, edad, esActivo);
            EscribeEnFichero(usuario);
            Console.WriteLine("Usuario añadido correctamente. al fichero.");
        }

        public static void EscribeEnFichero(Usuario usuario)
        {
            string json = JsonSerializer.Serialize(usuario);
            using StreamWriter sw = new StreamWriter(nombreFichero, append: true);
            sw.WriteLine(json);
        }

        public static void LeeFichero()
        {
            if (!File.Exists(nombreFichero))
            {
                Console.WriteLine("No hay usuarios para leer.");
                return;
            }

            Console.WriteLine("\n--- LISTA DE USUARIOS ---");

            using StreamReader sr = new StreamReader(nombreFichero);

            string linea;

            while((linea = sr.ReadLine()!) != null)
            {
                try
                {
                    Usuario? usuario =
                        JsonSerializer.Deserialize<Usuario>(linea);

                    if (usuario != null)
                    {
                        Console.WriteLine(
                            $"Nombre: {usuario.Nombre}, " +
                            $"Edad: {usuario.edad}, " +
                            $"Activo: {usuario.Activo}"
                        );
                    }
                }
                catch (JsonException)
                {
                    Console.WriteLine("Error al leer una línea JSON.");
                }
            }
        }
    }
}
