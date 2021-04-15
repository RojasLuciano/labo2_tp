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
using Support;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        Numero numeroUno;
        Numero numeroDos;
        string operador;
        double resultado = 0;


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
        /// Metodo privado que actualiza el label de resultados, los campos numericos, y agrega los operadores como item.
        /// </summary>
        private void Limpiar()
        {
            this.lblResultado.Text ="0";
            this.txtNumero1.Text = "0";
            this.txtNumero2.Text = "0";

            cmbOperador.Items.Clear();
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("*");
            cmbOperador.Items.Add("/");

        }

        /// <summary>
        /// Metodo que realiza la operacion Operar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string inputTxtUno = txtNumero1.Text;
            string inputTxtDos = txtNumero2.Text;

            if (Verificaciones.EsUnValorValido(inputTxtUno) && Verificaciones.EsUnValorValido(inputTxtDos))
            {
                numeroUno = new Numero(txtNumero1.Text);
                numeroDos = new Numero(txtNumero2.Text);
                operador = cmbOperador.Text;
                resultado = Calculadora.Operar(numeroUno, numeroDos, operador);
                if (operador.Equals("/") && resultado.Equals(Double.MinValue))
                {
                    MessageBox.Show("No se puede dividir por cero.");
                }
                else
                {
                    lblResultado.Text = Math.Round(resultado, 2).ToString();
                }
            }
            else
            {
                MessageBox.Show("Verifique los valores ingresados.");
            }

            }

            private static double Operar(string numero1, string numero2, string operador)
            {
                Numero n1 = new Numero(numero1);
                Numero n2 = new Numero(numero2);

                double resultado = Calculadora.Operar(n1, n2, operador);

                return resultado;
            }

            private void btnCerrar_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void btnConvertirADecimal_Click(object sender, EventArgs e)
            {
                if (this.lblResultado.Text != "Resultado" && this.lblResultado.Text != "Valor invalido")
                {
                    this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text);
                }
            }

            private void btnConvertirABinario_Click(object sender, EventArgs e)
            {
                if (this.lblResultado.Text != "Resultado")
                {
                    this.lblResultado.Text = Numero.DecimalBinario(this.lblResultado.Text);
                }
            }


        }
    }
