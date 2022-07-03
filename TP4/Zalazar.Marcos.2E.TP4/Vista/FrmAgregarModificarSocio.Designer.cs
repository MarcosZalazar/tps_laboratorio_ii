namespace Vista
{
    partial class FrmAgregarModificarSocio
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblDniSocio = new System.Windows.Forms.Label();
            this.txtDniSocio = new System.Windows.Forms.TextBox();
            this.lblMembresia = new System.Windows.Forms.Label();
            this.lblSexo = new System.Windows.Forms.Label();
            this.dtmFechaAlta = new System.Windows.Forms.DateTimePicker();
            this.lblFechaAlta = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.grbActividades = new System.Windows.Forms.GroupBox();
            this.chkNatacion = new System.Windows.Forms.CheckBox();
            this.chkYoga = new System.Windows.Forms.CheckBox();
            this.chkPilates = new System.Windows.Forms.CheckBox();
            this.chkSpinning = new System.Windows.Forms.CheckBox();
            this.chkAerobics = new System.Windows.Forms.CheckBox();
            this.chkGimnasioLibre = new System.Windows.Forms.CheckBox();
            this.cmbSexo = new System.Windows.Forms.ComboBox();
            this.cmbMembresia = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grbActividades.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(21, 65);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(51, 15);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(106, 65);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ShortcutsEnabled = false;
            this.txtNombre.Size = new System.Drawing.Size(200, 23);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(21, 101);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(51, 15);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(106, 101);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.ShortcutsEnabled = false;
            this.txtApellido.Size = new System.Drawing.Size(200, 23);
            this.txtApellido.TabIndex = 3;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // lblDniSocio
            // 
            this.lblDniSocio.AutoSize = true;
            this.lblDniSocio.Location = new System.Drawing.Point(21, 30);
            this.lblDniSocio.Name = "lblDniSocio";
            this.lblDniSocio.Size = new System.Drawing.Size(59, 15);
            this.lblDniSocio.TabIndex = 4;
            this.lblDniSocio.Text = "DNI Socio";
            // 
            // txtDniSocio
            // 
            this.txtDniSocio.Location = new System.Drawing.Point(106, 30);
            this.txtDniSocio.Name = "txtDniSocio";
            this.txtDniSocio.ShortcutsEnabled = false;
            this.txtDniSocio.Size = new System.Drawing.Size(200, 23);
            this.txtDniSocio.TabIndex = 5;
            this.txtDniSocio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDniSocio_KeyPress);
            // 
            // lblMembresia
            // 
            this.lblMembresia.AutoSize = true;
            this.lblMembresia.Location = new System.Drawing.Point(21, 225);
            this.lblMembresia.Name = "lblMembresia";
            this.lblMembresia.Size = new System.Drawing.Size(66, 15);
            this.lblMembresia.TabIndex = 7;
            this.lblMembresia.Text = "Membresia";
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(21, 138);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(32, 15);
            this.lblSexo.TabIndex = 10;
            this.lblSexo.Text = "Sexo";
            // 
            // dtmFechaAlta
            // 
            this.dtmFechaAlta.Location = new System.Drawing.Point(106, 177);
            this.dtmFechaAlta.Name = "dtmFechaAlta";
            this.dtmFechaAlta.Size = new System.Drawing.Size(200, 23);
            this.dtmFechaAlta.TabIndex = 12;
            // 
            // lblFechaAlta
            // 
            this.lblFechaAlta.AutoSize = true;
            this.lblFechaAlta.Location = new System.Drawing.Point(21, 177);
            this.lblFechaAlta.Name = "lblFechaAlta";
            this.lblFechaAlta.Size = new System.Drawing.Size(57, 30);
            this.lblFechaAlta.TabIndex = 13;
            this.lblFechaAlta.Text = "Fecha de \r\nAlta";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(338, 30);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(123, 58);
            this.btnAceptar.TabIndex = 14;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // grbActividades
            // 
            this.grbActividades.Controls.Add(this.chkNatacion);
            this.grbActividades.Controls.Add(this.chkYoga);
            this.grbActividades.Controls.Add(this.chkPilates);
            this.grbActividades.Controls.Add(this.chkSpinning);
            this.grbActividades.Controls.Add(this.chkAerobics);
            this.grbActividades.Controls.Add(this.chkGimnasioLibre);
            this.grbActividades.Location = new System.Drawing.Point(21, 259);
            this.grbActividades.Name = "grbActividades";
            this.grbActividades.Size = new System.Drawing.Size(285, 100);
            this.grbActividades.TabIndex = 15;
            this.grbActividades.TabStop = false;
            this.grbActividades.Text = "Actividades";
            // 
            // chkNatacion
            // 
            this.chkNatacion.AutoSize = true;
            this.chkNatacion.Location = new System.Drawing.Point(151, 72);
            this.chkNatacion.Name = "chkNatacion";
            this.chkNatacion.Size = new System.Drawing.Size(74, 19);
            this.chkNatacion.TabIndex = 5;
            this.chkNatacion.Text = "Natacion";
            this.chkNatacion.UseVisualStyleBackColor = true;
            // 
            // chkYoga
            // 
            this.chkYoga.AutoSize = true;
            this.chkYoga.Location = new System.Drawing.Point(151, 47);
            this.chkYoga.Name = "chkYoga";
            this.chkYoga.Size = new System.Drawing.Size(52, 19);
            this.chkYoga.TabIndex = 4;
            this.chkYoga.Text = "Yoga";
            this.chkYoga.UseVisualStyleBackColor = true;
            // 
            // chkPilates
            // 
            this.chkPilates.AutoSize = true;
            this.chkPilates.Location = new System.Drawing.Point(151, 22);
            this.chkPilates.Name = "chkPilates";
            this.chkPilates.Size = new System.Drawing.Size(60, 19);
            this.chkPilates.TabIndex = 3;
            this.chkPilates.Text = "Pilates";
            this.chkPilates.UseVisualStyleBackColor = true;
            // 
            // chkSpinning
            // 
            this.chkSpinning.AutoSize = true;
            this.chkSpinning.Location = new System.Drawing.Point(18, 72);
            this.chkSpinning.Name = "chkSpinning";
            this.chkSpinning.Size = new System.Drawing.Size(73, 19);
            this.chkSpinning.TabIndex = 2;
            this.chkSpinning.Text = "Spinning";
            this.chkSpinning.UseVisualStyleBackColor = true;
            // 
            // chkAerobics
            // 
            this.chkAerobics.AutoSize = true;
            this.chkAerobics.Location = new System.Drawing.Point(18, 47);
            this.chkAerobics.Name = "chkAerobics";
            this.chkAerobics.Size = new System.Drawing.Size(72, 19);
            this.chkAerobics.TabIndex = 1;
            this.chkAerobics.Text = "Aerobics";
            this.chkAerobics.UseVisualStyleBackColor = true;
            // 
            // chkGimnasioLibre
            // 
            this.chkGimnasioLibre.AutoSize = true;
            this.chkGimnasioLibre.Location = new System.Drawing.Point(18, 22);
            this.chkGimnasioLibre.Name = "chkGimnasioLibre";
            this.chkGimnasioLibre.Size = new System.Drawing.Size(105, 19);
            this.chkGimnasioLibre.TabIndex = 0;
            this.chkGimnasioLibre.Text = "Gimnasio Libre";
            this.chkGimnasioLibre.UseVisualStyleBackColor = true;
            // 
            // cmbSexo
            // 
            this.cmbSexo.FormattingEnabled = true;
            this.cmbSexo.Location = new System.Drawing.Point(106, 138);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(200, 23);
            this.cmbSexo.TabIndex = 16;
            // 
            // cmbMembresia
            // 
            this.cmbMembresia.FormattingEnabled = true;
            this.cmbMembresia.Location = new System.Drawing.Point(106, 217);
            this.cmbMembresia.Name = "cmbMembresia";
            this.cmbMembresia.Size = new System.Drawing.Size(200, 23);
            this.cmbMembresia.TabIndex = 17;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(338, 101);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(123, 58);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmAgregarModificarSocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 375);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cmbMembresia);
            this.Controls.Add(this.cmbSexo);
            this.Controls.Add(this.grbActividades);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblFechaAlta);
            this.Controls.Add(this.dtmFechaAlta);
            this.Controls.Add(this.lblSexo);
            this.Controls.Add(this.lblMembresia);
            this.Controls.Add(this.txtDniSocio);
            this.Controls.Add(this.lblDniSocio);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmAgregarModificarSocio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Socios";
            this.Load += new System.EventHandler(this.FrmAgregarModificarSocio_Load);
            this.grbActividades.ResumeLayout(false);
            this.grbActividades.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblDniSocio;
        private System.Windows.Forms.TextBox txtDniSocio;
        private System.Windows.Forms.Label lblMembresia;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.DateTimePicker dtmFechaAlta;
        private System.Windows.Forms.Label lblFechaAlta;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox grbActividades;
        private System.Windows.Forms.CheckBox chkSpinning;
        private System.Windows.Forms.CheckBox chkAerobics;
        private System.Windows.Forms.CheckBox chkGimnasioLibre;
        private System.Windows.Forms.CheckBox chkNatacion;
        private System.Windows.Forms.CheckBox chkYoga;
        private System.Windows.Forms.CheckBox chkPilates;
        private System.Windows.Forms.ComboBox cmbSexo;
        private System.Windows.Forms.ComboBox cmbMembresia;
        private System.Windows.Forms.Button btnCancelar;
    }
}