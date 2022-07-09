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

        /// <summary>
        /// Carga a un profesor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Agrega o modifica a un profesor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        
        /// <summary>
        /// Cancela la carga o modificacion del profesor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelarProf_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    
        /// <summary>
        /// Devuelve un objeto del tipo profesor
        /// </summary>
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

        /// <summary>
        /// Verifica que un campo determinado no esté vacío
        /// </summary>
        /// <param name="campoAControlar">campo a evaluar</param>
        /// <returns>si está vació, false. Sino, true</returns>
        /// <exception cref="CargaFormException"></exception>
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

        /// <summary>
        /// Valida que se haya elegido un valor para el campo fecha
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CargaFormException"></exception>
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

        /// <summary>
        /// Valida que se haya elegido un valor para el campo actividad
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CargaFormException"></exception>
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

        /// <summary>
        /// Valida que se haya elegido un valor para el campo actividad
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CargaFormException"></exception>
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

        /// <summary>
        /// Valida todos los campos del formulario
        /// </summary>
        /// <returns></returns>
        private bool ValidarTodosLosCampos()
        {
            if (ElCampoNoEstaVacio(this.txtDniProf.Text) &&
                this.txtDniProf.Text.ValidarDni() &&
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

        /// <summary>
        /// Valida que no se ingresen otros caracteres que no sean muumeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDniProf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se pueden ingresar números", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Valida que no se ingresen otros caracteres que no sean letras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombreProf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se pueden ingresar letras", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Valida que no se ingresen otros caracteres que no sean letras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtApellidoProf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se pueden ingresar letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Valida que no se ingresen otros caracteres que no sean numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
