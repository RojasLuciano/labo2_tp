using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquinery
{
    public class DrillingMachine
    {

        /// <summary>
        ///  Metodo static que simulara agujerear una pieza, reducira en un minimo su ancho, que servia para calcular el peso de la pieza.
        /// </summary>
        /// <param name="piece">Objeto sobre el cual se realizara la accion</param>
        /// <returns></returns>
        public static Piece ToBePierce(Piece piece)
        {
            piece.Width -= 0.2;
            piece.EstaAgujereado = true;
            return piece;
        }

    }
}

