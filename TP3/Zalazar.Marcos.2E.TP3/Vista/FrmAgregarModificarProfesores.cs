using EntidadesNegocio;
using GimnasioException;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmAgregarModificarProfesores : Form, IValidadorCampos
    {
        private Profesor profesor;

        public FrmAgregarModificarProfesores(string operacion, string operacionConfirmar, Profesor profesor)
        {
            InitializeComponent();
            this.Text = operacion;
            this.btnAceptarProf.Text = operacionConfirmar;
            this.profesor = profesor;
        }
        private void FrmAgregarModificarProfesores_Load(object sender, EventArgs e)
        {
            this.cmbSexoProf.DataSource = Enum.GetValues(typeof(ECampos.ESexo));
            this.cmbActividadProf.DataSource = Enum.GetValues(typeof(ECampos.Actividades));

            if (profesor is not null)
            {
                this.txtDniProf.Text = (profesor.Dni).ToString();
                this.txtNombreProf.Text = profesor.Nombre;
                this.txtApellidoProf.Text = profesor.Apellido;
                this.cmbSexoProf.SelectedIndex = (int)profesor.Sexo;
                this.dtmFechaContratacionProf.Text = (profesor.FechaDeContratacion).ToString();
                this.txtSalarioProf.Text = profesor.Salario.ToString();
                this.cmbActividadProf.SelectedIndex = (int)profesor.Actividad;
            }
        }
        private void btnAceptarProf_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarTodosLosCampos())
                {
                    int dniIngresado = int.Parse(this.txtDniProf.Text);
                    decimal salarioIngresado = decimal.Parse(this.txtSalarioProf.Text);

                    if (this.profesor is null)
                    {
                        this.profesor = new Profesor(dniIngresado, this.txtNombreProf.Text, this.txtApellidoProf.Text, (ECampos.ESexo)this.cmbSexoProf.SelectedIndex, this.dtmFechaContratacionProf.Value, salarioIngresado, (ECampos.Actividades)this.cmbActividadProf.SelectedItem);
                    }
                    else
                    {
                        this.profesor.Dni = dniIngresado;
                        this.profesor.Nombre = this.txtNombreProf.Text;
                        this.profesor.Apellido = this.txtApellidoProf.Text;
                        this.profesor.Sexo = (ECampos.ESexo)this.cmbSexoProf.SelectedIndex;
                        this.profesor.FechaDeContratacion = this.dtmFechaContratacionProf.Value;
                        this.profesor.Salario = salarioIngresado;
                        this.profesor.Actividad = (ECampos.Actividades)this.cmbActividadProf.SelectedIndex;
                    }

                    this.DialogResult = DialogResult.OK;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Verifique la correcta carga de los campos ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
           
        private void btnCancelarProf_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    
        public Profesor DevolverProfesor
        {
            get
            {
                return this.profesor;
            }
            set
            {
                this.profesor = value;
            }
        }

        public bool ElCampoNoEstaVacio(string campoAControlar)
        {
            if (campoAControlar != String.Empty)
            {
                return true;
            }
            else
            {
                throw new CargaFormException("El campo no puede quedar vacio. Por favor, completarlo");
            }
        }

        public bool ValidarEleccionSexo()
        {
            if (this.cmbSexoProf.SelectedIndex != -1)
            {
                return true;
            }
            else
            {
                throw new CargaFormException("Por favor, seleccione una opción en el campo sexo");
            }
        }
        public bool ValidarEleccionFecha()
        {
            DateTime fechaDeHoy = DateTime.Now;
            if (this.dtmFechaContratacionProf.Value.Date >= fechaDeHoy)
            {
                throw new CargaFormException("Por favor, seleccione una fecha válida");
            }
            else
            {
                return true;
            }
        }

        public bool ValidarEleccionActividad()
        {
            if (this.cmbActividadProf.SelectedIndex != -1)
            {
                return true;
            }
            else
            {
                throw new CargaFormException("Por favor, seleccione una opción en el campo actividad");
            }
        }
        private bool ValidarTodosLosCampos()
        {
            if (ElCampoNoEstaVacio(this.txtDniProf.Text) &&
                ElCampoNoEstaVacio(this.txtNombreProf.Text) &&
                ElCampoNoEstaVacio(this.txtApellidoProf.Text) &&
                ValidarEleccionSexo() &&
                ValidarEleccionFecha() &&
                ElCampoNoEstaVacio(this.txtSalarioProf.Text) &&
                ValidarEleccionActividad())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtDniProf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se pueden ingresar números", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void txtNombreProf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se pueden ingresar letras", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void txtApellidoProf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se pueden ingresar letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void txtSalarioProf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se pueden ingresar números", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }
    }
}
