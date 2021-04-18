using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// El constructor por defecto (sin parámetros) asignará valor 0 al atributo numero.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor que recibe un parámetro del tipo double para inicializar su atributo número
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        ///Constructor que recibe un parámetro del tipo string para inicializar su atributo número
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Método que setea un valor al atributo numero.
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = this.ValidarNumero(value);
            }
        }

        /// <summary>
        /// Recibe un tipo de dato del tipo string y reemplaza los "." por "," y parsea el numero a double.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>Valor del tipo double con número validado</returns>
        private double ValidarNumero(string strNumero)
        {
            {
                StringBuilder sb = new StringBuilder(strNumero);
                for (int i = 0; i < strNumero.Length; i++)
                {
                    if (strNumero[i].Equals('.'))
                    {
                        sb.Replace('.', ',');
                    }
                }
                double.TryParse(sb.ToString(), out double numero); 
                return numero;
            }

        }

        /// <summary>
        ///  Metodo para realizar una suma entre dos operandos.
        /// </summary>
        /// <param name="n1">Valor correspondiente al primer operando</param>
        /// <param name="n2">Valor correspondiente al segundo operando</param>
        /// <returns>La suma de los dos operandos</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        ///  Metodo para realizar una resta entre dos operandos.
        /// </summary>
        /// <param name="n1">Valor correspondiente al primer operando</param>
        /// <param name="n2">Valor correspondiente al segundo operando</param>
        /// <returns>La resta de los dos operandos</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        ///  Metodo para realizar una division entre dos operandos.
        /// </summary>
        /// <param name="n1">Valor correspondiente al primer operando</param>
        /// <param name="n2">Valor correspondiente al segundo operando</param>
        /// <returns>La division de los dos operandos</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }

        /// <summary>
        ///  Metodo para realizar una multiplicacion entre dos operandos.
        /// </summary>
        /// <param name="n1">Valor correspondiente al primer operando</param>
        /// <param name="n2">Valor correspondiente al segundo operando</param>
        /// <returns>La multiplicacion de los dos operandos</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Recibe un numero binario y lo transforma en decimal
        /// </summary>
        /// <param name="binario">parametro recibido en formato string</param>
        /// <returns>numero decimal en formato string</returns>
        public  string BinarioDecimal(string binario)
        {
            string resultado = "Valor invalido";
            double acumulador = 0;
            char[] array = binario.ToCharArray();
            Array.Reverse(array);

            if (EsBinario(binario))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == '1')
                    {
                        acumulador += Math.Pow(2, i);
                    }

                }
                resultado = acumulador.ToString();
            }
            return resultado;
        }

        /// <summary>
        /// Recibe un string e intenta convertirlo en double para despues
        /// convertirlo en Binario llamando al método DecimalBinario(), en caso de que no
        /// se pueda convertir a double se emite un mensaje de error.
        /// </summary>
        /// <param name="numero">string con el valor a convertir</param>
        /// <returns>string con el número binario convertido o un string con el error</returns>
        public  string DecimalBinario(string numero)
        {
            string resultado = "Valor invalido";
            double auxNumeroIngresado;

            if (double.TryParse(numero, out auxNumeroIngresado))
            {
                resultado = DecimalBinario(auxNumeroIngresado);
            }
            return resultado;
        }

        /// <summary>
        /// Recibe un valor del tipo double y lo convierte en un string binario.
        /// </summary>
        /// <param name="numero">numero a convertir en binario</param>
        /// <returns>retorno con el string convertido en binario</returns>
        public  string DecimalBinario(double numero)
        {
            string resultado = "";
            int numeroEntero = (int)numero;

            if (numeroEntero > 0)
            {
                while (numeroEntero > 0)
                {
                    if (numeroEntero % 2 == 0)
                    {
                        resultado = "0" + resultado;
                    }
                    else
                    {
                        resultado = "1" + resultado;
                    }
                    numeroEntero = numeroEntero / 2;
                }
            }
            else
            {
                if (numeroEntero == 0)
                {
                    resultado = "0";
                }
                else
                {
                    resultado = "Valor invalido";
                }
            }
            return resultado;
        }

        /// <summary>
        /// Recibe una cadena del tipo string y valida que se corresponda a un número binario
        /// </summary>
        /// <param name="binario"></param>
        /// <returns> retorna true si es binario y false si no es binario</returns>
        private  bool EsBinario(string binario)
        {
            bool output = true;
            char[] array = binario.ToCharArray();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != '0' && array[i] != '1')
                {
                    output = false;
                    break;
                }
            }
            return output;
        }




    }
}
