
namespace UI
{
    partial class FormHome
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTextoFormHome = new System.Windows.Forms.Label();
            this.lblInstruccionesPiezas = new System.Windows.Forms.Label();
            this.btnPiezas = new System.Windows.Forms.Button();
            this.btnCargarListas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTextoFormHome
            // 
            this.lblTextoFormHome.AutoSize = true;
            this.lblTextoFormHome.Location = new System.Drawing.Point(49, 43);
            this.lblTextoFormHome.Name = "lblTextoFormHome";
            this.lblTextoFormHome.Size = new System.Drawing.Size(104, 20);
            this.lblTextoFormHome.TabIndex = 1;
            this.lblTextoFormHome.Text = "Instrucciones";
            // 
            // lblInstruccionesPiezas
            // 
            this.lblInstruccionesPiezas.AutoSize = true;
            this.lblInstruccionesPiezas.Location = new System.Drawing.Point(64, 256);
            this.lblInstruccionesPiezas.Name = "lblInstruccionesPiezas";
            this.lblInstruccionesPiezas.Size = new System.Drawing.Size(104, 20);
            this.lblInstruccionesPiezas.TabIndex = 2;
            this.lblInstruccionesPiezas.Text = "Instrucciones";
            // 
            // btnPiezas
            // 
            this.btnPiezas.Location = new System.Drawing.Point(140, 295);
            this.btnPiezas.Name = "btnPiezas";
            this.btnPiezas.Size = new System.Drawing.Size(441, 90);
            this.btnPiezas.TabIndex = 3;
            this.btnPiezas.Text = "Piezas";
            this.btnPiezas.UseVisualStyleBackColor = true;
            this.btnPiezas.Click += new System.EventHandler(this.btnPiezas_Click);
            // 
            // btnCargarListas
            // 
            this.btnCargarListas.Location = new System.Drawing.Point(140, 89);
            this.btnCargarListas.Name = "btnCargarListas";
            this.btnCargarListas.Size = new System.Drawing.Size(441, 96);
            this.btnCargarListas.TabIndex = 4;
            this.btnCargarListas.Text = "Cargar Materiales";
            this.btnCargarListas.UseVisualStyleBackColor = true;
            this.btnCargarListas.Click += new System.EventHandler(this.btnCargarListas_Click);
            // 
            // FormHome
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(720, 564);
            this.Controls.Add(this.btnCargarListas);
            this.Controls.Add(this.btnPiezas);
            this.Controls.Add(this.lblInstruccionesPiezas);
            this.Controls.Add(this.lblTextoFormHome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormHome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTextoFormHome;
        private System.Windows.Forms.Label lblInstruccionesPiezas;
        private System.Windows.Forms.Button btnPiezas;
        private System.Windows.Forms.Button btnCargarListas;
    }
}

