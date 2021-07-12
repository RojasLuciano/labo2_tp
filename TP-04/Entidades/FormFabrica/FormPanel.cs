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
    public partial class FormPanel : FormAutoParte
    {
        //Tuve que poner la referencia asi, por que ya existe algo de Panel windows form
        private Entidades.Entidades.Herencia.Panel panel;


        /// <summary>
        /// Constructor
        /// </summary>
        public FormPanel()
        {
            InitializeComponent();
            lblTexto.Text = "Ingrese el lado para el panel. " +
           "Ej: Derecho Delantero.";
        }

        /// <summary>
        /// Propiedad de lectura que devolvera un chasis
        /// </summary>
        public Entidades.Entidades.Herencia.Panel PanelForm
        {
            get
            {
                return this.panel;
            }
        }

        /// <summary>
        /// Propiedad override para obtener la instancia del form.
        /// </summary>
        public override AutoParte AutoParteDelForm
        {
            get { return this.PanelForm; }
        }

        /// <summary>
        /// Metodo que creara una nueva autoparte cuando se realice click en Aceptar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btn_Aceptar_Click(object sender, EventArgs e)
        {
            this.panel = new Entidades.Entidades.Herencia.Panel((ETipoDeMaterial)Enum.Parse(typeof(ETipoDeMaterial), cmbMateriales.Text), double.Parse(tbAltura.Text), double.Parse(tbLargo.Text), txbDescripcion.Text);
            base.btn_Aceptar_Click(sender, e);
        }

        protected override void tbLargo_TextChanged(object sender, EventArgs e)
        {
            base.tbLargo_TextChanged(sender, e);
        }

    }
}
