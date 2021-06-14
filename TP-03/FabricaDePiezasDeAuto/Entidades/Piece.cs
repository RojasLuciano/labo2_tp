using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Piece
    {
        private double height;
        private double long_;
        private double width;
        private double weight;
        private Tipo type;
        private typeOfPartToCreate typeOfPartToCreate_;
        private bool estaCortado;
        private bool estaAgujereado;
        private bool estaMoldeado;
        private bool estaPintado;
        private bool estaSoldado;


        public typeOfPartToCreate TypeOfPartToCreate
        {
            get
            {
                return this.typeOfPartToCreate_;
            }
            set
            {
                this.typeOfPartToCreate_ = value;
            }
        }
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
        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value > 0)
                {
                    this.weight = value;
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
        public bool EstaCortado { get => estaCortado; set => estaCortado = value; }
        public bool EstaAgujereado { get => estaAgujereado; set => estaAgujereado = value; }
        public bool EstaMoldeado { get => estaMoldeado; set => estaMoldeado = value; }
        public bool EstaPintado { get => estaPintado; set => estaPintado = value; }
        public bool EstaSoldado { get => estaSoldado; set => estaSoldado = value; }

        public Piece() { }

        /// <summary>
        /// Constructor habilitado para la creacion de piezas.
        /// </summary>
        /// <param name="typeOfPartToCreate_">Parametro recibido de que parte se desea crear.</param>
        /// <param name="type">Parametro recibido que indica de que material se creara la pieza.</param>
        /// <param name="height">Altura de la pieza</param>
        /// <param name="long_">Largo de la pieza</param>
        /// <param name="width">Ancho de la pieza</param>
        /// <param name="weight">Peso de la pieza.</param>
        public Piece(typeOfPartToCreate typeOfPartToCreate_, Tipo type, double height, double long_, double width, double weight)
        {
            this.typeOfPartToCreate_ = typeOfPartToCreate_;
            this.type = type;
            this.height = height;
            this.long_ = long_;
            this.width = width;
            this.weight = weight;

        }
        /// <summary>
        /// Constructor habilitado para la creacion de piezas.
        /// </summary>
        /// <param name="typeOfPartToCreate_">Parametro recibido de que parte se desea crear.</param>
        /// <param name="type">Parametro recibido que indica de que material se creara la pieza.</param>
        /// <param name="height">Altura de la pieza</param>
        /// <param name="long_">Largo de la pieza</param>
        /// <param name="width">Ancho de la pieza</param>
        /// <param name="weight">Peso de la pieza.</param>
        /// <param name="estaCortada">Parametro recibido para indicar si la pieza se encuentra cortada.</param>
        public Piece(typeOfPartToCreate typeOfPartToCreate_, Tipo type, double height, double long_, double width, double weight, bool estaCortada) : this(typeOfPartToCreate_, type, height, long_, width, weight)
        {
            this.typeOfPartToCreate_ = typeOfPartToCreate_;
            this.type = type;
            this.height = height;
            this.long_ = long_;
            this.width = width;
            this.weight = weight;
            this.estaCortado = estaCortada;

        }

        /// <summary>
        /// Constructor habilitado para la creacion de piezas.
        /// </summary>
        /// <param name="typeOfPartToCreate_">Parametro recibido de que parte se desea crear.</param>
        /// <param name="type">Parametro recibido que indica de que material se creara la pieza.</param>
        /// <param name="height">Altura de la pieza</param>
        /// <param name="long_">Largo de la pieza</param>
        /// <param name="width">Ancho de la pieza</param>
        /// <param name="weight">Peso de la pieza.</param>
        /// <param name="estaCortada">Parametro recibido para indicar si la pieza se encuentra cortada.</param>
        /// <param name="estaMoldeado">Parametro recibido para indicar si la pieza se encuentra moldeada</param>
        public Piece(typeOfPartToCreate typeOfPartToCreate_, Tipo type, double height, double long_, double width, double weight, bool estaCortada, bool estaMoldeado) : this(typeOfPartToCreate_, type, height, long_, width, weight, estaCortada)
        {
            this.typeOfPartToCreate_ = typeOfPartToCreate_;
            this.type = type;
            this.height = height;
            this.long_ = long_;
            this.width = width;
            this.weight = weight;
            this.estaCortado = estaCortada;
            this.estaMoldeado = estaMoldeado;
        }

        /// <summary>
        /// Constructor habilitado para la creacion de piezas.
        /// </summary>
        /// <param name="typeOfPartToCreate_">Parametro recibido de que parte se desea crear.</param>
        /// <param name="type">Parametro recibido que indica de que material se creara la pieza.</param>
        /// <param name="height">Altura de la pieza</param>
        /// <param name="long_">Largo de la pieza</param>
        /// <param name="width">Ancho de la pieza</param>
        /// <param name="weight">Peso de la pieza.</param>
        /// <param name="estaCortada">Parametro recibido para indicar si la pieza se encuentra cortada.</param>
        /// <param name="estaMoldeado">Parametro recibido para indicar si la pieza se encuentra moldeada</param>
        /// <param name="estaAgujereado">Parametro recibido para indicar si la pieza se encuentra agujereada</param>
        public Piece(typeOfPartToCreate typeOfPartToCreate_, Tipo type, double height, double long_, double width, double weight, bool estaCortada, bool estaMoldeado, bool estaAgujereado) : this(typeOfPartToCreate_, type, height, long_, width, weight, estaCortada, estaMoldeado)
        {
            this.typeOfPartToCreate_ = typeOfPartToCreate_;
            this.type = type;
            this.height = height;
            this.long_ = long_;
            this.width = width;
            this.weight = weight;
            this.estaCortado = estaCortada;
            this.estaMoldeado = estaMoldeado;
            this.estaAgujereado = estaAgujereado;
        }

        /// <summary>
        /// Constructor habilitado para la creacion de piezas.
        /// </summary>
        /// <param name="typeOfPartToCreate_">Parametro recibido de que parte se desea crear.</param>
        /// <param name="type">Parametro recibido que indica de que material se creara la pieza.</param>
        /// <param name="height">Altura de la pieza</param>
        /// <param name="long_">Largo de la pieza</param>
        /// <param name="width">Ancho de la pieza</param>
        /// <param name="weight">Peso de la pieza.</param>
        /// <param name="estaCortada">Parametro recibido para indicar si la pieza se encuentra cortada.</param>
        /// <param name="estaMoldeado">Parametro recibido para indicar si la pieza se encuentra moldeada</param>
        /// <param name="estaAgujereado">Parametro recibido para indicar si la pieza se encuentra agujereada</param>
        /// <param name="estaPintado">Parametro recibido para indicar si la pieza se encuentra agujereada</param>
        public Piece(typeOfPartToCreate typeOfPartToCreate_, Tipo type, double height, double long_, double width, double weight, bool estaCortada, bool estaMoldeado, bool estaAgujereado, bool estaPintado) : this(typeOfPartToCreate_, type, height, long_, width, weight, estaCortada, estaMoldeado, estaAgujereado)
        {
            this.typeOfPartToCreate_ = typeOfPartToCreate_;
            this.type = type;
            this.height = height;
            this.long_ = long_;
            this.width = width;
            this.weight = weight;
            this.estaCortado = estaCortada;
            this.estaMoldeado = estaMoldeado;
            this.estaAgujereado = estaAgujereado;
            this.estaPintado = estaPintado;
        }

        /// <summary>
        /// Constructor habilitado para la creacion de piezas.
        /// </summary>
        /// <param name="typeOfPartToCreate_">Parametro recibido de que parte se desea crear.</param>
        /// <param name="type">Parametro recibido que indica de que material se creara la pieza.</param>
        /// <param name="height">Altura de la pieza</param>
        /// <param name="long_">Largo de la pieza</param>
        /// <param name="width">Ancho de la pieza</param>
        /// <param name="weight">Peso de la pieza.</param>
        /// <param name="estaCortada">Parametro recibido para indicar si la pieza se encuentra cortada.</param>
        /// <param name="estaMoldeado">Parametro recibido para indicar si la pieza se encuentra moldeada</param>
        /// <param name="estaAgujereado">Parametro recibido para indicar si la pieza se encuentra agujereada</param>
        /// <param name="estaPintado">Parametro recibido para indicar si la pieza se encuentra agujereada</param>
        /// <param name="estaSoldado">Parametro recibido para indicar si la pieza se encuentra soldada</param>
        public Piece(typeOfPartToCreate typeOfPartToCreate_, Tipo type, double height, double long_, double width, double weight, bool estaCortada, bool estaMoldeado, bool estaAgujereado, bool estaPintado, bool estaSoldado) : this(typeOfPartToCreate_, type, height, long_, width, weight, estaCortada, estaMoldeado, estaAgujereado, estaPintado)
        {
            this.typeOfPartToCreate_ = typeOfPartToCreate_;
            this.type = type;
            this.height = height;
            this.long_ = long_;
            this.width = width;
            this.weight = weight;
            this.estaCortado = estaCortada;
            this.estaMoldeado = estaMoldeado;
            this.estaAgujereado = estaAgujereado;
            this.estaPintado = estaPintado;
            this.estaSoldado = estaSoldado;
        }

        /// <summary>
        /// Informara las especificaciones de cada pieza.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("typeOfPart: {0}\n", this.typeOfPartToCreate_.ToString());
            sb.AppendFormat("Type: {0}\n", this.type.ToString());
            sb.AppendFormat("Height: {0}\n", Height);
            sb.AppendFormat("Long: {0}\n", Long);
            sb.AppendFormat("Width: {0}\n", Width);
            sb.AppendFormat("Weight: {0} KG\n", Weight);
            sb.AppendFormat("estaCortado: {0}\n", this.estaCortado);
            sb.AppendFormat("estaMoldeado: {0}\n", this.estaMoldeado);
            sb.AppendFormat("estaAgujereado: {0}\n", this.estaAgujereado);
            sb.AppendFormat("estaPintado: {0}\n", this.estaPintado);
            sb.AppendFormat("estaSoldado: {0}\n", this.estaSoldado);
            return sb.ToString();
        }



    }
}
