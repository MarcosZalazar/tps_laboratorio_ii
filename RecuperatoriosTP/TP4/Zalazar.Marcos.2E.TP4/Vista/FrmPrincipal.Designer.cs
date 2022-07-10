namespace Vista
{
    partial class FrmPrincipal
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
            this.lstSocios = new System.Windows.Forms.ListBox();
            this.btnAgregarAlSocio = new System.Windows.Forms.Button();
            this.btnModificarAlSocio = new System.Windows.Forms.Button();
            this.btnEliminarAlSocio = new System.Windows.Forms.Button();
            this.btnImprimirFicha = new System.Windows.Forms.Button();
            this.lstProfesores = new System.Windows.Forms.ListBox();
            this.btnAgregarProfesor = new System.Windows.Forms.Button();
            this.btnModificarProfesor = new System.Windows.Forms.Button();
            this.btnEliminarProfesor = new System.Windows.Forms.Button();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblTituloSocios = new System.Windows.Forms.Label();
            this.lblTituloProfesores = new System.Windows.Forms.Label();
            this.lblTituloGestion = new System.Windows.Forms.Label();
            this.btnMostrarInfoGestion = new System.Windows.Forms.Button();
            this.rtbGestion = new System.Windows.Forms.RichTextBox();
            this.btnRegistrarEgresos = new System.Windows.Forms.Button();
            this.btnLimpiarInforme = new System.Windows.Forms.Button();
            this.btnImportarEgresos = new System.Windows.Forms.Button();
            this.lblRecordatorioProfesores = new System.Windows.Forms.Label();
            this.btnImprimirInforme = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstSocios
            // 
            this.lstSocios.FormattingEnabled = true;
            this.lstSocios.ItemHeight = 15;
            this.lstSocios.Location = new System.Drawing.Point(14, 73);
            this.lstSocios.Name = "lstSocios";
            this.lstSocios.Size = new System.Drawing.Size(1030, 124);
            this.lstSocios.TabIndex = 0;
            // 
            // btnAgregarAlSocio
            // 
            this.btnAgregarAlSocio.Location = new System.Drawing.Point(12, 217);
            this.btnAgregarAlSocio.Name = "btnAgregarAlSocio";
            this.btnAgregarAlSocio.Size = new System.Drawing.Size(96, 48);
            this.btnAgregarAlSocio.TabIndex = 1;
            this.btnAgregarAlSocio.Text = "Agregar";
            this.btnAgregarAlSocio.UseVisualStyleBackColor = true;
            this.btnAgregarAlSocio.Click += new System.EventHandler(this.btnAgregarAlSocio_Click);
            // 
            // btnModificarAlSocio
            // 
            this.btnModificarAlSocio.Location = new System.Drawing.Point(213, 217);
            this.btnModificarAlSocio.Name = "btnModificarAlSocio";
            this.btnModificarAlSocio.Size = new System.Drawing.Size(96, 50);
            this.btnModificarAlSocio.TabIndex = 2;
            this.btnModificarAlSocio.Text = "Modificar";
            this.btnModificarAlSocio.UseVisualStyleBackColor = true;
            this.btnModificarAlSocio.Click += new System.EventHandler(this.btnModificarAlSocio_Click);
            // 
            // btnEliminarAlSocio
            // 
            this.btnEliminarAlSocio.Location = new System.Drawing.Point(428, 217);
            this.btnEliminarAlSocio.Name = "btnEliminarAlSocio";
            this.btnEliminarAlSocio.Size = new System.Drawing.Size(96, 50);
            this.btnEliminarAlSocio.TabIndex = 3;
            this.btnEliminarAlSocio.Text = "Eliminar";
            this.btnEliminarAlSocio.UseVisualStyleBackColor = true;
            this.btnEliminarAlSocio.Click += new System.EventHandler(this.btnEliminarAlSocio_Click);
            // 
            // btnImprimirFicha
            // 
            this.btnImprimirFicha.Location = new System.Drawing.Point(647, 217);
            this.btnImprimirFicha.Name = "btnImprimirFicha";
            this.btnImprimirFicha.Size = new System.Drawing.Size(96, 50);
            this.btnImprimirFicha.TabIndex = 4;
            this.btnImprimirFicha.Text = "Imprimir Ficha";
            this.btnImprimirFicha.UseVisualStyleBackColor = true;
            this.btnImprimirFicha.Click += new System.EventHandler(this.btnImprimirFicha_Click);
            // 
            // lstProfesores
            // 
            this.lstProfesores.FormattingEnabled = true;
            this.lstProfesores.ItemHeight = 15;
            this.lstProfesores.Location = new System.Drawing.Point(12, 320);
            this.lstProfesores.Name = "lstProfesores";
            this.lstProfesores.Size = new System.Drawing.Size(1030, 124);
            this.lstProfesores.TabIndex = 5;
            // 
            // btnAgregarProfesor
            // 
            this.btnAgregarProfesor.Location = new System.Drawing.Point(12, 459);
            this.btnAgregarProfesor.Name = "btnAgregarProfesor";
            this.btnAgregarProfesor.Size = new System.Drawing.Size(96, 48);
            this.btnAgregarProfesor.TabIndex = 6;
            this.btnAgregarProfesor.Text = "Agregar";
            this.btnAgregarProfesor.UseVisualStyleBackColor = true;
            this.btnAgregarProfesor.Click += new System.EventHandler(this.btnAgregarProfesor_Click);
            // 
            // btnModificarProfesor
            // 
            this.btnModificarProfesor.Location = new System.Drawing.Point(213, 459);
            this.btnModificarProfesor.Name = "btnModificarProfesor";
            this.btnModificarProfesor.Size = new System.Drawing.Size(96, 50);
            this.btnModificarProfesor.TabIndex = 7;
            this.btnModificarProfesor.Text = "Modificar";
            this.btnModificarProfesor.UseVisualStyleBackColor = true;
            this.btnModificarProfesor.Click += new System.EventHandler(this.btnModificarProfesor_Click);
            // 
            // btnEliminarProfesor
            // 
            this.btnEliminarProfesor.Location = new System.Drawing.Point(428, 459);
            this.btnEliminarProfesor.Name = "btnEliminarProfesor";
            this.btnEliminarProfesor.Size = new System.Drawing.Size(96, 50);
            this.btnEliminarProfesor.TabIndex = 8;
            this.btnEliminarProfesor.Text = "Eliminar";
            this.btnEliminarProfesor.UseVisualStyleBackColor = true;
            this.btnEliminarProfesor.Click += new System.EventHandler(this.btnEliminarProfesor_Click);
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBienvenida.Location = new System.Drawing.Point(318, 9);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(425, 28);
            this.lblBienvenida.TabIndex = 9;
            this.lblBienvenida.Text = "¡Bienvenido al sistema de gestión del gimnasio!\r\n";
            // 
            // lblTituloSocios
            // 
            this.lblTituloSocios.AutoSize = true;
            this.lblTituloSocios.Location = new System.Drawing.Point(12, 51);
            this.lblTituloSocios.Name = "lblTituloSocios";
            this.lblTituloSocios.Size = new System.Drawing.Size(90, 15);
            this.lblTituloSocios.TabIndex = 11;
            this.lblTituloSocios.Text = "Nuestros socios";
            // 
            // lblTituloProfesores
            // 
            this.lblTituloProfesores.AutoSize = true;
            this.lblTituloProfesores.Location = new System.Drawing.Point(12, 288);
            this.lblTituloProfesores.Name = "lblTituloProfesores";
            this.lblTituloProfesores.Size = new System.Drawing.Size(112, 15);
            this.lblTituloProfesores.TabIndex = 12;
            this.lblTituloProfesores.Text = "Nuestros profesores";
            // 
            // lblTituloGestion
            // 
            this.lblTituloGestion.AutoSize = true;
            this.lblTituloGestion.Location = new System.Drawing.Point(12, 519);
            this.lblTituloGestion.Name = "lblTituloGestion";
            this.lblTituloGestion.Size = new System.Drawing.Size(130, 15);
            this.lblTituloGestion.TabIndex = 13;
            this.lblTituloGestion.Text = "Informacion de gestion";
            // 
            // btnMostrarInfoGestion
            // 
            this.btnMostrarInfoGestion.Location = new System.Drawing.Point(707, 549);
            this.btnMostrarInfoGestion.Name = "btnMostrarInfoGestion";
            this.btnMostrarInfoGestion.Size = new System.Drawing.Size(145, 42);
            this.btnMostrarInfoGestion.TabIndex = 15;
            this.btnMostrarInfoGestion.Text = "Mostrar Informacion de \r\nGestion";
            this.btnMostrarInfoGestion.UseVisualStyleBackColor = true;
            this.btnMostrarInfoGestion.Click += new System.EventHandler(this.btnMostrarInfoGestion_Click);
            // 
            // rtbGestion
            // 
            this.rtbGestion.Location = new System.Drawing.Point(12, 549);
            this.rtbGestion.Name = "rtbGestion";
            this.rtbGestion.Size = new System.Drawing.Size(651, 141);
            this.rtbGestion.TabIndex = 16;
            this.rtbGestion.Text = "";
            // 
            // btnRegistrarEgresos
            // 
            this.btnRegistrarEgresos.Location = new System.Drawing.Point(897, 549);
            this.btnRegistrarEgresos.Name = "btnRegistrarEgresos";
            this.btnRegistrarEgresos.Size = new System.Drawing.Size(145, 42);
            this.btnRegistrarEgresos.TabIndex = 17;
            this.btnRegistrarEgresos.Text = "Registrar egresos";
            this.btnRegistrarEgresos.UseVisualStyleBackColor = true;
            this.btnRegistrarEgresos.Click += new System.EventHandler(this.btnRegistrarEgresos_Click);
            // 
            // btnLimpiarInforme
            // 
            this.btnLimpiarInforme.Location = new System.Drawing.Point(707, 598);
            this.btnLimpiarInforme.Name = "btnLimpiarInforme";
            this.btnLimpiarInforme.Size = new System.Drawing.Size(145, 42);
            this.btnLimpiarInforme.TabIndex = 18;
            this.btnLimpiarInforme.Text = "Limpiar informe";
            this.btnLimpiarInforme.UseVisualStyleBackColor = true;
            this.btnLimpiarInforme.Click += new System.EventHandler(this.btnLimpiarInforme_Click);
            // 
            // btnImportarEgresos
            // 
            this.btnImportarEgresos.Location = new System.Drawing.Point(897, 598);
            this.btnImportarEgresos.Name = "btnImportarEgresos";
            this.btnImportarEgresos.Size = new System.Drawing.Size(145, 42);
            this.btnImportarEgresos.TabIndex = 19;
            this.btnImportarEgresos.Text = "Importar Egresos";
            this.btnImportarEgresos.UseVisualStyleBackColor = true;
            this.btnImportarEgresos.Click += new System.EventHandler(this.btnImportarEgresos_Click);
            // 
            // lblRecordatorioProfesores
            // 
            this.lblRecordatorioProfesores.AutoSize = true;
            this.lblRecordatorioProfesores.ForeColor = System.Drawing.Color.Red;
            this.lblRecordatorioProfesores.Location = new System.Drawing.Point(215, 288);
            this.lblRecordatorioProfesores.Name = "lblRecordatorioProfesores";
            this.lblRecordatorioProfesores.Size = new System.Drawing.Size(75, 15);
            this.lblRecordatorioProfesores.TabIndex = 20;
            this.lblRecordatorioProfesores.Text = "Recordatorio";
            this.lblRecordatorioProfesores.Visible = false;
            // 
            // btnImprimirInforme
            // 
            this.btnImprimirInforme.Location = new System.Drawing.Point(707, 646);
            this.btnImprimirInforme.Name = "btnImprimirInforme";
            this.btnImprimirInforme.Size = new System.Drawing.Size(145, 44);
            this.btnImprimirInforme.TabIndex = 22;
            this.btnImprimirInforme.Text = "Imprimir Informe";
            this.btnImprimirInforme.UseVisualStyleBackColor = true;
            this.btnImprimirInforme.Click += new System.EventHandler(this.btnImprimirInforme_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 702);
            this.Controls.Add(this.btnImprimirInforme);
            this.Controls.Add(this.lblRecordatorioProfesores);
            this.Controls.Add(this.btnImportarEgresos);
            this.Controls.Add(this.btnLimpiarInforme);
            this.Controls.Add(this.btnRegistrarEgresos);
            this.Controls.Add(this.rtbGestion);
            this.Controls.Add(this.btnMostrarInfoGestion);
            this.Controls.Add(this.lblTituloGestion);
            this.Controls.Add(this.lblTituloProfesores);
            this.Controls.Add(this.lblTituloSocios);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.btnEliminarProfesor);
            this.Controls.Add(this.btnModificarProfesor);
            this.Controls.Add(this.btnAgregarProfesor);
            this.Controls.Add(this.lstProfesores);
            this.Controls.Add(this.btnImprimirFicha);
            this.Controls.Add(this.btnEliminarAlSocio);
            this.Controls.Add(this.btnModificarAlSocio);
            this.Controls.Add(this.btnAgregarAlSocio);
            this.Controls.Add(this.lstSocios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gimnasio";
            this.Load += new System.EventHandler(this.FrmPrincipalDeSocio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstSocios;
        private System.Windows.Forms.Button btnAgregarAlSocio;
        private System.Windows.Forms.Button btnModificarAlSocio;
        private System.Windows.Forms.Button btnEliminarAlSocio;
        private System.Windows.Forms.Button btnImprimirFicha;
        private System.Windows.Forms.ListBox lstProfesores;
        private System.Windows.Forms.Button btnAgregarProfesor;
        private System.Windows.Forms.Button btnModificarProfesor;
        private System.Windows.Forms.Button btnEliminarProfesor;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblTituloSocios;
        private System.Windows.Forms.Label lblTituloProfesores;
        private System.Windows.Forms.Label lblTituloGestion;
        private System.Windows.Forms.Button btnMostrarInfoGestion;
        private System.Windows.Forms.RichTextBox rtbGestion;
        private System.Windows.Forms.Button btnRegistrarEgresos;
        private System.Windows.Forms.Button btnLimpiarInforme;
        private System.Windows.Forms.Button btnImportarEgresos;
        private System.Windows.Forms.Label lblRecordatorioProfesores;
        private System.Windows.Forms.Button btnImprimirInforme;
    }
}