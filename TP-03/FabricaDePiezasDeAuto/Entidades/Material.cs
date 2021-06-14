using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class Material
    {
        private double height;//Altura
        private double long_; //Largo
        private double width; //Ancho
        private double density;
        private Tipo type;

        public Tipo Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
        public double Density
        {
            get
            {
                return this.density;
            }
            set
            {
                if (value > 0)
                {
                    this.density
                        = value;
                }
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value > 0)
                {
                    this.height = value;
                }
            }
        }
        public double Long
        {
            get
            {
                return this.long_;
            }
            set
            {
                if (value > 0)
                {
                    this.long_ = value;
                }
            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value > 0)
                {
                    this.width = value;
                }
            }
        }

        /// <summary>
        /// Metodo static que indicara si hay material para realizar el corte solicitado.
        /// </summary>
        /// <param name="item">Material al cual se le realizara el corte</param>
        /// <param name="altura">Altura indicada para realizar el corte.</param>
        /// <param name="largo">Largo indicado para realizar el corte.</param>
        /// <returns></returns>
        public static bool ThereIsEnoughMaterial2(Material item, double altura, double largo)
        {
            bool output = false;
            try
            {
                if (item.Height > altura && item.Long > largo)
                {
                    item.Height = item.Height - altura;
                    item.Long = item.Long - largo;
                    output = true;
                }
                else
                {
                    throw new MaterialException("No hay material suficiente.");
                }
            }
            catch (MaterialException e)
            {
                throw new MaterialException(e.Message);
            }
            return output;
        }

        public Material(Tipo type, double height, double long_, double weight, double density)
        {
            this.type = type;
            this.height = height;
            this.long_ = long_;
            this.width = weight;
            this.density = density;
        }

        public string Show()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Type: {0}\n", this.type.ToString());
            sb.AppendFormat("Height: {0}\n", Height);
            sb.AppendFormat("Long: {0}\n", Long);
            sb.AppendFormat("Width: {0}\n", Width);
            sb.AppendFormat("Density: {0}\n", Density);
            return sb.ToString();
        }
        public Material() { }
    }
}
