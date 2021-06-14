using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquinery
{
    public class PaintingMachine
    {

        /// <summary>
        /// Metodo static que simulara pintar una pieza.
        /// </summary>
        /// <param name="piece">Objeto sobre el cual se realizara la accion</param>
        /// <returns></returns>
        public static Piece ToBePainting(Piece piece)
        {
            piece.EstaPintado = true;
            return piece;
        }

    }
}
