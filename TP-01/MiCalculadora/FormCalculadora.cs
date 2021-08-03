using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;


namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {


        public FormCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Metodo para actualizar los valores a "0" ó limpiar. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Metodo privado que actualiza el label de resultados, los campos numericos.
        /// </summary>
        private void Limpiar()
        {
            this.lblResultado.Text ="0";
            this.txtNumero1.Text = "0";
            this.txtNumero2.Text = "0";
        }

        /// <summary>
        /// Metodo que realiza la operacion Operar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numeroUno = txtNumero1.Text.Replace('.', ',');
            string numeroDos = txtNumero2.Text.Replace('.', ',');
            string operador = cmbOperador.Text;
            double resultado = Operar(numeroUno, numeroDos, operador);

            if (operador.Equals("/") && resultado.Equals(Double.MinValue))
            {
                MessageBox.Show("No se puede dividir por cero.");
            }
            else
            {
                lblResultado.Text = resultado.ToString();
                btnConvertirABinario.Enabled = true;
                btnConvertirADecimal.Enabled = false;
                if (!lblResultado.Visible)
                {
                    lblResultado.Visible = true;
                }
            }

        }


        /// <summary>
        /// Recibe dos numeros en formato string y realiza las operaciones
        /// relacionadas al operador para devolver un resultado producto de la operación
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero numeroUno = new Numero(numero1);
            Numero numeroDos = new Numero(numero2);
            double resultado = Calculadora.Operar(numeroUno, numeroDos, operador);
            return resultado;
        }


        /// <summary>
        /// Metodo para cerrar wl formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
            {
                this.Close();
            }

        /// <summary>
        /// Convierte el valor binario a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
            {
            Numero numero = new Numero();
            string resultado = numero.BinarioDecimal(lblResultado.Text);
            lblResultado.Text = resultado;
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = false;
             }

        /// <summary>
        /// Convierte el resultado de la operacion en binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
            {
            Numero numero = new Numero();
            string resultado = numero.DecimalBinario(lblResultado.Text);
            lblResultado.Text = resultado;
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = true;
        }


        }
    }
