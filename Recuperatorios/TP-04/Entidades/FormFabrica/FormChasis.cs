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
    public partial class FormChasis : FormAutoParte
    {
        private Chasis chasis;


        /// <summary>
        /// Constructor
        /// </summary>
        public FormChasis()
        {
            InitializeComponent();
            lblTexto.Text = "Ingrese el tipo de chasis. " +
           "Ej: Chasis monocasco o compacto";
        }

        /// <summary>
        /// Propiedad de lectura que devolvera un chasis
        /// </summary>
        public Chasis ChasisForm
        {
            get
            {
                return this.chasis;
            }
        }

        /// <summary>
        /// Propiedad override para obtener la instancia del form.
        /// </summary>
        public override AutoParte AutoParteDelForm
        {
            get { return this.ChasisForm; }
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
                    this.chasis = new Chasis((ETipoDeMaterial)Enum.Parse(typeof(ETipoDeMaterial), cmbMateriales.Text), double.Parse(tbAltura.Text), double.Parse(tbLargo.Text), txbDescripcion.Text);
                    base.btn_Aceptar_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Verifique los datos ingresados.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
    }
}
