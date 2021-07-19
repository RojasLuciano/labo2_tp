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
using NPOI.SS.Formula.Functions;
using System.Diagnostics;

namespace FormFabrica
{

    /// <summary>
    /// Delegado para actualizar las imagenes
    /// </summary>
    public delegate void DelegadoImagen(PictureBox pic, string rutaImagen);

    /// <summary>
    /// Delegado para actualizar la lista de auto partes.
    /// </summary>
    public delegate void DelegadoActualizarListas();
    public partial class FormPrincipal : Form
    {
        private Fabrica fabrica;
        private Logger logger;
        private Thread hiloActualizadorDeDatos;
        private Thread hiloPicAutoPartes;
        private Thread hiloContadorDePiezas;
        AutoParte aux;

        /// <summary>
        /// Evento encargado de actualizar las imagenes.
        /// </summary>
        public event DelegadoImagen eventoImagenes;


        /// <summary>
        /// Evento encargado de actualizar los datos de la lista de autopartes.
        /// </summary>
        public event DelegadoActualizarListas actualizarDatos;

        public FormPrincipal()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.fabrica = new Fabrica("Mi fábrica");
            this.Text = "Fábrica";
            aux = new AutoParte();

            hiloContadorDePiezas = new Thread(this.Actualizar);
            if (!this.hiloContadorDePiezas.IsAlive)
            {
                this.hiloContadorDePiezas.Start();
            }

            actualizarDatos += InformacionParaLosDataGrids;
            hiloActualizadorDeDatos = new Thread(this.ActualizadorDataGrids);
            if (!this.hiloActualizadorDeDatos.IsAlive)
            {
                this.hiloActualizadorDeDatos.Start();
            }

            this.eventoImagenes += this.MostrarImagen;
            this.hiloPicAutoPartes = new Thread(this.ImagenesCreacion);
            if (!this.hiloPicAutoPartes.IsAlive)
            {
                this.hiloPicAutoPartes.Start();
            }


            logger = new Logger(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Logging.txt");
        }

        public void Actualizar()
        {
            while (true)
            {
                if (this.lblCantidadDePiezas.InvokeRequired)
                {
                    this.lblCantidadDePiezas.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.lblCantidadDePiezas.Text = $"Cantidad de piezas creadas: {fabrica.AutoPartes.Count}";
                    }
                    );
                }
                else
                {
                    this.lblCantidadDePiezas.Text = $"Cantidad de piezas creadas: {fabrica.AutoPartes.Count}";
                }
                Thread.Sleep(2500);
            }

        }

        /// <summary>
        /// Metodo para actualizar las imagenes
        /// </summary>
        /// <param name="picB"></param>
        /// <param name="path"></param>
        private void MostrarImagen(PictureBox picB, string path)
        {
            picB.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + $@"\img\{path}";
        }

        /// <summary>
        /// Metodo para invocar al evento y pasarle la ruta de las imagenes.
        /// </summary>
        private void ImagenesCreacion()
        {
            try
            {
                do
                {
                    this.eventoImagenes.Invoke(this.pic, "capot.png");
                    Thread.Sleep(2500);
                    this.eventoImagenes.Invoke(this.pic, "door.png");
                    Thread.Sleep(2500);
                    this.eventoImagenes.Invoke(this.pic, "panel.png");
                    Thread.Sleep(2500);
                    this.eventoImagenes.Invoke(this.pic, "chasis.png");
                    Thread.Sleep(2500);
                } while (true);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.saveReport(ex);
            }
        }

        /// <summary>
        /// MEtodo que invoca al actualizador del datagrid.
        /// </summary>
        private void ActualizadorDataGrids()
        {
            while (true)
            {
                if (this.dgvListPieces.InvokeRequired)
                {
                    this.dgvListPieces.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.actualizarDatos.Invoke();
                    }
                    );
                }
                else
                {
                    this.actualizarDatos.Invoke();
                }
                Thread.Sleep(2500);
            }
        }


        /// <summary>
        /// Metodo encargado de invocar el hilo que se encarga de actualizar un datagrid.
        /// Nota: Si no pongo los formateadores para los datagrid, se les puede ingresar y modificar, cosa que rompen el proyecto, esto sucede por que si no le mando null al datagrid, este no se actualiza.
        /// </summary>
        public void InformacionParaLosDataGrids()
        {
            dgvListMaterials.DataSource = null; //tengo que darles null, por que de otra manera no se me actualizaba el datagrid :/.
            dgvListPieces.DataSource = null;
            dgvListMaterials.DataSource = fabrica.Materiales;
            dgvListPieces.DataSource = fabrica.AutoPartes;


            FormatoParaDataGridViewMateriales();
            FormatoParaDataGridViewAutoParte();
        }

        /// <summary>
        /// Metodo load, realiza acciones sobre los datagrids.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// CREACION DE LISTA PARA PRUEBAS.
        /// </summary>
        private void CreacionAutomaticaDeMateriales()
        {
            Fabrica miFabrica = new Fabrica("Test");
            miFabrica.Materiales.Add(new Material(ETipoDeMaterial.Acero, 500, 500, 5, 7850));
            miFabrica.Materiales.Add(new Material(ETipoDeMaterial.Aluminio, 500, 500, 5, 7850));
            Fabrica.Save(miFabrica, "datosDePrueba.xml");
        }

        /// <summary>
        /// MEtodo que se encarga de dar formato al datagrid de materiales.
        /// </summary>
        /// <param name="f"></param>
        private void FormatoParaDataGridViewMateriales()
        {
            try
            {
          
                dgvListMaterials.Refresh();
                dgvListMaterials.AutoResizeColumns();
                dgvListMaterials.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvListMaterials.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvListMaterials.ReadOnly = true;
                dgvListMaterials.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvListMaterials.AllowUserToResizeColumns = false;
                dgvListMaterials.AllowUserToOrderColumns = false;
                dgvListMaterials.RowHeadersVisible = false;

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
          
                dgvListPieces.Refresh();
                dgvListPieces.AutoResizeColumns();
                dgvListPieces.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvListPieces.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvListPieces.ReadOnly = false;
                dgvListPieces.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvListPieces.AllowUserToResizeColumns = false;
                dgvListPieces.AllowUserToOrderColumns = false;
                dgvListPieces.RowHeadersVisible = false;

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
                {
                    DialogResult rta = MessageBox.Show($"Si carga nuevamente el archivo, perdera el progreso actual.", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rta == DialogResult.OK)
                    {
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.fabrica = Fabrica.Read(openFileDialog.SafeFileName);
                            this.Text = "Fábrica " + this.fabrica.NombreFabrica;
                            MessageBox.Show("Se cargó el archivo correctamente!", "Cargado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.fabrica = Fabrica.Read(openFileDialog.SafeFileName);
                        this.Text = "Fábrica " + this.fabrica.NombreFabrica;
                        MessageBox.Show("Se cargó el archivo correctamente!", "Cargado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /// Metodo encargado de serializar los datos actuales a xml.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_GuardarXML_Click(object sender, EventArgs e)
        {
            if (fabrica.AutoPartes.Count == 0 && fabrica.Materiales.Count == 0)
            {
                MessageBox.Show("No hay materiales ni autopartes para guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog.Filter = "Archivos XML|*.xml|Todos los archivos|*.*";

                try
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo fi = new FileInfo(saveFileDialog.FileName);

                        Fabrica.Save(this.fabrica, fi.Name);
                        MessageBox.Show($"Se guardaron los datos en {saveFileDialog.FileName}", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (FileException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.saveReport(ex);
                }
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
                
                if (!this.hiloContadorDePiezas.IsAlive)
                {
                    this.hiloContadorDePiezas.Abort();
                }

                if (!this.hiloActualizadorDeDatos.IsAlive)
                {
                    this.hiloActualizadorDeDatos.Abort();
                }

                if (!this.hiloPicAutoPartes.IsAlive)
                {
                    this.hiloPicAutoPartes.Abort();
                }

                actualizarDatos -= FormatoParaDataGridViewAutoParte;
                actualizarDatos -= FormatoParaDataGridViewMateriales;
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
            if (fabrica.Materiales.Count == 0 || fabrica.AutoPartes.Count == 0)
            {
                DialogResult rta = MessageBox.Show($"Una de las listas no cuenta con elementos.\nDesea generar el reporte de todas maneras?", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rta == DialogResult.OK)
                {
                    MessageBox.Show(string.Format("Se genero el reporte en {0}", fabrica.GenerarReporte()), "WARNING.");
                }
            }
            else
            {
                MessageBox.Show(string.Format("Se genero el reporte en {0}", fabrica.GenerarReporte()), "WARNING.");
            }
        }

        /// <summary>
        /// Metodo encargado de eliminar una pieza de la fabrica y de la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {

            if (fabrica.AutoPartes.Count == 0)
            {
                MessageBox.Show("No hay piezas cargadas para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    aux = dgvListPieces.CurrentRow.DataBoundItem as AutoParte;

                    if (aux.EstaDefectuoso)
                    {
                        DialogResult rta = MessageBox.Show($"Esta seguro de elimnar de la lista: \n{aux.ToString()}", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        EliminarPieza(rta, aux);
                    }
                    else
                    {
                        DialogResult rta = MessageBox.Show($"La pieza seleccionada no se encuentra defectuosa, desea eliminarla?", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        EliminarPieza(rta, aux);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.saveReport(ex);
                }
            }
        }

        /// <summary>
        /// Metodo encargado de eliminar una pieza
        /// </summary>
        /// <param name="rta"></param>
        /// <param name="aux"></param>
        private void EliminarPieza(DialogResult rta, AutoParte aux)
        {
            if (rta == DialogResult.OK)
            {
                if (fabrica - aux)
                {
                    actualizarDatos.Invoke();
                    MessageBox.Show("La pieza ha sido eliminada de la lista.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                {
                    DialogResult rta = MessageBox.Show("Si importa nuevamente los datos, perdera el progreso actual.", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (rta == DialogResult.OK)
                    {
                        ObtieneDatosDesdeLaBase();
                    }
                }
                else
                {
                    ObtieneDatosDesdeLaBase();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.saveReport(ex);
            }
        }

        /// <summary>
        /// Metodo para obtener los datos de la base de datos.
        /// </summary>
        private void ObtieneDatosDesdeLaBase()
        {
            fabrica.GetMaterialsFromDB();
            fabrica.GetAutoPartesFromDB();
            actualizarDatos.Invoke();
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
                using (FormPopUp pop2 = new FormPopUp("Seleccione que exportar", "Materiales", "AutoPartes"))
                {
                    pop2.ShowDialog();

                    if (pop2.OptionSelected == "Materiales" && fabrica.Materiales.Count != 0)
                        {
                            if (fabrica.DropTableMateriales() && fabrica.CreateTableMateriales() && fabrica.ExportMaterialsToDB())

                            MessageBox.Show("Se exportaron con exito los datos.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            throw new FileException("Hubo un error al exportar los datos.");

                    }
                    else if (pop2.OptionSelected == "AutoPartes" && fabrica.AutoPartes.Count != 0)
                    {
                        if (fabrica.DropTableAutoParts() && fabrica.CreateTableAutoParts() && fabrica.ExportAutoPartsToDB()) 
                            MessageBox.Show("Se exportaron con exito los datos.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            throw new FileException("Hubo un error al exportar los datos.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.saveReport(ex);
            }
        }

        private void dgvListPieces_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Tuve que activarlo para poder aplicar el true or false en la propiedad estaDefectuoso.
        }
    }
}
