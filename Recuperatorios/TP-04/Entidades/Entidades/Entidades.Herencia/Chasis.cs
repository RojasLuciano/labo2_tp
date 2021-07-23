using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Chasis : AutoParte
    {
        private string tipoDeChasis;

        /// <summary>
        /// Propiedad de lectura y escritura para darle valor al tipo de chasis
        /// </summary>
        public string TipoDeChasis
        {
            get
            {
                return this.tipoDeChasis;
            }
            set => tipoDeChasis = value;
        }

        /// <summary>
        /// Constructor del Chasis.
        /// </summary>
        public Chasis()
        {

        }

        /// <summary>
        /// Constructor del Chasis con parametros.
        /// </summary>
        /// <param name="tipoDeMaterial">Valor para el tipo de material </param>
        /// <param name="alto">Valor para la altura</param>
        /// <param name="largo">Valor para el largo.</param>
        /// <param name="tipoDeChasis">Valor para el tipo de chasis.</param>
        public Chasis(ETipoDeMaterial tipoDeMaterial, double alto, double largo, string tipoDeChasis) : base(tipoDeMaterial, alto, largo)
        {
            this.tipoDeChasis = tipoDeChasis;
        }

        /// <summary>
        /// Metodo para informar los datos del Chasis.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Tipo de Chasis: {TipoDeChasis}");
            return sb.ToString();
        }

    }
}