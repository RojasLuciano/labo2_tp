using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquinery
{
    public class CuttingMachine
    {

        /// <summary>
        /// Metodo privado que calculara el peso de cada pieza, segun el alto, largo y densidad de la pieza.
        /// </summary>
        /// <param name="item">Material del cual se obtendran los datos.</param>
        /// <param name="altura">Altura de la pieza a cortar.</param>
        /// <param name="largo">Largo de la pieza a cortar.</param>
        /// <returns></returns>
        private static double PieceWeight(Material item, double altura, double largo)
        {
            double output;
            output = (altura * largo * item.Width * item.Density / 1000000);
            return Math.Round(output, 2);
        }

        /// <summary>
        /// Metodo publico static que simulara el corte de una pieza.
        /// </summary>
        /// <param name="item">Material del cual estara creada la pieza.</param>
        /// <param name="typeOfPieceToBeCut">El tipo de pieza que se va a crear.</param>
        /// <param name="tipoDeMaterial">Tipo de material de cual estara creada la pieza.</param>
        /// <param name="altura">Altura de la pieza a cortar</param>
        /// <param name="largo">Largo de la pieza a cortar.</param>
        /// <returns></returns>
        public static Piece ToBeCut2(Material item, typeOfPartToCreate typeOfPieceToBeCut, Tipo tipoDeMaterial, double altura, double largo)
        {
            Piece piezaCortada = null;
            try
            {
                if (item.Density > 22610)
                    throw new MachineException("Material demasiado denso");

                //Corto material
                switch (typeOfPieceToBeCut)
                {
                    case typeOfPartToCreate.Chasis:
                        piezaCortada = new Piece(typeOfPartToCreate.Chasis, tipoDeMaterial, altura, largo, item.Width, PieceWeight(item, altura, largo), true);
                        break;

                    case typeOfPartToCreate.Puerta:
                        piezaCortada = new Piece(typeOfPartToCreate.Puerta, tipoDeMaterial, altura, largo, item.Width, PieceWeight(item, altura, largo), true);
                        break;

                    case typeOfPartToCreate.Capot:
                        piezaCortada = new Piece(typeOfPartToCreate.Capot, tipoDeMaterial, altura, largo, item.Width, PieceWeight(item, altura, largo), true);
                        break;

                    case typeOfPartToCreate.Baul:
                        piezaCortada = new Piece(typeOfPartToCreate.Baul, tipoDeMaterial, altura, largo, item.Width, PieceWeight(item, altura, largo), true);
                        break;

                    case typeOfPartToCreate.Carroceria:
                        piezaCortada = new Piece(typeOfPartToCreate.Carroceria, tipoDeMaterial, altura, largo, item.Width, PieceWeight(item, altura, largo), true);
                        break;

                    case typeOfPartToCreate.Panel:
                        piezaCortada = new Piece(typeOfPartToCreate.Panel, tipoDeMaterial, altura, largo, item.Width, PieceWeight(item, altura, largo), true);
                        break;
                }
            }
            catch (MachineException e)
            {
                throw new MachineException(e);
            }
            return piezaCortada;
        }

    }
}
