using Entidades.Entidades.Herencia;
using Entidades.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{

    [XmlInclude(typeof(Chasis))]
    [XmlInclude(typeof(Puerta))]
    [XmlInclude(typeof(Panel))]
    [XmlInclude(typeof(Carroceria))]
    [XmlInclude(typeof(Capot))]
    [XmlInclude(typeof(Baul))]
    public class AutoParte
    {
        protected string numeroDeSerie;
        protected static Random random;
        protected double largo;
        protected double alto;
        protected double peso;
        protected ETipoDeMaterial tipoDeMaterial;
        protected bool estaDefectuosa;

        /// <summary>
        /// Propiedad de lectura y escritura para la variable estaDefectuosa
        /// </summary>
        public bool EstaDefectuoso
        {
            get
            {
                return this.estaDefectuosa;
            }
            set
            {
                this.estaDefectuosa = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para la variable largo
        /// </summary>
        public double Largo
        {
            get => largo;
            set => largo = value;
        }


        /// <summary>
        /// Propiedad de lectura y escritura para la variable alto
        /// </summary>
        public double Alto
        {
            get => alto;
            set => alto = value;
        }

        /// <summary>
        /// Propiedad de lectura y escritura para la variable peso
        /// </summary>
        public double Peso
        {
            get => peso;
            set => peso = value;
        }

        /// <summary>
        /// Propiedad de lectura y escritura para la variable numeroDeSerie
        /// </summary>
        public string NumeroDeSerie
        {
            get => numeroDeSerie;
            set => numeroDeSerie = value;
        }

        /// <summary>
        /// Propiedad de lectura y escritura para la variable tipoDeMaterial
        /// </summary>
        public ETipoDeMaterial TipoDeMaterial
        {
            get => tipoDeMaterial;
            set => tipoDeMaterial = value;
        }

        /// <summary>
        /// Metodo para generar un numero de serie, compuesto por letras y numeros.
        /// </summary>
        /// <returns></returns>
        public static string GeneraUnNumeroDeSerie()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            String r = new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray());
            return r + random.Next(0, 1000000).ToString("D6");
        }

        /// <summary>
        /// Constructor statico que inicializara el numero random.
        /// </summary>
        static AutoParte()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor sin parametros.
        /// </summary>
        public AutoParte() { }

        /// <summary>
        /// Propiedad de lectura para obtener el nombre de la clase.
        /// </summary>
        public string Tipo
        {
            get
            {
                return this.GetType().Name;
            }
        }

        /// <summary>
        /// Constructor con parametros.
        /// </summary>
        /// <param name="tipoDeMaterial"></param>
        /// <param name="alto"></param>
        /// <param name="largo"></param>
        public AutoParte(ETipoDeMaterial tipoDeMaterial, double alto, double largo)
        {
            this.tipoDeMaterial = tipoDeMaterial;
            this.numeroDeSerie = GeneraUnNumeroDeSerie();
            this.largo = largo;
            this.alto = alto;
            this.estaDefectuosa = false;
        }

        /// <summary>
        /// Metodo para mostrar la informacion de la auto parte.
        /// </summary>
        /// <returns></returns>
        public string AutoParteInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Tipo: {this.Tipo}");
            sb.AppendLine($"Número de serie: {NumeroDeSerie}");
            sb.AppendLine($"Código fabricante: {NumeroDeSerie.ObtenerCodigoFabricante()}");
            sb.AppendLine($"Tipo de Material: {TipoDeMaterial}");
            sb.AppendLine($"Largo: {Largo}");
            sb.AppendLine($"Alto: {Alto}");
            sb.AppendLine($"Peso: {Peso}");
            sb.Append($"Defectuoso: {EstaDefectuoso}");

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.AutoParteInfo();
        }

    }
}