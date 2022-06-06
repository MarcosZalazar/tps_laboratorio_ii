namespace Vista
{
    partial class FrmAgregarModificarProfesores
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
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDniProf = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblSexo = new System.Windows.Forms.Label();
            this.lblFechaContratacion = new System.Windows.Forms.Label();
            this.lblSalario = new System.Windows.Forms.Label();
            this.lblActividad = new System.Windows.Forms.Label();
            this.txtNombreProf = new System.Windows.Forms.TextBox();
            this.txtApellidoProf = new System.Windows.Forms.TextBox();
            this.cmbSexoProf = new System.Windows.Forms.ComboBox();
            this.dtmFechaContratacionProf = new System.Windows.Forms.DateTimePicker();
            this.txtSalarioProf = new System.Windows.Forms.TextBox();
            this.cmbActividadProf = new System.Windows.Forms.ComboBox();
            this.btnAceptarProf = new System.Windows.Forms.Button();
            this.btnCancelarProf = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(31, 20);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(25, 15);
            this.lblDni.TabIndex = 0;
            this.lblDni.Text = "Dni";
            // 
            // txtDniProf
            // 
            this.txtDniProf.Location = new System.Drawing.Point(120, 20);
            this.txtDniProf.Name = "txtDniProf";
            this.txtDniProf.ShortcutsEnabled = false;
            this.txtDniProf.Size = new System.Drawing.Size(209, 23);
            this.txtDniProf.TabIndex = 1;
            this.txtDniProf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDniProf_KeyPress);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(31, 56);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(51, 15);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(31, 98);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(51, 15);
            this.lblApellido.TabIndex = 3;
            this.lblApellido.Text = "Apellido";
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(31, 139);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(32, 15);
            this.lblSexo.TabIndex = 4;
            this.lblSexo.Text = "Sexo";
            // 
            // lblFechaContratacion
            // 
            this.lblFechaContratacion.AutoSize = true;
            this.lblFechaContratacion.Location = new System.Drawing.Point(31, 172);
            this.lblFechaContratacion.Name = "lblFechaContratacion";
            this.lblFechaContratacion.Size = new System.Drawing.Size(74, 30);
            this.lblFechaContratacion.TabIndex = 5;
            this.lblFechaContratacion.Text = "Fecha de \r\ncontratacion";
            // 
            // lblSalario
            // 
            this.lblSalario.AutoSize = true;
            this.lblSalario.Location = new System.Drawing.Point(31, 220);
            this.lblSalario.Name = "lblSalario";
            this.lblSalario.Size = new System.Drawing.Size(42, 15);
            this.lblSalario.TabIndex = 6;
            this.lblSalario.Text = "Salario";
            // 
            // lblActividad
            // 
            this.lblActividad.AutoSize = true;
            this.lblActividad.Location = new System.Drawing.Point(31, 262);
            this.lblActividad.Name = "lblActividad";
            this.lblActividad.Size = new System.Drawing.Size(57, 15);
            this.lblActividad.TabIndex = 7;
            this.lblActividad.Text = "Actividad";
            // 
            // txtNombreProf
            // 
            this.txtNombreProf.Location = new System.Drawing.Point(120, 56);
            this.txtNombreProf.Name = "txtNombreProf";
            this.txtNombreProf.ShortcutsEnabled = false;
            this.txtNombreProf.Size = new System.Drawing.Size(209, 23);
            this.txtNombreProf.TabIndex = 8;
            this.txtNombreProf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreProf_KeyPress);
            // 
            // txtApellidoProf
            // 
            this.txtApellidoProf.Location = new System.Drawing.Point(120, 98);
            this.txtApellidoProf.Name = "txtApellidoProf";
            this.txtApellidoProf.ShortcutsEnabled = false;
            this.txtApellidoProf.Size = new System.Drawing.Size(209, 23);
            this.txtApellidoProf.TabIndex = 9;
            this.txtApellidoProf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellidoProf_KeyPress);
            // 
            // cmbSexoProf
            // 
            this.cmbSexoProf.FormattingEnabled = true;
            this.cmbSexoProf.Location = new System.Drawing.Point(120, 139);
            this.cmbSexoProf.Name = "cmbSexoProf";
            this.cmbSexoProf.Size = new System.Drawing.Size(209, 23);
            this.cmbSexoProf.TabIndex = 10;
            // 
            // dtmFechaContratacionProf
            // 
            this.dtmFechaContratacionProf.Location = new System.Drawing.Point(120, 179);
            this.dtmFechaContratacionProf.Name = "dtmFechaContratacionProf";
            this.dtmFechaContratacionProf.Size = new System.Drawing.Size(209, 23);
            this.dtmFechaContratacionProf.TabIndex = 11;
            // 
            // txtSalarioProf
            // 
            this.txtSalarioProf.Location = new System.Drawing.Point(120, 220);
            this.txtSalarioProf.Name = "txtSalarioProf";
            this.txtSalarioProf.ShortcutsEnabled = false;
            this.txtSalarioProf.Size = new System.Drawing.Size(209, 23);
            this.txtSalarioProf.TabIndex = 12;
            this.txtSalarioProf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalarioProf_KeyPress);
            // 
            // cmbActividadProf
            // 
            this.cmbActividadProf.FormattingEnabled = true;
            this.cmbActividadProf.Location = new System.Drawing.Point(120, 262);
            this.cmbActividadProf.Name = "cmbActividadProf";
            this.cmbActividadProf.Size = new System.Drawing.Size(209, 23);
            this.cmbActividadProf.TabIndex = 13;
            // 
            // btnAceptarProf
            // 
            this.btnAceptarProf.Location = new System.Drawing.Point(357, 20);
            this.btnAceptarProf.Name = "btnAceptarProf";
            this.btnAceptarProf.Size = new System.Drawing.Size(123, 58);
            this.btnAceptarProf.TabIndex = 15;
            this.btnAceptarProf.Text = "Aceptar";
            this.btnAceptarProf.UseVisualStyleBackColor = true;
            this.btnAceptarProf.Click += new System.EventHandler(this.btnAceptarProf_Click);
            // 
            // btnCancelarProf
            // 
            this.btnCancelarProf.Location = new System.Drawing.Point(357, 98);
            this.btnCancelarProf.Name = "btnCancelarProf";
            this.btnCancelarProf.Size = new System.Drawing.Size(123, 58);
            this.btnCancelarProf.TabIndex = 19;
            this.btnCancelarProf.Text = "Cancelar";
            this.btnCancelarProf.UseVisualStyleBackColor = true;
            this.btnCancelarProf.Click += new System.EventHandler(this.btnCancelarProf_Click);
            // 
            // FrmAgregarModificarProfesores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 330);
            this.Controls.Add(this.btnCancelarProf);
            this.Controls.Add(this.btnAceptarProf);
            this.Controls.Add(this.cmbActividadProf);
            this.Controls.Add(this.txtSalarioProf);
            this.Controls.Add(this.dtmFechaContratacionProf);
            this.Controls.Add(this.cmbSexoProf);
            this.Controls.Add(this.txtApellidoProf);
            this.Controls.Add(this.txtNombreProf);
            this.Controls.Add(this.lblActividad);
            this.Controls.Add(this.lblSalario);
            this.Controls.Add(this.lblFechaContratacion);
            this.Controls.Add(this.lblSexo);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtDniProf);
            this.Controls.Add(this.lblDni);
            this.Name = "FrmAgregarModificarProfesores";
            this.Text = "Profesores";
            this.Load += new System.EventHandler(this.FrmAgregarModificarProfesores_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDniProf;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.Label lblFechaContratacion;
        private System.Windows.Forms.Label lblSalario;
        private System.Windows.Forms.Label lblActividad;
        private System.Windows.Forms.TextBox txtNombreProf;
        private System.Windows.Forms.TextBox txtApellidoProf;
        private System.Windows.Forms.ComboBox cmbSexoProf;
        private System.Windows.Forms.DateTimePicker dtmFechaContratacionProf;
        private System.Windows.Forms.TextBox txtSalarioProf;
        private System.Windows.Forms.ComboBox cmbActividadProf;
        private System.Windows.Forms.Button btnAceptarProf;
        private System.Windows.Forms.Button btnCancelarProf;
    }
}