using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Debera validar que el parametro ingresado sea +,-,/ ó *  . Caso contrario debera retornar + 
        /// </summary>
        /// <param name="operador"> Parametro que contendra el valor de la operacion matematica.</param>
        /// <returns>Retornara el operador en formato string</returns>
        public static string ValidarOperador(char operador)
        {
            string output = "+";
            switch (operador)
            {
                case '-':
                case '*':
                case '/':
                    output = operador.ToString();
                    break;
            }
            return output;
        }

        /// <summary>
        /// Realiza la operación correspondiente a la calculadora validando el operador ingresado
        /// </summary>
        /// <param name="numeroUno"> Primer número ingresado </param>
        /// <param name="numeroDos"> Segundo número ingresado </param>
        /// <param name="operador"> Operador</param>
        /// <returns> el resultado de la operacion </returns>
        public static double Operar(Numero numeroUno, Numero numeroDos, string operador)
        {
            double output = 0;

            if (operador.Equals(""))
            {
                operador = " ";
            }

            string operadorInput = ValidarOperador(operador[0]);
            switch (operadorInput)
            {
                case "+":
                    output = numeroUno + numeroDos;
                    break;
                case "-":
                    output = numeroUno - numeroDos;
                    break;
                case "*":
                    output = numeroUno * numeroDos;
                    break;
                case "/":
                    output = numeroUno / numeroDos;
                    break;
            }
            return output;
        }

    }       
}
