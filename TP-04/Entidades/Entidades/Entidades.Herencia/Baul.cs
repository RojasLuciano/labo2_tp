using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Baul : AutoParte
    {
        public string capacidad;

        /// <summary>
        /// Propiedad de lectura y escritura para darle valor a la capacidad del baul.
        /// </summary>
        public string Capacidad
        {
            get
            {
                return this.capacidad;
            }
            set => capacidad = value;
        }

        /// <summary>
        /// Constructor del baul.
        /// </summary>
        public Baul() { }

        /// <summary>
        /// Constructor del baul con parametros.
        /// </summary>
        /// <param name="tipoDeMaterial">Valor para el tipo de material </param>
        /// <param name="alto">Valor para la altura</param>
        /// <param name="largo">Valor para el largo.</param>
        /// <param name="capacidad">Valor para la capacidad </param>
        public Baul(ETipoDeMaterial tipoDeMaterial, double alto, double largo, string capacidad) : base(tipoDeMaterial, alto, largo)
        {
            this.capacidad = capacidad;
        }

        /// <summary>
        /// Metodo para informar los datos del baul.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Con una capacidad de : {Capacidad}");
            return sb.ToString();
        }
    }
}