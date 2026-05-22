using Xunit;
using ejercicio3;
using System.IO;
using System;

namespace ejercicio3.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Usuario_AsignaPropiedades_Correctamente()
        {
            var u = new Usuario { Nombre = "U3", Apodo = "Nick" };
            Assert.Equal("Nick", u.Apodo);
        }

        [Fact]
        public void Program_Main_EjecutaSinErrores_Y_GeneraJsonCorrecto()
        {
            // Arrange
            string fichero = "usuarios_avanzados.json";
            if (File.Exists(fichero)) File.Delete(fichero);

            // Act
            // Ejecutamos Main. 
            var exception = Record.Exception(() => Program.Main(new string[0]));
            
            // Assert - No hay excepciones
            Assert.Null(exception);
            
            // Assert - El fichero existe
            Assert.True(File.Exists(fichero), "El fichero JSON debería haberse creado.");

            // Assert - Contenido del JSON
            string jsonContent = File.ReadAllText(fichero);
            
            // 1. Verificamos que se serializaron los datos esperados
            Assert.Contains("Usuario Con Apodo", jsonContent);
            Assert.Contains("TheUser", jsonContent);
            
            // 2. Verificamos la opción de ignorar nulos (DefaultIgnoreCondition = WhenWritingNull)
            // El usuario 2 tiene Apodo = null, por lo que NO debería aparecer "apodo": null
            // Pero el usuario 1 sí tiene apodo. Buscaremos específicamente en el bloque del segundo usuario o contaremos ocurrencias si fuera necesario.
            // Una forma simple es verificar que no existe la cadena exacta "apodo": null
            Assert.DoesNotContain("\"apodo\": null", jsonContent);

            // 3. Verificamos indentación (WriteIndented = true)
            // Debería contener saltos de línea y espacios
            Assert.Contains("\n", jsonContent); 
            Assert.Contains("  ", jsonContent);

            // 4. Verificamos nomenclatura (camelCase)
            Assert.Contains("\"nombre\":", jsonContent); // Check camelCasing property name
            Assert.Contains("\"fechaRegistro\":", jsonContent);

            // Cleanup
            if(File.Exists(fichero)) File.Delete(fichero);
        }
    }
}
