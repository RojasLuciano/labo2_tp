using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquinery
{
    public class MoldingMachine 
    {
        /// <summary>
        /// Metodo static que simulada moldear una pieza, este reducira su peso en tres cuartos de su parte.
        /// </summary>
        /// <param name="piece">Objeto sobre el cual se realizara la accion</param>
        /// <returns></returns>
        public static Piece ToBeMolding(Piece piece)
        {
            piece.Width = (3 * piece.Width / 4);
            piece.EstaMoldeado = true;
            return piece;
        }

    }
}
