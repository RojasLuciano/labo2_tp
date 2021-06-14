using Entidades;
using Files;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Maquinery;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = iTextSharp.text.Font;

namespace UI
{
    public partial class FormPiezas : Form
    {
        Materiales listMaterials;
        Pieces listPieces;
        FormHome formhome;
        Piece pieceRowSelected;
        string materialSelected;
        string pieceSelected;

        public FormPiezas()
        {
            InitializeComponent();
        }

        public FormPiezas(Materiales mats, FormHome f1) : this()
        {
            listMaterials = new Materiales();
            listMaterials = mats;
            formhome = f1;
            dgvListMaterials.DataSource = mats.Items;
            DataGridView(mats);

        }
        private void FormPiezas_Load(object sender, EventArgs e)
        {
            this.cmbListaDePartes.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbListaDePartes.DataSource = Enum.GetValues(typeof(typeOfPartToCreate));
            #region lbl
            this.lblInstrucciones.Text = " INSTRUCCIONES:\n * Seleccione el tipo de material de la lista.\n * Seleccione el tipo de pieza a cortar.\n * Ingrese las medidas.\n * Presione el boton Cortar. \n * Una vez creadas sus piezas, presione Siguiente";
            #endregion
            listPieces = new Pieces();
            pieceRowSelected = new Piece();
            dgvListMaterials.ClearSelection();
            dgvListPieces.ClearSelection();
            dgvListMaterials.Refresh();
            dgvListPieces.Refresh();
        }
        private void DataGridViewPieces(DataGridView dgv, Pieces pieces)
        {
            dgv.DataSource = null;
            dgv.DataSource = pieces.Items;
            dgv.AutoResizeColumns();
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.Columns["TypeOfPartToCreate"].HeaderText = "Pieza";
            dgv.Columns["Type"].HeaderText = "Tipo material";
            dgv.Columns["Height"].HeaderText = "Altura";
            dgv.Columns["Long"].HeaderText = "Largo";
            dgv.Columns["Width"].HeaderText = "Ancho";
            dgv.Columns["Weight"].HeaderText = "Peso";
            dgv.Columns["EstaCortado"].HeaderText = "Cortada";
            dgv.Columns["EstaAgujereado"].HeaderText = "Agujereada";
            dgv.Columns["EstaMoldeado"].HeaderText = "Moldeada";
            dgv.Columns["EstaPintado"].HeaderText = "Pintada";
            dgv.Columns["EstaSoldado"].HeaderText = "Soldada";
        }
        private void DataGridView(Materiales mats)
        {
            dgvListMaterials.DataSource = null;
            dgvListMaterials.DataSource = mats.Items;
            dgvListMaterials.AutoResizeColumns();
            dgvListMaterials.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvListMaterials.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvListMaterials.ReadOnly = true;
            dgvListMaterials.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvListMaterials.AllowUserToResizeColumns = false;
            dgvListMaterials.AllowUserToOrderColumns = false;
            dgvListMaterials.RowHeadersVisible = false;
            dgvListMaterials.Columns["Type"].HeaderText = "Tipo";
            dgvListMaterials.Columns["Height"].HeaderText = "Altura";
            dgvListMaterials.Columns["Density"].HeaderText = "Densidad";
            dgvListMaterials.Columns["Long"].HeaderText = "Largo";
            dgvListMaterials.Columns["Width"].HeaderText = "Ancho";
        }

        private void dgvListMaterials_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvListMaterials.Rows[e.RowIndex];
                materialSelected = row.Cells[0].Value.ToString();
            }
        }

        private void tbAltura_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbAltura.Text, "[^0-9]"))
            {
                MessageBox.Show("Solo se admiten numeros", "Advertencia.");
                tbAltura.Text = tbAltura.Text.Remove(tbAltura.Text.Length - 1);
            }
        }

        private void tbLargo_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbLargo.Text, "[^0-9]"))
            {
                MessageBox.Show("Solo se admiten numeros", "Advertencia.");
                tbLargo.Text = tbLargo.Text.Remove(tbLargo.Text.Length - 1);
            }
        }

        private void btnRealizarCorte_Click(object sender, EventArgs e)
        {
            Piece new_piece;
            try
                {
                if (materialSelected == null)
                    throw new Exception("Debe seleccionar un material");

                foreach (Material item in listMaterials.Items)
                {
                    if (item.Type.Equals((Tipo)Enum.Parse(typeof(Tipo), materialSelected)))
                    {

                        if (Material.ThereIsEnoughMaterial2(item, double.Parse(tbAltura.Text), double.Parse(tbLargo.Text)))
                        {
                            new_piece = CuttingMachine.ToBeCut2(item, (typeOfPartToCreate)Enum.Parse(typeof(typeOfPartToCreate), pieceSelected), item.Type, double.Parse(tbAltura.Text), double.Parse(tbLargo.Text));
                            listPieces.Items.Add(new_piece);
                            break;
                        }
                    }
                }
                DataGridViewPieces(dgvListPieces, listPieces);
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message, "Advertencia.");
            }
            DataGridView(listMaterials);
        }

        private void cmbListaDePartes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbListaDePartes.DropDownStyle = ComboBoxStyle.DropDownList;
            pieceSelected = cmbListaDePartes.SelectedItem.ToString();
        }

        private void dgvListPieces_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 1)
            {
                DataGridViewRow row = dgvListMaterials.Rows[e.RowIndex];
                materialSelected = row.Cells[0].Value.ToString();
            }
        }

        private void btnMoldear_Click(object sender, EventArgs e)
        {
            pieceRowSelected = dgvListPieces.CurrentRow.DataBoundItem as Piece;
            foreach (Piece item in listPieces.Items)
            {
                if (item == pieceRowSelected)
                {
                    MoldingMachine.ToBeMolding(item);
                }
                DataGridViewPieces(dgvListPieces, listPieces);
            }
        }

        private void btnAgujerear_Click(object sender, EventArgs e)
        {
            pieceRowSelected = dgvListPieces.CurrentRow.DataBoundItem as Piece;
            foreach (Piece item in listPieces.Items)
            {
                if (item == pieceRowSelected)
                {
                    DrillingMachine.ToBePierce(item);
                }
                DataGridViewPieces(dgvListPieces, listPieces);
            }
        }

        private void btnPintar_Click(object sender, EventArgs e)
        {
            pieceRowSelected = dgvListPieces.CurrentRow.DataBoundItem as Piece;
            foreach (Piece item in listPieces.Items)
            {
                if (item == pieceRowSelected)
                {
                    PaintingMachine.ToBePainting(item);
                }
                DataGridViewPieces(dgvListPieces, listPieces);
            }
        }

        private void btnSoldar_Click(object sender, EventArgs e)
        {
            pieceRowSelected = dgvListPieces.CurrentRow.DataBoundItem as Piece;
            foreach (Piece item in listPieces.Items)
            {
                if (item == pieceRowSelected)
                {
                    WeldingMachine.ToBeWelding(item);
                }
                DataGridViewPieces(dgvListPieces, listPieces);
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
                Font titleFont = FontFactory.GetFont("Arial", 32);
                Font regularFont = FontFactory.GetFont("Arial", 9);
                Paragraph saltoDeLinea = new Paragraph("\n");

                Paragraph title;
                Paragraph text;

                string fileName = string.Empty;
                DateTime fileCreationDatetime = DateTime.Now;
                fileName = string.Format("Report{0}", fileCreationDatetime.ToString(@"ddMMyyyy") + "_" + fileCreationDatetime.ToString(@"HHmm"));

                FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + fileName + ".pdf", FileMode.Create);
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 10, 10);
                PdfWriter pw = PdfWriter.GetInstance(doc, fs);
                doc.Open();


                text = new Paragraph(fileCreationDatetime.ToString("dd/MM/yyyy"), FontFactory.GetFont("Arial", 10));
                text.IndentationLeft = 485;
                text.SpacingAfter = 5;
                doc.Add(text);

                //Añado la tabla.
                PdfPTable tableMaterials = new PdfPTable(dgvListMaterials.Columns.Count);
                foreach (DataGridViewColumn item in dgvListMaterials.Columns)
                {
                    tableMaterials.AddCell(new Phrase(item.HeaderText, regularFont));
                }


                for (int rows = 0; rows < dgvListMaterials.Rows.Count; rows++)
                {
                    for (int cell = 0; cell < dgvListMaterials.Columns.Count; cell++)
                    {
                        if (dgvListMaterials[cell, rows].Value != null)
                        {
                            tableMaterials.AddCell(new Phrase(dgvListMaterials[cell, rows].Value.ToString(), regularFont));
                        }
                    }
                }

                PdfPTable tablePieces = new PdfPTable(dgvListPieces.Columns.Count);
                foreach (DataGridViewColumn item in dgvListPieces.Columns)
                {
                    tablePieces.AddCell(new Phrase(item.HeaderText, regularFont));
                }
                string value = "";
                for (int rows = 0; rows < dgvListPieces.Rows.Count; rows++)
                {
                    for (int cell = 0; cell < dgvListPieces.Columns.Count; cell++)
                    {
                        if (dgvListPieces[cell, rows].Value != null)
                        {
                            value = dgvListPieces[cell, rows].Value.ToString();
                            if (value == "True")
                                value = "SI";

                            if (value == "False")
                                value = "NO";

                            tablePieces.AddCell(new Phrase(value, regularFont));
                        }
                    }
                }

                title = new Paragraph("Reporte", titleFont);
                title.Alignment = Element.ALIGN_CENTER;

                text = new Paragraph("Lista de material sobrante\n", regularFont);
                text.IndentationLeft = 58;
                text.SpacingAfter = 5;

                //Comienzo a añadir la info
                doc.Add(title);
                doc.Add(saltoDeLinea);
                doc.Add(text);
                doc.Add(tableMaterials);
                doc.Add(saltoDeLinea);

                text = new Paragraph(string.Format("Se ha fabricado un total de: {0} piezas.", listPieces.Items.Count), regularFont);
                text.IndentationLeft = 58;
                text.SpacingAfter = 5;
                doc.Add(text);

                text = new Paragraph("Lista de piezas creadas", regularFont);
                text.IndentationLeft = 58;
                text.SpacingAfter = 5;
                doc.Add(text);
                doc.Add(tablePieces);
                doc.Close();

                MessageBox.Show(string.Format("Se genero el reporte en {0}",fs.Name), "Advertencia.");

        }
    }
}
