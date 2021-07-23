using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades.Herencia
{
    public class Puerta : AutoParte
    {
        public string ladoPuerta;


        /// <summary>
        /// Propiedad de lectura y escritura para darle valor al lado de la puerta
        /// </summary>
        public string LadoPuerta
        {
            get
            {
                return this.ladoPuerta;
            }
            set => ladoPuerta = value;
        }


        /// <summary>
        /// Constructor del Chasis.
        /// </summary>
        public Puerta() { }

        /// <summary>
        /// Constructor del Puerta con parametros.
        /// </summary>
        /// <param name="tipoDeMaterial">Valor para el tipo de material </param>
        /// <param name="alto">Valor para la altura</param>
        /// <param name="largo">Valor para el largo.</param>
        /// <param name="ladoPuerta">Valor para el lado de puerta..</param>
        public Puerta(ETipoDeMaterial tipoDeMaterial, double alto, double largo, string ladoPuerta) : base(tipoDeMaterial, alto, largo)
        {
            this.ladoPuerta = ladoPuerta;
        }

        /// <summary>
        /// Metodo para informar los datos del Puerta.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Puerta : {LadoPuerta}");
            return sb.ToString();
        }
    }

}