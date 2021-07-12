using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Capot : AutoParte
    {
        public string aperturaDesde;

        /// <summary>
        /// Propiedad de lectura y escritura para darle valor a la apertura del capot.
        /// </summary>
        public string AperturaDesde
        {
            get
            {
                return this.aperturaDesde;
            }
            set => aperturaDesde = value;
        }

        /// <summary>
        /// Constructor del Capot.
        /// </summary>
        public Capot() { }

        /// <summary>
        /// Constructor del Capot con parametros.
        /// </summary>
        /// <param name="tipoDeMaterial">Valor para el tipo de material </param>
        /// <param name="alto">Valor para la altura</param>
        /// <param name="largo">Valor para el largo.</param>
        /// <param name="aperturaDesde">Valor para la apertura</param>
        public Capot(ETipoDeMaterial tipoDeMaterial, double alto, double largo, string aperturaDesde) : base(tipoDeMaterial, alto, largo)
        {
            this.aperturaDesde = aperturaDesde;
        }

        /// <summary>
        /// Metodo para informar los datos del Capot.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Apertura desde : {AperturaDesde}");
            return sb.ToString();
        }
    }
}