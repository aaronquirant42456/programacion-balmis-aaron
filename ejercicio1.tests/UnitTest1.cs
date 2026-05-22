using Xunit;
using ejercicio1;
using System.IO;

namespace ejercicio1.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Usuario_AsignaPropiedades_Correctamente()
        {
            var u = new Usuario { Nombre = "Test", Edad = 20, Activo = true };
            Assert.Equal("Test", u.Nombre);
            Assert.Equal(20, u.Edad);
            Assert.True(u.Activo);
        }

        [Fact]
        public void Program_EscribeEnFichero_CreaArchivoCorrectamente()
        {
            // Setup
            string archivoTest = "test_usuario_escribe.json";
            string nombreOriginal = Program.nombreFichero; 
            Program.nombreFichero = archivoTest;

            if (File.Exists(archivoTest)) File.Delete(archivoTest);

            var u = new Usuario { Nombre = "UsuarioTest", Edad = 99, Activo = false };

            // Act
            Program.EscribeEnFichero(u);

            // Assert
            Assert.True(File.Exists(archivoTest));
            string contenido = File.ReadAllText(archivoTest);
            Assert.Contains("UsuarioTest", contenido);

            // Cleanup
            if (File.Exists(archivoTest)) File.Delete(archivoTest);
            Program.nombreFichero = nombreOriginal;
        }

        [Fact]
        public void Program_LeeFichero_NoLanzaExcepcion()
        {
            // Setup
            string archivoTest = "test_usuario_lee.json";
            string nombreOriginal = Program.nombreFichero; 
            Program.nombreFichero = archivoTest;

            // Creamos un archivo dummy
            File.WriteAllText(archivoTest, "{\"nombre\":\"TestRead\",\"edad\":30,\"activo\":true}\n");

            // Act & Assert
            var exception = Record.Exception(() => Program.LeeFichero());
            Assert.Null(exception);

            // Cleanup
            if (File.Exists(archivoTest)) File.Delete(archivoTest);
            Program.nombreFichero = nombreOriginal;
        }
    }
}
