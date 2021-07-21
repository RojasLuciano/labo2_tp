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
    public partial class FormBaul : FormAutoParte
    {
        private Baul baul;

        /// <summary>
        /// Constructor 
        /// </summary>
        public FormBaul()
        {
            InitializeComponent();
          
            lblTexto.Text = "Ingrese la capacidad del baul." +
              "Ej: 407 litros";
        }

        /// <summary>
        /// Propiedad de lectura que devolvera un baul.
        /// </summary>
        public Baul BaulForm
        {
            get
            {
                return this.baul;
            }
        }

        /// <summary>
        /// Propiedad override para obtener la instancia del form.
        /// </summary>
        public override AutoParte AutoParteDelForm
        {
            get
            {
                return this.BaulForm;
            }
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
                this.baul = new Baul((ETipoDeMaterial)Enum.Parse(typeof(ETipoDeMaterial), cmbMateriales.Text), double.Parse(tbAltura.Text), double.Parse(tbLargo.Text), txbDescripcion.Text);
                base.btn_Aceptar_Click(sender, e);
            }
            else 
            {
                MessageBox.Show("Verifique los datos ingresados.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}