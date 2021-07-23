using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Extension
{
     static class Extensora
    {

        /// <summary>
        /// Devuelve el codigo de fabricante.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ObtenerCodigoFabricante(this string source)
        {
            return source.Substring(source.Length - 4);
        }
    }
}
