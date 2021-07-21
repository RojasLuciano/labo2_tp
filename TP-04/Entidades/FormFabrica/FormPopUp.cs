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


    public partial class FormPopUp : Form
    {

        public FormPopUp(string lbl,string btnText1, string btnText2)
        {
            InitializeComponent();
            this.lblInformacion.Text = lbl;
            this.btnOption1.Text = btnText1;
            this.btnOption2.Text = btnText2;
           
        }

        public string OptionSelected { get ; set; }

        private void btnOption1_Click(object sender, EventArgs e)
        {
            OptionSelected = btnOption1.Text;
            this.Close();
        }

        private void btnOption2_Click(object sender, EventArgs e)
        {
            OptionSelected = btnOption2.Text;
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult output = MessageBox.Show("¿Está seguro de salir?", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (output == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
