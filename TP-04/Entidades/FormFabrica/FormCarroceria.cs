using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormFabrica
{
    public partial class FormCarroceria : FormAutoParte
    {
        private Carroceria carroceria;

        /// <summary>
        /// Constructor
        /// </summary>
        public FormCarroceria()
        {
            InitializeComponent();
            lblTexto.Text = "Ingrese el tipo de carroceria. " +
            "Ej: Coupé o SUV";
        }

        /// <summary>
        /// Propiedad de lectura que devolvera una  carroceria.
        /// </summary>
        public Carroceria CarroceriaForm
        {
            get
            {
                return this.carroceria;
            }
        }

        /// <summary>
        /// Propiedad override para obtener la instancia del form.
        /// </summary>
        public override AutoParte AutoParteDelForm
        {
            get { return this.CarroceriaForm; }
        }

        /// <summary>
        /// Metodo que creara una nueva autoparte cuando se realice click en Aceptar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btn_Aceptar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbAltura.Text) && !String.IsNullOrWhiteSpace(tbLargo.Text))
            {
                this.carroceria = new Carroceria((ETipoDeMaterial)Enum.Parse(typeof(ETipoDeMaterial), cmbMateriales.Text), double.Parse(tbAltura.Text), double.Parse(tbLargo.Text), txbDescripcion.Text);
                base.btn_Aceptar_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Verifique los datos ingresados.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
