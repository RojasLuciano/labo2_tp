using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquinery
{
    public class WeldingMachine
    {


        /// <summary>
        /// Metodo static que simulara la soldadura a una pieza, este añadira el peso de una soldadura promedio.
        /// </summary>
        /// <param name="piece">Objeto sobre el cual se realizara la accion</param>
        /// <returns></returns>
        public static Piece ToBeWelding(Piece piece)
        {
            piece.Width += 0.5;
            piece.EstaSoldado = true;
            return piece;
        }
    }
}
