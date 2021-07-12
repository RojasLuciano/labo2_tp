using Entidades;
using Entidades.Entidades.Files;
using Entidades.Entidades.Herencia;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestUnitarios
{
    [TestClass]
    public class FilesTest
    {
        [TestMethod]
        public void CuandoSerializoMaterialesDeberiaGuardarCorrectamente()
        {
            Fabrica miFabrica = new Fabrica("FabricaTest");

            miFabrica.Materiales.Add(new Material(ETipoDeMaterial.Acero, 50, 50, 5, 7850));
            miFabrica.Materiales.Add(new Material(ETipoDeMaterial.Aluminio, 50, 50, 4, 7850));

            Assert.IsTrue(Fabrica.Save(miFabrica, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "datos.xml"));
        }

        [TestMethod]
        [ExpectedException(typeof(FileException))]
        public void CuandoLaRutaEsInvalidaDeberiaLanzarErrorArchivosException()
        {
            Fabrica miFabrica = new Fabrica("FabricaTest");
            Chasis chasis = new Chasis(ETipoDeMaterial.Acero, 2, 2, "Compacto");
            Puerta puerta = new Puerta(ETipoDeMaterial.Aluminio, 2, 2, "Derecha delantera");

            bool output = miFabrica + chasis && miFabrica + puerta;

            Fabrica.Save(miFabrica,"");
        }
    }
}
