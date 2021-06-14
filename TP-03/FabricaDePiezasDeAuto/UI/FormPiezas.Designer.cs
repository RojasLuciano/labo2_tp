
namespace UI
{
    partial class FormPiezas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button6 = new System.Windows.Forms.Button();
            this.cmbListaDePartes = new System.Windows.Forms.ComboBox();
            this.lblInstrucciones = new System.Windows.Forms.Label();
            this.btnCargarListaDeMateriales = new System.Windows.Forms.Label();
            this.dgvListMaterials = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAltura = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbLargo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRealizarCorte = new System.Windows.Forms.Button();
            this.dgvListPieces = new System.Windows.Forms.DataGridView();
            this.lbl = new System.Windows.Forms.Label();
            this.btnMoldear = new System.Windows.Forms.Button();
            this.lblMedidas = new System.Windows.Forms.Label();
            this.btnAgujerear = new System.Windows.Forms.Button();
            this.btnPintar = new System.Windows.Forms.Button();
            this.btnSoldar = new System.Windows.Forms.Button();
            this.lblOpciones = new System.Windows.Forms.Label();
            this.btnReporte = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListPieces)).BeginInit();
            this.SuspendLayout();
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 681);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(315, 101);
            this.button6.TabIndex = 5;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // cmbListaDePartes
            // 
            this.cmbListaDePartes.FormattingEnabled = true;
            this.cmbListaDePartes.Location = new System.Drawing.Point(492, 51);
            this.cmbListaDePartes.Name = "cmbListaDePartes";
            this.cmbListaDePartes.Size = new System.Drawing.Size(74, 21);
            this.cmbListaDePartes.TabIndex = 12;
            this.cmbListaDePartes.SelectedIndexChanged += new System.EventHandler(this.cmbListaDePartes_SelectedIndexChanged);
            // 
            // lblInstrucciones
            // 
            this.lblInstrucciones.AutoSize = true;
            this.lblInstrucciones.Location = new System.Drawing.Point(598, 20);
            this.lblInstrucciones.Name = "lblInstrucciones";
            this.lblInstrucciones.Size = new System.Drawing.Size(70, 13);
            this.lblInstrucciones.TabIndex = 24;
            this.lblInstrucciones.Text = "Instrucciones";
            // 
            // btnCargarListaDeMateriales
            // 
            this.btnCargarListaDeMateriales.AutoSize = true;
            this.btnCargarListaDeMateriales.Location = new System.Drawing.Point(24, 20);
            this.btnCargarListaDeMateriales.Name = "btnCargarListaDeMateriales";
            this.btnCargarListaDeMateriales.Size = new System.Drawing.Size(149, 13);
            this.btnCargarListaDeMateriales.TabIndex = 25;
            this.btnCargarListaDeMateriales.Text = "Lista de materiales disponibles";
            // 
            // dgvListMaterials
            // 
            this.dgvListMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListMaterials.Location = new System.Drawing.Point(27, 36);
            this.dgvListMaterials.Name = "dgvListMaterials";
            this.dgvListMaterials.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvListMaterials.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListMaterials.Size = new System.Drawing.Size(318, 63);
            this.dgvListMaterials.TabIndex = 26;
            this.dgvListMaterials.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListMaterials_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Seleccione la pieza a cortar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(405, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Alto";
            // 
            // tbAltura
            // 
            this.tbAltura.Location = new System.Drawing.Point(427, 23);
            this.tbAltura.Name = "tbAltura";
            this.tbAltura.Size = new System.Drawing.Size(26, 20);
            this.tbAltura.TabIndex = 29;
            this.tbAltura.TextChanged += new System.EventHandler(this.tbAltura_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(556, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "CM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(493, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Largo";
            // 
            // tbLargo
            // 
            this.tbLargo.Location = new System.Drawing.Point(524, 23);
            this.tbLargo.Name = "tbLargo";
            this.tbLargo.Size = new System.Drawing.Size(26, 20);
            this.tbLargo.TabIndex = 32;
            this.tbLargo.TextChanged += new System.EventHandler(this.tbLargo_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(459, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "CM";
            // 
            // btnRealizarCorte
            // 
            this.btnRealizarCorte.Location = new System.Drawing.Point(351, 78);
            this.btnRealizarCorte.Name = "btnRealizarCorte";
            this.btnRealizarCorte.Size = new System.Drawing.Size(237, 21);
            this.btnRealizarCorte.TabIndex = 34;
            this.btnRealizarCorte.Text = "Cortar";
            this.btnRealizarCorte.UseVisualStyleBackColor = true;
            this.btnRealizarCorte.Click += new System.EventHandler(this.btnRealizarCorte_Click);
            // 
            // dgvListPieces
            // 
            this.dgvListPieces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListPieces.Location = new System.Drawing.Point(198, 128);
            this.dgvListPieces.Name = "dgvListPieces";
            this.dgvListPieces.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvListPieces.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListPieces.Size = new System.Drawing.Size(714, 210);
            this.dgvListPieces.TabIndex = 35;
            this.dgvListPieces.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListPieces_CellContentClick);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(195, 112);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(109, 13);
            this.lbl.TabIndex = 36;
            this.lbl.Text = "Seleccione una pieza";
            // 
            // btnMoldear
            // 
            this.btnMoldear.Location = new System.Drawing.Point(27, 128);
            this.btnMoldear.Name = "btnMoldear";
            this.btnMoldear.Size = new System.Drawing.Size(139, 48);
            this.btnMoldear.TabIndex = 37;
            this.btnMoldear.Text = "Moldear";
            this.btnMoldear.UseVisualStyleBackColor = true;
            this.btnMoldear.Click += new System.EventHandler(this.btnMoldear_Click);
            // 
            // lblMedidas
            // 
            this.lblMedidas.AutoSize = true;
            this.lblMedidas.Location = new System.Drawing.Point(348, 30);
            this.lblMedidas.Name = "lblMedidas";
            this.lblMedidas.Size = new System.Drawing.Size(50, 13);
            this.lblMedidas.TabIndex = 38;
            this.lblMedidas.Text = "Medidas:";
            // 
            // btnAgujerear
            // 
            this.btnAgujerear.Location = new System.Drawing.Point(27, 182);
            this.btnAgujerear.Name = "btnAgujerear";
            this.btnAgujerear.Size = new System.Drawing.Size(139, 48);
            this.btnAgujerear.TabIndex = 39;
            this.btnAgujerear.Text = "Agujerear";
            this.btnAgujerear.UseVisualStyleBackColor = true;
            this.btnAgujerear.Click += new System.EventHandler(this.btnAgujerear_Click);
            // 
            // btnPintar
            // 
            this.btnPintar.Location = new System.Drawing.Point(27, 236);
            this.btnPintar.Name = "btnPintar";
            this.btnPintar.Size = new System.Drawing.Size(139, 48);
            this.btnPintar.TabIndex = 40;
            this.btnPintar.Text = "Pïntar";
            this.btnPintar.UseVisualStyleBackColor = true;
            this.btnPintar.Click += new System.EventHandler(this.btnPintar_Click);
            // 
            // btnSoldar
            // 
            this.btnSoldar.Location = new System.Drawing.Point(27, 290);
            this.btnSoldar.Name = "btnSoldar";
            this.btnSoldar.Size = new System.Drawing.Size(139, 48);
            this.btnSoldar.TabIndex = 41;
            this.btnSoldar.Text = "Soldar";
            this.btnSoldar.UseVisualStyleBackColor = true;
            this.btnSoldar.Click += new System.EventHandler(this.btnSoldar_Click);
            // 
            // lblOpciones
            // 
            this.lblOpciones.AutoSize = true;
            this.lblOpciones.Location = new System.Drawing.Point(24, 112);
            this.lblOpciones.Name = "lblOpciones";
            this.lblOpciones.Size = new System.Drawing.Size(52, 13);
            this.lblOpciones.TabIndex = 42;
            this.lblOpciones.Text = "Opciones";
            // 
            // btnReporte
            // 
            this.btnReporte.Location = new System.Drawing.Point(408, 353);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(237, 21);
            this.btnReporte.TabIndex = 43;
            this.btnReporte.Text = "Generar Reporte";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // FormPiezas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 516);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.lblOpciones);
            this.Controls.Add(this.btnSoldar);
            this.Controls.Add(this.btnPintar);
            this.Controls.Add(this.btnAgujerear);
            this.Controls.Add(this.lblMedidas);
            this.Controls.Add(this.btnMoldear);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.dgvListPieces);
            this.Controls.Add(this.btnRealizarCorte);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbLargo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbAltura);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvListMaterials);
            this.Controls.Add(this.btnCargarListaDeMateriales);
            this.Controls.Add(this.lblInstrucciones);
            this.Controls.Add(this.cmbListaDePartes);
            this.Controls.Add(this.button6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPiezas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPiezas";
            this.Load += new System.EventHandler(this.FormPiezas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListPieces)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox cmbListaDePartes;
        private System.Windows.Forms.Label lblInstrucciones;
        private System.Windows.Forms.Label btnCargarListaDeMateriales;
        private System.Windows.Forms.DataGridView dgvListMaterials;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAltura;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbLargo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRealizarCorte;
        private System.Windows.Forms.DataGridView dgvListPieces;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button btnMoldear;
        private System.Windows.Forms.Label lblMedidas;
        private System.Windows.Forms.Button btnAgujerear;
        private System.Windows.Forms.Button btnPintar;
        private System.Windows.Forms.Button btnSoldar;
        private System.Windows.Forms.Label lblOpciones;
        private System.Windows.Forms.Button btnReporte;
    }
}