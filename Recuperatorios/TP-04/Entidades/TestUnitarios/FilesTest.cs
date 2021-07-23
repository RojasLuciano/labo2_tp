using Entidades;
using Entidades.Entidades.Database;
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
        public void CuandoSerializoDeberiaGuardarCorrectamente()
        {
            Fabrica miFabrica = new Fabrica("FabricaSerializada");

            miFabrica.Materiales.Add(new Material(ETipoDeMaterial.Acero, 50, 50, 5, 7850));
            miFabrica.Materiales.Add(new Material(ETipoDeMaterial.Aluminio, 50, 50, 4, 7850));
            Fabrica.Save(miFabrica, "datos.xml");
            Fabrica miFabrica2 ;

            miFabrica2 = Fabrica.Read("datos.xml");
            Assert.IsTrue(miFabrica2.NombreFabrica.Equals("FabricaSerializada")); ;
        }

        [TestMethod]
        [ExpectedException(typeof(FileException))]
        public void CuandoLaRutaEsInvalidaDeberiaLanzarErrorFileException()
        {
            Fabrica miFabrica = new Fabrica("FabricaSerializada");

            miFabrica.Materiales.Add(new Material(ETipoDeMaterial.Acero, 50, 50, 5, 7850));
            miFabrica.Materiales.Add(new Material(ETipoDeMaterial.Aluminio, 50, 50, 4, 7850));
            Fabrica.Save(miFabrica, "datos.xml");
            Fabrica miFabrica2;
            miFabrica2 = Fabrica.Read("error.xml");
        }

        [TestMethod]
        public void CuandoNoExisteElIDEliminarDeberiaDevolverFalse()
        {
            Fabrica miFabrica = new Fabrica("FabricaSQL");
            Assert.IsFalse(miFabrica.DeletePartFromDB("lllll"));
        }

        [TestMethod]
        public void CuandoEliminoUnaPiezaDelaDBDeberiaDevolverTrue()
        {
            Fabrica miFabrica = new Fabrica("FabricaSQL");
            Chasis chasis = new Chasis(ETipoDeMaterial.Acero, 2, 2, "Compacto");
            bool nothing = miFabrica + chasis;
            miFabrica.ExportAutoPartsToDB();
            Assert.IsTrue(miFabrica.DeletePartFromDB(chasis.NumeroDeSerie));
        }

        [TestMethod]
        public void CuandoImportoYExportoDeberiaTraerLosMismoDatos()
        {
            Fabrica miFabrica = new Fabrica("FabricaSQL");
            Chasis chasis = new Chasis(ETipoDeMaterial.Acero, 2, 2, "Compacto");
            bool nothing = miFabrica + chasis;

            miFabrica.DropTableAutoParts();
            miFabrica.CreateTableAutoParts();
            miFabrica.ExportAutoPartsToDB();

            Fabrica miFabrica2 = new Fabrica("FabricaSQL2");
            miFabrica2.GetAutoPartesFromDB();
            AutoParte chasis2 = miFabrica2.AutoPartes[0];

            Assert.AreEqual(chasis.NumeroDeSerie,chasis2.NumeroDeSerie);
        }

    }
}
