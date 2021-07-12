using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Material
    {
        private double largo;
        private double ancho;
        private double alto;
        private double densidad; //densidad acero 7850 | densidad aluminio 2700
        private ETipoDeMaterial tipoDeMaterial;

        /// <summary>
        /// Constructor
        /// </summary>
        public Material()
        {

        }

        /// <summary>
        /// Constructor con parametros.
        /// </summary>
        /// <param name="tipoDeMaterial"></param>
        /// <param name="alto"></param>
        /// <param name="largo"></param>
        /// <param name="ancho"></param>
        /// <param name="densidad"></param>
        public Material(ETipoDeMaterial tipoDeMaterial, double alto, double largo, double ancho, double densidad)
        {
            this.TipoDeMaterial = tipoDeMaterial;
            this.Largo = largo;
            this.Ancho = ancho;
            this.Alto = alto;
            this.Densidad = densidad;
        }

        /// <summary>
        /// Propiedad de lectura y escritura de la variable largo
        /// </summary>
        public double Largo
        {
            get => largo;
            set => largo = value;
        }

        /// <summary>
        /// Propiedad de lectura y escritura de la variable ancho
        /// </summary>
        public double Ancho
        {
            get => ancho;
            set => ancho = value;
        }

        /// <summary>
        /// Propiedad de lectura y escritura de la variable alto
        /// </summary>
        public double Alto
        {
            get => alto;
            set => alto = value;
        }

        /// <summary>
        /// Propiedad de lectura y escritura de la variable densidad
        /// </summary>
        public double Densidad
        {
            get => densidad;
            set => densidad = value;
        }

        /// <summary>
        /// Propiedad de lectura y escritura de la variable tipoDeMaterial
        /// </summary>
        public ETipoDeMaterial TipoDeMaterial
        {
            get => tipoDeMaterial;
            set => tipoDeMaterial = value;
        }

        /// <summary>
        /// Metodo para informar el material.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"TipoDeMaterial : {TipoDeMaterial}");
            sb.AppendLine($"Largo : {Largo}");
            sb.AppendLine($"Alto : {Alto}");
            sb.AppendLine($"Ancho : {Ancho}");
            sb.AppendLine($"Densidad : {Densidad}");

            return sb.ToString();
        }

    }
}