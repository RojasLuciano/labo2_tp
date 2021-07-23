using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Carroceria : AutoParte
    {
        public string tipoCarroceria;

        /// <summary>
        /// Propiedad de lectura y escritura para darle valor el tipo de carroceria.
        /// </summary>
        public string TipoCarroceria
        {
            get
            {
                return this.tipoCarroceria;
            }
            set => tipoCarroceria = value;
        }

        /// <summary>
        /// Constructor del Capot.
        /// </summary>
        public Carroceria() { }

        /// <summary>
        /// Constructor del Capot con parametros.
        /// </summary>
        /// <param name="tipoDeMaterial">Valor para el tipo de material </param>
        /// <param name="alto">Valor para la altura</param>
        /// <param name="largo">Valor para el largo.</param>
        /// <param name="tipoCarroceria">Valor para el tipo de carroceria.</param>
        public Carroceria(ETipoDeMaterial tipoDeMaterial, double alto, double largo, string tipoCarroceria) : base(tipoDeMaterial, alto, largo)
        {
            this.tipoCarroceria = tipoCarroceria;
        }

        /// <summary>
        /// Metodo para informar los datos del Capot.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Tipo de carroceria : {TipoCarroceria}");
            return sb.ToString();
        }
    }
}