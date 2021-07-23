using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades.Herencia
{
    public class Panel : AutoParte
    {

        public string lado;

        /// <summary>
        /// Propiedad de lectura y escritura para darle valor al lado.
        /// </summary>
        public string Lado
        {
            get
            {
                return this.lado;
            }
            set => lado = value;
        }

        /// <summary>
        /// Constructor del Chasis.
        /// </summary>
        public Panel() { }

        /// <summary>
        /// Constructor del Panel con parametros.
        /// </summary>
        /// <param name="tipoDeMaterial">Valor para el tipo de material </param>
        /// <param name="alto">Valor para la altura</param>
        /// <param name="largo">Valor para el largo.</param>
        /// <param name="lado">Valor para el lado.</param>
        public Panel(ETipoDeMaterial tipoDeMaterial, double alto, double largo, string lado) : base(tipoDeMaterial, alto, largo)
        {
            this.lado = lado;
        }

        /// <summary>
        /// Metodo para informar los datos del Panel.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Panel de lado : {Lado}");
            return sb.ToString();
        }
    }
}