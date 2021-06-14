using Entidades;
using Files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{

        public partial class FormHome : Form
        {
            FormPiezas frmPiezas;
            Materiales listaDeMateriales;
            string message;
            string title;

            public FormHome()
            {
                InitializeComponent();
                CreacionAutomaticaDeMateriales();
            }

        private void CreacionAutomaticaDeMateriales() 
        {
            // Creacion de materiales.
            Materiales listaMateriales = new Materiales();
            listaMateriales.Items.Add(new Material(Tipo.Acero, 50, 50, 50, 7850));
            listaMateriales.Items.Add(new Material(Tipo.Aluminio, 50, 50, 50, 2700));
            //Serializo la lista de materiales.
            Serializer.SerializeToFile<Materiales>(listaMateriales, "listMaterials.xml");
        }

            private void FormHome_Load(object sender, EventArgs e)
            {
                listaDeMateriales = new Materiales();
                //this.ControlBox = false;
                this.Text = String.Empty;
                this.lblTextoFormHome.Text = "Bienvenido, seleccione la lista de materiales.";
                this.lblInstruccionesPiezas.Text = "En la seccion de piezas, las acciones a realizar sobre las piezas creadas.";
                message = "";
                title = "";
            }


        private void btnCargarListas_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = Serializer.GetDirectoryPath;
                openFileDialog.ShowDialog();

                string filename = openFileDialog.SafeFileName;
                listaDeMateriales = Serializer.DeserializeFromFile<Materiales>(filename);
                message = "Archivo cargado correctamente";
                title = "¡WARNING!";
            }
            catch (Exception ex)
            {
                message = ex.Message;
                title = "¡FAILED!";
            }
            finally
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK);
            }
        }

        private void btnPiezas_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaDeMateriales.Items.Count == 0)
                    throw new Exception("Debe cargar la lista de materiales.");

                frmPiezas = new FormPiezas(listaDeMateriales, this);
                frmPiezas.ShowDialog();
                this.Hide();

            }
            catch (Exception ex)
            {
                message = ex.Message;
                title = "¡FAILED!";
            }
            finally
            {
                MessageBox.Show(message, title);
            }
        }

        //private void btnPiezas_Click(object sender, EventArgs e)
        //{

        //    MessageBox.Show("---------FUNCIONA ");
        //    try
        //    {
        //        if (listaDeMateriales.Items.Count == 0)
        //            throw new Exception("Debe cargar la lista de materiales.");

        //    //    frmPiezas = new FormPiezas(listaDeMateriales, this);
        //        frmPiezas.ShowDialog();
        //        this.Hide();

        //    }
        //    catch (Exception ex)
        //    {
        //        message = ex.Message;
        //        title = "¡FAILED!";
        //    }
        //    finally
        //    {
        //        MessageBox.Show(message, title);
        //    }

        //}



    }
    
}
