using System.Text.Json;
using System.Text.Json.Serialization;

namespace ejercicio3
{
    public record class Usuario(
        [property: JsonPropertyName("nombre")]
        string Nombre,
        [property: JsonPropertyName("apodo")]
        string Apodo,
        [property: JsonPropertyName("edad")]
        int edad,
        [property: JsonPropertyName("fechaRegistro")]
        DateTime FechaRegistro,
        [property: JsonPropertyName("activo")]
        bool Activo);
    
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 3. Opciones de Serialización\n");
            
            var opciones = new JsonSerializerOptions
            {
                WriteIndented = true, // que sea legible
                PropertyNameCaseInsensitive = true, // mayus y minusc
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull // no nulls
            };

            string ruta = "usuarios_avanzados.json";

            List<Usuario> usuarios = new List<Usuario>
            {
                new Usuario("Usuario Con Apodo", "TheUser", 22, DateTime.Now, true),
                new Usuario("Usuario Sin Apodo", null, 45, DateTime.Now, true),
            };

            string json = JsonSerializer.Serialize(usuarios, opciones);
            File.WriteAllText(ruta, json);
            Console.WriteLine($"Lista guardad en {ruta}");

            Console.WriteLine();
            Console.WriteLine("Contenido del fichero generado (Verificación visual):");
            Console.WriteLine("-----------------------------------------------");

            string contenido = File.ReadAllText(ruta);
            List<Usuario>? usuariosLeidos = JsonSerializer.Deserialize<List<Usuario>>(contenido, opciones);

            Console.WriteLine(contenido);

            Console.WriteLine();
            Console.WriteLine($"Leídos {usuariosLeidos.Count} usuarios ok.");

            Console.WriteLine("\nPulse una tecla para seguir...");
         //   Console.ReadKey();
        }
    }
}
