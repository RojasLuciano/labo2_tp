using Entidades;
using Files;
using Maquinery;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests_
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CuandoSerializoDeberiaGuardarCorrectamente()
        {
            Material acero = new Material(Tipo.Acero, 50, 50, 50, 7850);
            Xml<Material> serializador = new Xml<Material>();
            Material aceroDeserializado;
            Assert.IsTrue(serializador.Save("Acero.xml", acero) && serializador.Read("Acero.xml", out aceroDeserializado) && acero.Height == aceroDeserializado.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(FileException))]
        public void CuandoLaRutaEsInvalidaDeberiaLanzarErrorArchivosException()
        {
            Xml<Material> serializador = new Xml<Material>();
            Material materialDeserializado;
            serializador.Read("C:\\acero.xml", out materialDeserializado);
        }

        [TestMethod]
        [ExpectedException(typeof(MaterialException))]
        public void CuandoMeQuedoSinMaterialDeberiaLanzarFaltaDeMaterial()
        {
            Material acero = new Material(Tipo.Acero, 50, 50, 50, 7850);
            Piece newPiece;
            while (Material.ThereIsEnoughMaterial2(acero, 4, 7))
            {
                newPiece = CuttingMachine.ToBeCut2(acero, typeOfPartToCreate.Panel, Tipo.Acero, 4, 7);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(MachineException))]
        public void CuandoQuieroCortarUnMaterialMuyDensoDeberiaLanzarMachineException()
        {
            Material acero = new Material(Tipo.Acero, 50, 50, 50, 22800);
            Piece newPiece;
            while (Material.ThereIsEnoughMaterial2(acero, 4, 7))
            {
                newPiece = CuttingMachine.ToBeCut2(acero, typeOfPartToCreate.Panel, Tipo.Acero, 4, 7);
            }
        }


    }
}
