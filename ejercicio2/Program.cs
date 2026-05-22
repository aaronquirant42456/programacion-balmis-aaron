using System.Text.Json;
using System.Text.Json.Serialization;

namespace ejercicio2
{
    public record class Usuario(
        [property: JsonPropertyName("nombre")]
        string Nombre,
        [property: JsonPropertyName("edad")]
        int Edad,
        [property: JsonPropertyName("activo")]
        bool Activo);

    public class Grupo
    {
        // así??
        [JsonPropertyName("nombreGrupo")]
        public string NombreGrupo { get; set; }
        [JsonPropertyName("miembros")]
        public List<Usuario> Miembros { get; set; }
    }

    public static class GestorDeGrupos
    {
        public static void GuardaGrupo(Grupo grupo, string ruta)
        {
            List<Grupo> gruposExistentes = new List<Grupo>();
            if (File.Exists(ruta))
            {
                string contenido = File.ReadAllText(ruta);
                if (!string.IsNullOrWhiteSpace(contenido))
                    gruposExistentes = JsonSerializer.Deserialize<List<Grupo>>(contenido) ?? new List<Grupo>();
            }

            gruposExistentes.Add(grupo);
            string nuevoContenido = JsonSerializer.Serialize(gruposExistentes, new JsonSerializerOptions 
            { 
                WriteIndented = true 
            });
            File.WriteAllText(ruta, nuevoContenido);
        }

        public static List<Grupo> CargaGrupos(string ruta)
        {
            if (!File.Exists(ruta)) 
                return new List<Grupo>();

            string contenido = File.ReadAllText(ruta);

            if(string.IsNullOrWhiteSpace(contenido)) 
                return new List<Grupo>();
            return JsonSerializer.Deserialize<List<Grupo>>(contenido) ?? new List<Grupo>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 2. Persistencia de Listas y Composición\n");
            string nombreFichero = "grupo.json";
            if (File.Exists(nombreFichero)) File.Delete(nombreFichero);

            Grupo grupoAdmin = new Grupo
            {
                NombreGrupo = "Administradores",
                Miembros = new List<Usuario>
                {
                    new Usuario ("Alice", 25, true ),
                    new Usuario ("Bob", 30, true )
                }
            };

            Grupo grupoUsuarios = new Grupo
            {
                NombreGrupo = "Usuarios",
                Miembros = new List<Usuario>
                {
                    new Usuario ("Charlie", 35, false ),
                    new Usuario ("Dave", 40, true )
                }
            };

            GestorDeGrupos.GuardaGrupo(grupoAdmin, nombreFichero);
            GestorDeGrupos.GuardaGrupo(grupoUsuarios, nombreFichero);

            Console.WriteLine("\nCargando grupos desde fichero...");
            List<Grupo> gruposRecuperados = GestorDeGrupos.CargaGrupos(nombreFichero);

            Console.WriteLine($"\nSe han recuperado {gruposRecuperados.Count} grupos.");

            foreach (var grupoRecuperado in gruposRecuperados)
            {
                Console.WriteLine("\nInformación del Grupo Recuperado:");
                Console.WriteLine($"Nombre del Grupo: {grupoRecuperado.NombreGrupo}");
                Console.WriteLine($"Cantidad de Miembros: {grupoRecuperado.Miembros.Count}");
                
                Console.WriteLine("Lista de Miembros:");
                foreach (var m in grupoRecuperado.Miembros)
                {
                     Console.WriteLine($"- {m.Nombre} ({m.Edad} años) [Activo: {m.Activo}]");
                }
            }

            Console.WriteLine("\nPulse una tecla para seguir...");
            Console.ReadKey();
        }
    }
}
