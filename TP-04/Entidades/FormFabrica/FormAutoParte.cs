using Entidades;
using Entidades.Entidades.Files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormFabrica
{
    public partial class FormAutoParte : Form
    {
        protected Logger logger;

        /// <summary>
        /// MEtodo virtual para obtener las distintas autopartes forms.
        /// </summary>
        public virtual AutoParte AutoParteDelForm
        {
            get;
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public FormAutoParte()
        {
            InitializeComponent();

            logger = new Logger(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Logging.txt");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        /// <summary>
        /// Metodo Load del formulario, cargara los datos del enumerado al combox de materiales.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAutoParte_Load(object sender, EventArgs e)
        {
            this.cmbMateriales.DataSource = Enum.GetValues(typeof(ETipoDeMaterial));
        }

        /// <summary>
        /// Metodo para prevenir que se ingresen distintos valores 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbAltura_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(this.tbAltura.Text, "[^0-9]"))
                {
                    MessageBox.Show("Solo se admiten numeros", "Advertencia.");
                    tbAltura.Text = tbAltura.Text.Remove(tbAltura.Text.Length - 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Las medidas no puedan estar vacias.", "Advertencia.");
                logger.saveReport(ex);
            }

          
        }

        /// <summary>
        /// Metodo para prevenir que se ingresen distintos valores 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void tbLargo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(tbLargo.Text, "[^0-9]") || string.IsNullOrWhiteSpace(tbLargo.Text))
                {
                    MessageBox.Show("Solo se admiten numeros", "Advertencia.");
                    tbLargo.Text = tbLargo.Text.Remove(tbLargo.Text.Length - 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Las medidas no puedan estar vacias.", "Advertencia.");
                logger.saveReport(ex);
            }
        }

        /// <summary>
        /// Metodo que cerrara el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Está seguro de salir?", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (rta == DialogResult.OK)
            {
                this.Close();
            }
        }

        /// <summary>
        /// MEtodo para maximizar la ventana actual del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        /// <summary>
        /// MEtodo para minimizar la ventana actual del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// MEtodo para restarurar la ventana actual del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }

        /// <summary>
        /// MEtodo para el boton aceptar y sus derivados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void btn_Aceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}