using Xunit;
using ejercicio2;
using System.IO;
using System.Collections.Generic;

namespace ejercicio2.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Usuario_AsignaPropiedades_Correctamente()
        {
            var u = new Usuario { Nombre = "U2", Edad = 30, Activo = false };
            Assert.Equal("U2", u.Nombre);
        }

        [Fact]
        public void Grupo_AsignaPropiedades_Correctamente()
        {
            var g = new Grupo { NombreGrupo = "G1" };
            Assert.Equal("G1", g.NombreGrupo);
            Assert.NotNull(g.Miembros);
        }

        [Fact]
        public void GestorDeGrupos_GuardaGrupo_CreaFichero()
        {
             // Setup
             string ruta = "test_grupo.json";
             if(File.Exists(ruta)) File.Delete(ruta);
             
             var g = new Grupo { NombreGrupo = "TGroup" };
             
             // Act
             GestorDeGrupos.GuardaGrupo(g, ruta);
             
             // Assert
             Assert.True(File.Exists(ruta));
             string content = File.ReadAllText(ruta);
             Assert.Contains("TGroup", content);
             
             // Cleanup
             File.Delete(ruta);
        }

        [Fact]
        public void GestorDeGrupos_CargaGrupos_LeeCorrectamente()
        {
             // Setup
             string ruta = "test_grupo_read.json";
             string json = "{\"nombreGrupo\":\"GRead\",\"miembros\":[]}";
             File.WriteAllText(ruta, json + "\n");
             
             // Act
             var grupos = GestorDeGrupos.CargaGrupos(ruta);
             
             // Assert
             Assert.Single(grupos);
             Assert.Equal("GRead", grupos[0].NombreGrupo);
             
             // Cleanup
             File.Delete(ruta);
        }
    }
}
