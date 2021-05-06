using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
  public  class Sedan : Vehiculo
    {
        public enum ETipo { CuatroPuertas, CincoPuertas }
        private  ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca">Valor para el atributo 'marca' con el cual se creara el objeto.</param>
        /// <param name="chasis">Valor para el atributo 'chasis' con el cual se creara el objeto.</param>
        /// <param name="color">Valor para el atributo 'color' con el cual se creara el objeto.</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            tipo = ETipo.CuatroPuertas;
        }

        /// <summary>
        /// Constructor sobrecargado que podra crear un objeto con otro TIPO
        /// </summary>
        /// <param name="marca">Valor para el atributo 'marca' con el cual se creara el objeto.</param>
        /// <param name="chasis">Valor para el atributo 'chasis' con el cual se creara el objeto.</param>
        /// <param name="color">Valor para el atributo 'color' con el cual se creara el objeto.</param>
        ///  <param name="tipo">Valor para el atributo 'tipo' con el cual se creara el objeto.</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : this(marca, chasis, color)
        {
            this.tipo = tipo;
        }


        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// Informara la informacion perteneciente al Sedan
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Sedan");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine($"TIPO : {this.tipo}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
    }
}
