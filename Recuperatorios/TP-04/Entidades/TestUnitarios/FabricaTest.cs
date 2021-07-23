using Entidades;
using Entidades.Entidades.Herencia;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Entidades.Extension;

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
        public void AlAgregarUnaPiezaDeberiaRetornarTrue()
        {
            Fabrica miFabrica = new Fabrica("FabricaTest");
            Chasis chasis = new Chasis(ETipoDeMaterial.Acero, 2, 2, "Compacto");
            Assert.IsTrue(miFabrica + chasis);
        }

        [TestMethod]
        public void SiLaPiezaYaExisteEnLaFabricaDeberiaRetornarTrue()
        {
            Fabrica miFabrica = new Fabrica("FabricaTest");
            Chasis chasis = new Chasis(ETipoDeMaterial.Acero, 2, 2, "Compacto");
            bool output = miFabrica + chasis;
            Assert.IsTrue(miFabrica == chasis);
        }

        /// <summary>
        /// Es verdadero que la pieza NO existe en la fabrica.
        /// </summary>
        [TestMethod]
        public void SiLaPiezaNoExisteEnLaFabricaDeberiaRetornarTrue()
        {
            Fabrica miFabrica = new Fabrica("FabricaTest");
            Chasis chasis = new Chasis(ETipoDeMaterial.Acero, 2, 2, "Compacto");
            Assert.IsTrue(miFabrica != chasis);
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
        public void NoDebeRetirarDeLaFabricaUnaPiezaNoDefectuosa()
        {
            Fabrica miFabrica = new Fabrica("FabricaTest");
            Chasis chasis = new Chasis(ETipoDeMaterial.Acero, 2, 2, "Compacto");
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

        [TestMethod]
        public void SiSolicitoLaListaDeMaterialesDeberiaDevolvermeUnaListaDeMateriales()
        {
            Fabrica miFabrica = new Fabrica("FabricaTest");
            miFabrica.Materiales.Add(new Material(ETipoDeMaterial.Acero, 1, 2, 1, 7850));
            Assert.IsTrue(miFabrica.Materiales is List<Material>);
        }

        [TestMethod]
        public void SiSolicitoLaListaDeAutoPartesDeberiaDevolvermeUnaListaDeAutoPartes()
        {
            Fabrica miFabrica = new Fabrica("FabricaTest");
            Chasis chasis = new Chasis(ETipoDeMaterial.Acero, 2, 2, "Compacto");
            bool output = miFabrica + chasis;
            Assert.IsTrue(miFabrica.AutoPartes is List<AutoParte>);
        }

        [TestMethod]
        public void SiModificoElEstadoDeUnaPieza()
        {
            Fabrica miFabrica = new Fabrica("FabricaTest");
            Chasis chasis = new Chasis(ETipoDeMaterial.Acero, 2, 2, "Compacto");
            chasis.EstaDefectuoso = true;
            Assert.IsTrue(chasis.EstaDefectuoso);
        }

        [TestMethod]
        public void VerificarAgisnacionDeNombreaLaFabrica()
        {
            Fabrica miFabrica = new Fabrica("FabricaTest");
            Assert.IsTrue(miFabrica.NombreFabrica == "FabricaTest");
        }

    }
}
