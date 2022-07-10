namespace Vista
{
    partial class FrmAgregarEgresos
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
            this.grbEgreso = new System.Windows.Forms.GroupBox();
            this.lblImporteEgreso = new System.Windows.Forms.Label();
            this.lblTipoEgreso = new System.Windows.Forms.Label();
            this.txtImporteEgreso = new System.Windows.Forms.TextBox();
            this.txtTipoEgreso = new System.Windows.Forms.TextBox();
            this.btnCargaManual = new System.Windows.Forms.Button();
            this.grbEgreso.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbEgreso
            // 
            this.grbEgreso.Controls.Add(this.lblImporteEgreso);
            this.grbEgreso.Controls.Add(this.lblTipoEgreso);
            this.grbEgreso.Controls.Add(this.txtImporteEgreso);
            this.grbEgreso.Controls.Add(this.txtTipoEgreso);
            this.grbEgreso.Location = new System.Drawing.Point(34, 25);
            this.grbEgreso.Name = "grbEgreso";
            this.grbEgreso.Size = new System.Drawing.Size(308, 112);
            this.grbEgreso.TabIndex = 12;
            this.grbEgreso.TabStop = false;
            this.grbEgreso.Text = "Registrar Egreso";
            // 
            // lblImporteEgreso
            // 
            this.lblImporteEgreso.AutoSize = true;
            this.lblImporteEgreso.Location = new System.Drawing.Point(6, 60);
            this.lblImporteEgreso.Name = "lblImporteEgreso";
            this.lblImporteEgreso.Size = new System.Drawing.Size(87, 15);
            this.lblImporteEgreso.TabIndex = 3;
            this.lblImporteEgreso.Text = "Importe Egreso";
            // 
            // lblTipoEgreso
            // 
            this.lblTipoEgreso.AutoSize = true;
            this.lblTipoEgreso.Location = new System.Drawing.Point(6, 31);
            this.lblTipoEgreso.Name = "lblTipoEgreso";
            this.lblTipoEgreso.Size = new System.Drawing.Size(68, 15);
            this.lblTipoEgreso.TabIndex = 2;
            this.lblTipoEgreso.Text = "Tipo Egreso";
            // 
            // txtImporteEgreso
            // 
            this.txtImporteEgreso.Location = new System.Drawing.Point(112, 60);
            this.txtImporteEgreso.Name = "txtImporteEgreso";
            this.txtImporteEgreso.ShortcutsEnabled = false;
            this.txtImporteEgreso.Size = new System.Drawing.Size(136, 23);
            this.txtImporteEgreso.TabIndex = 1;
            this.txtImporteEgreso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporteEgreso_KeyPress);
            // 
            // txtTipoEgreso
            // 
            this.txtTipoEgreso.Location = new System.Drawing.Point(112, 31);
            this.txtTipoEgreso.Name = "txtTipoEgreso";
            this.txtTipoEgreso.ShortcutsEnabled = false;
            this.txtTipoEgreso.Size = new System.Drawing.Size(138, 23);
            this.txtTipoEgreso.TabIndex = 0;
            this.txtTipoEgreso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTipoEgreso_KeyPress);
            // 
            // btnCargaManual
            // 
            this.btnCargaManual.Location = new System.Drawing.Point(132, 155);
            this.btnCargaManual.Name = "btnCargaManual";
            this.btnCargaManual.Size = new System.Drawing.Size(108, 42);
            this.btnCargaManual.TabIndex = 13;
            this.btnCargaManual.Text = "Confirmar carga manual";
            this.btnCargaManual.UseVisualStyleBackColor = true;
            this.btnCargaManual.Click += new System.EventHandler(this.btnCargaManual_Click);
            // 
            // FrmAgregarEgresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 222);
            this.Controls.Add(this.btnCargaManual);
            this.Controls.Add(this.grbEgreso);
            this.Name = "FrmAgregarEgresos";
            this.Text = "Egresos";
            this.grbEgreso.ResumeLayout(false);
            this.grbEgreso.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grbEgreso;
        private System.Windows.Forms.Label lblImporteEgreso;
        private System.Windows.Forms.Label lblTipoEgreso;
        private System.Windows.Forms.TextBox txtImporteEgreso;
        private System.Windows.Forms.TextBox txtTipoEgreso;
        private System.Windows.Forms.Button btnCargaManual;
    }
}