
using Entidades;
using Entidades.Entidades.Herencia;
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
    public partial class FormPuerta : FormAutoParte
    {
        private Puerta puerta;

        /// <summary>
        /// Constructor
        /// </summary>
        public FormPuerta()
        {
            InitializeComponent();
            lblTexto.Text = "Ingrese el lado para la puerta. " +
                "Ej: Derecha Delantera.";

        }

        /// <summary>
        /// Propiedad de lectura que devolvera la instancia del form.-
        /// </summary>
        public Puerta PuertaForm
        {
            get
            {
                return this.puerta;
            }
        }

        /// <summary>
        /// Metodo override que devulve la instancia actual del form.
        /// </summary>
        public override AutoParte AutoParteDelForm
        {
            get { return this.PuertaForm; }
        }

        /// <summary>
        /// ;Metodo que fabricara una nueva pieza cuando presione Aceptar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btn_Aceptar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbAltura.Text) && !String.IsNullOrWhiteSpace(tbLargo.Text))
            {

                this.puerta = new Puerta((ETipoDeMaterial)Enum.Parse(typeof(ETipoDeMaterial), cmbMateriales.Text), double.Parse(tbAltura.Text), double.Parse(tbLargo.Text), txbDescripcion.Text);
                base.btn_Aceptar_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Verifique los datos ingresados.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
