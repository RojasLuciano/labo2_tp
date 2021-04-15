using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support
{
    public  static class Verificaciones
    {
        /// <summary>
        /// Metodo para verificar que los parametros recibidos correspondan a un caracter numerico.
        /// </summary>
        /// <param name="input"> El valor ingresado que se validara.</param>
        /// <returns>True si puedo parsear el valor ingresado, caso contrario retornara false.</returns>
        public static bool EsUnValorValido(string input)
        {
            bool output = false;
            if (double.TryParse(input, out _))
            {
                output = true;
            }   
            return output;
        }
    }
}
