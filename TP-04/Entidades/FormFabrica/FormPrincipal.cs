using Entidades;
using Entidades.Entidades.Files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;
using System.IO;
using System.Threading;
using Entidades.Entidades.Herencia;

namespace FormFabrica
{ 
    /// <summary>
    /// Delegado para actualizar la lista de auto partes.
    /// </summary>
    public delegate void ActualizarListaDePiezas();
    public partial class FormPrincipal : Form
    {
        private Fabrica fabrica;
        private Logger logger;
        Thread actualizadorDgvMateriales;

        /// <summary>
        /// Evento encargado de actualizar los datos de la lista de autopartes.
        /// </summary>
        public event ActualizarListaDePiezas actualizarDato;

        public FormPrincipal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.fabrica = new Fabrica("Mi fábrica");
            this.Text = "Fábrica";
            actualizadorDgvMateriales = new Thread(this.Actualizar);
            logger = new Logger(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Logging.txt");
            FormatoParaDataGridViewMateriales(fabrica);

            CreacionAutomaticaDeMateriales(); // Cargar una lista hardcodiada.
        }

        /// <summary>
        /// Metodo encargado de invocar el hilo que se encarga de actualizar un datagrid.
        /// </summary>
        public void Actualizar()
        {
            try
            {
                while (true)
                {
                    if (this.dgvListMaterials.InvokeRequired)
                    {
                        this.dgvListMaterials.BeginInvoke((MethodInvoker)delegate ()
                        {
                            dgvListMaterials.DataSource = fabrica.Materiales;
                            dgvListMaterials.Refresh();
                        });
                    }
                    else
                    {
                        FormatoParaDataGridViewMateriales(fabrica);
                    }
                    Thread.Sleep(2000);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.saveReport(ex);
            }
        }

        /// <summary>
        /// Metodo para actualizar la lista de auto partes.
        /// </summary>
        public void ActualizarListaDeAutoPartes()
        {
            dgvListPieces.DataSource = null;
            dgvListPieces.DataSource = fabrica.AutoPartes;
            FormatoParaDataGridViewAutoParte();
        }

        /// <summary>
        /// Metodo load, realiza acciones sobre los datagrids.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            dgvListMaterials.ClearSelection();
            dgvListMaterials.Refresh();
            dgvListPieces.ClearSelection();
            dgvListPieces.Refresh();
        }

        /// <summary>
        /// CREACION DE LISTA PARA PRUEBAS.
        /// </summary>
        private void CreacionAutomaticaDeMateriales()
        {
            Fabrica miFabrica = new Fabrica("eee");
            miFabrica.Materiales.Add(new Material(ETipoDeMaterial.Acero, 50, 50, 5, 7850));
            miFabrica.Materiales.Add(new Material(ETipoDeMaterial.Aluminio, 50, 50, 5, 7850));

            double largoParte = 2;
            double AltoParte = 2;

                for (int i = 0; i < 5; i++)
                {
                    if (Fabrica.HayMaterialSuficiente(miFabrica.DoyMaterial(ETipoDeMaterial.Acero), largoParte, AltoParte) && Fabrica.HayMaterialSuficiente(miFabrica.DoyMaterial(ETipoDeMaterial.Aluminio), largoParte, AltoParte))
                    {

                        Chasis chasis = new Chasis(ETipoDeMaterial.Acero, largoParte, AltoParte, "Compacto");
                        Chasis chasis1 = new Chasis(ETipoDeMaterial.Aluminio, largoParte, AltoParte, "Monocausico");

                        Puerta puerta = new Puerta(ETipoDeMaterial.Acero, largoParte, AltoParte, "Delantera derecha");
                        Puerta puerta1 = new Puerta(ETipoDeMaterial.Aluminio, largoParte, AltoParte, "Delantera izquierda");

                        Entidades.Entidades.Herencia.Panel panel = new Entidades.Entidades.Herencia.Panel(ETipoDeMaterial.Acero, largoParte, AltoParte, "Delantero derecho");
                        Entidades.Entidades.Herencia.Panel panel1 = new Entidades.Entidades.Herencia.Panel(ETipoDeMaterial.Aluminio, largoParte, AltoParte, "Delantero izquierdo");

                        Carroceria carroceria = new Carroceria(ETipoDeMaterial.Acero, largoParte, AltoParte, "SUV");
                        Carroceria carroceria1 = new Carroceria(ETipoDeMaterial.Aluminio, largoParte, AltoParte, "Coupe");

                        Capot capot = new Capot(ETipoDeMaterial.Acero, largoParte, AltoParte, "Apertura trasera");
                        Capot capot1 = new Capot(ETipoDeMaterial.Aluminio, largoParte, AltoParte, "Apertura delantera");

                        Baul baul = new Baul(ETipoDeMaterial.Acero, largoParte, AltoParte, "101 litros");
                        Baul baul1 = new Baul(ETipoDeMaterial.Aluminio, largoParte, AltoParte, "500 litros");

                        if (miFabrica + chasis)
                        
                        if (miFabrica + chasis1)
                       
                        if (miFabrica + puerta)
                       
                        if (miFabrica + puerta1)
                       
                        if (miFabrica + carroceria)
                      
                        if (miFabrica + carroceria1)
                       
                        if (miFabrica + capot)
                       
                        if (miFabrica + capot1)
                        
                        if (miFabrica + baul)
                        
                        if (miFabrica + baul1)
                        
                        if (miFabrica + panel)
                        
                        if (miFabrica + panel1);
                    }
                }
            Fabrica.Save(miFabrica, "datosDePrueba.xml");
        }

        /// <summary>
        /// MEtodo que se encarga de dar formato al datagrid de materiales.
        /// </summary>
        /// <param name="f"></param>
        private void FormatoParaDataGridViewMateriales(Fabrica f)
        {
            try
            {
                dgvListMaterials.DataSource = null;
                dgvListMaterials.DataSource = f.Materiales;
                dgvListMaterials.ClearSelection();
                dgvListMaterials.Refresh();
                dgvListMaterials.AutoResizeColumns();
                dgvListMaterials.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvListMaterials.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvListMaterials.ReadOnly = true;
                dgvListMaterials.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvListMaterials.AllowUserToResizeColumns = false;
                dgvListMaterials.AllowUserToOrderColumns = false;
                dgvListMaterials.RowHeadersVisible = false;
                dgvListMaterials.Columns["largo"].HeaderText = "Largo";
                dgvListMaterials.Columns["ancho"].HeaderText = "Ancho";
                dgvListMaterials.Columns["alto"].HeaderText = "Alto";
                dgvListMaterials.Columns["densidad"].HeaderText = "Densidad";
                dgvListMaterials.Columns["tipoDeMaterial"].HeaderText = "Tipo";
                dgvListMaterials.Columns["tipoDeMaterial"].DisplayIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.saveReport(ex);
            }
        }

        /// <summary>
        /// MEtodo que se ecnarga de dar formato al data grid de auto partes.
        /// </summary>
        private void FormatoParaDataGridViewAutoParte()
        {
            try
            {
                dgvListPieces.AutoResizeColumns();
                dgvListPieces.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvListPieces.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvListPieces.ReadOnly = true;
                dgvListPieces.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvListPieces.AllowUserToResizeColumns = false;
                dgvListPieces.AllowUserToOrderColumns = false;
                dgvListPieces.RowHeadersVisible = false;
                dgvListPieces.Columns["Tipo"].HeaderText = "Tipo";
                dgvListPieces.Columns["Tipo"].DisplayIndex = 0;
                dgvListPieces.Columns["TipoDeMaterial"].HeaderText = "TipoDeMaterial";
                dgvListPieces.Columns["TipoDeMaterial"].DisplayIndex = 1;
                dgvListPieces.Columns["NumeroDeSerie"].HeaderText = "NumeroDeSerie";
                dgvListPieces.Columns["NumeroDeSerie"].DisplayIndex = 2;
                dgvListPieces.Columns["Largo"].HeaderText = "Largo";
                dgvListPieces.Columns["Largo"].DisplayIndex = 3;
                dgvListPieces.Columns["Alto"].HeaderText = "Alto";
                dgvListPieces.Columns["Alto"].DisplayIndex = 4;
                dgvListPieces.Columns["Peso"].HeaderText = "Peso";
                dgvListPieces.Columns["Peso"].DisplayIndex = 5;
                dgvListPieces.Columns["EstaDefectuoso"].HeaderText = "Defectuoso";
                dgvListPieces.Columns["EstaDefectuoso"].DisplayIndex = 6;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.saveReport(ex);
            }
        }
        /// <summary>
        /// Metodo encargado de cargar un xml.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargarXML_Click(object sender, EventArgs e)
        {
            try
            {
                if (fabrica.Materiales.Count != 0)
                    throw new FileException("No puede recargar una lista nueva, aún posee material disponible.");

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.fabrica = Fabrica.Read(openFileDialog.SafeFileName);
                    this.Text = "Fábrica " + this.fabrica.NombreFabrica;
                    MessageBox.Show("Se cargó el archivo correctamente!", "Cargado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (!(this.actualizadorDgvMateriales is null) && !actualizadorDgvMateriales.IsAlive)
                {
                    actualizadorDgvMateriales.Start();
                }
                else
                {
                    actualizadorDgvMateriales.Abort();
                }
                actualizarDato += ActualizarListaDeAutoPartes;
                actualizarDato.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.saveReport(ex);
            }
        }

        /// <summary>
        /// Metodo encargado de serializar los datos actuales a xml.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_GuardarXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 
            saveFileDialog.Filter = "Archivos XML|*.xml|Todos los archivos|*.*";

            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Fabrica.Save(this.fabrica, saveFileDialog.FileName);
                    MessageBox.Show($"Se guardaron los datos en {saveFileDialog.FileName}", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FileException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.saveReport(ex);
            }
        }

        /// <summary>
        /// MEtodo principal para la creacion de piezas, segun su indice del combox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTipoDeAutoParte_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormAutoParte frm = null;
            try
            {
                if (fabrica.Materiales.Count == 0)
                    throw new Exception("No hay materiales cargados.");

                switch (cmbTipoDeAutoParte.SelectedIndex)
                {
                    case 0:
                        frm = new FormPuerta();
                        break;
                    case 1:
                        frm = new FormPanel();
                        break;
                    case 2:
                        frm = new FormChasis();
                        break;
                    case 3:
                        frm = new FormCarroceria();
                        break;
                    case 4:
                        frm = new FormCapot();
                        break;
                    case 5:
                        frm = new FormBaul();
                        break;
                }
                frm.StartPosition = FormStartPosition.CenterScreen;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (this.fabrica.MaterialSuficiente(frm.AutoParteDelForm) && this.fabrica + frm.AutoParteDelForm)
                    {
                        actualizarDato += ActualizarListaDeAutoPartes;
                        actualizarDato.Invoke();
                        MessageBox.Show("Se fabricó correctamente!", "Fabricado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
                logger.saveReport(ex);
            }
        }

        /// <summary>
        /// Metodo que cerrara la aplicacion y desasociara los eventos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult output = MessageBox.Show("¿Está seguro de salir?", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (output == DialogResult.OK)
            {
                actualizarDato -= ActualizarListaDeAutoPartes;
                Application.Exit();
            }
        }

        /// <summary>
        /// Metodo encargado de maximizar la ventana actual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        /// <summary>
        /// MEtodo encargado de restaurar la ventana actual.
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
        /// Metodo encargado de minimizar la ventana actual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Metodo encargado de generar un reporte en formato pdf.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Reporte_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("Se genero el reporte en {0}", fabrica.GenerarReporte()), "WARNING.");
        }

        /// <summary>
        /// Metodo encargado de eliminar una pieza de la fabrica y de la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                AutoParte aux = dgvListPieces.CurrentRow.DataBoundItem as AutoParte;
                DialogResult rta = MessageBox.Show(string.Format("Esta seguro de elimnar de la lista:  {0}", aux.ToString()), "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (rta == DialogResult.OK)
                {
                    if (fabrica - aux && fabrica.DeletePartFromDB(aux.NumeroDeSerie))
                    {
                        actualizarDato += ActualizarListaDeAutoPartes;
                        actualizarDato.Invoke();
                        MessageBox.Show("Se elimino de la lista la autoParte defectuosa", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.saveReport(ex);
            }
        }        

        /// <summary>
        /// MEtodo que actualizara la propiedad de una pieza.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvListPieces.Columns["estaDefectuoso"].Index ==
            e.ColumnIndex && e.RowIndex >= 0)
                {
                    dgvListPieces.CurrentCell.Value = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.saveReport(ex);
            }
        }

        /// <summary>
        /// Metodo encargado de abrir el combox en caso de hacer click alrededor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.cmbTipoDeAutoParte.DroppedDown = true;
        }
        /// <summary>
        /// Metodo encargago de obtener los datos desde la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (fabrica.Materiales.Count != 0)
                    throw new FileException("No puede recargar una lista nueva, aún posee material disponible.");

                fabrica.GetMaterialsFromDB();


                if (fabrica.AutoPartes.Count != 0)
                    throw new FileException("No puede recargar una lista nueva, aún posee material disponible.");

                fabrica.GetAutoPartesFromDB();

                actualizarDato += ActualizarListaDeAutoPartes;
                actualizarDato.Invoke();

                if (!(this.actualizadorDgvMateriales is null) && !actualizadorDgvMateriales.IsAlive)
                {
                    actualizadorDgvMateriales.Start();
                }
                else
                {
                    actualizadorDgvMateriales.Abort();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Metodo encargado de exportar los datos hacia la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (fabrica.Materiales.Count == 0)
                    throw new FileException("No Hay datos para exportar");

                fabrica.ExportMaterialsToDB();


                if (fabrica.AutoPartes.Count == 0)
                    throw new FileException("No Hay datos para exportar");

                fabrica.ExportAutoPartsToDB();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }
    }
}
