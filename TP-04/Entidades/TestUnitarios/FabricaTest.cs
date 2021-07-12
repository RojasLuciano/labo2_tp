using Entidades;
using Entidades.Entidades.Herencia;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestUnitarios
{
    [TestClass]
    public class FabricaTest
    {
        [TestMethod]
        public void AlFabricarPartesDistintasDebeResponderOK()
        {
            Fabrica miFabrica = new Fabrica("FabricaTest");
            Chasis chasis = new Chasis(ETipoDeMaterial.Acero, 2, 2, "Compacto");
            Puerta puerta = new Puerta(ETipoDeMaterial.Aluminio, 2, 2, "Derecha delantera");

            bool output = miFabrica + chasis && miFabrica + puerta;

            Assert.IsTrue(output);
        }

        [TestMethod] 
        [ExpectedException(typeof(AutoPartesException))]
        public void AlAgregarPartesIgualesDebeTirarException()
        {
            Fabrica miFabrica = new Fabrica("FabricaTest");
            Chasis chasis = new Chasis(ETipoDeMaterial.Acero, 2, 2, "Compacto");

            bool output = miFabrica + chasis && miFabrica + chasis;
        }

        [TestMethod]
        [ExpectedException(typeof(AutoPartesException))]
        public void AlEliminarDosVecesLaMismaParteDeberiaTirarException()
        {
            Fabrica miFabrica = new Fabrica("FabricaTest");
            Chasis chasis = new Chasis(ETipoDeMaterial.Acero, 2, 2, "Compacto");

            chasis.EstaDefectuoso = true;

            bool output = miFabrica - chasis;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AlNoExistirMaterialDeberiaArrojarException()
        {
            Fabrica miFabrica = new Fabrica("FabricaTest");
            miFabrica.DoyMaterial((ETipoDeMaterial)Enum.Parse(typeof(ETipoDeMaterial), "Oro"));
        }

        [TestMethod]
        [ExpectedException(typeof(MaterialException))]
        public void AlNoHaberMaterialDeberiaArrojarException()
        {
            Fabrica miFabrica = new Fabrica("FabricaTest");
            miFabrica.Materiales.Add(new Material(ETipoDeMaterial.Acero, 1, 2, 1, 7850));

            Fabrica.HayMaterialSuficiente(miFabrica.DoyMaterial(ETipoDeMaterial.Acero), 2, 2);
        }


    }
}
