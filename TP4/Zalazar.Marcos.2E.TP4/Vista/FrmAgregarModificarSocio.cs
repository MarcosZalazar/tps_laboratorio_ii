using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesNegocio;
using GimnasioException;

namespace Vista
{
    public partial class FrmAgregarModificarSocio : Form, IValidadorCampos
    {
        private Socio socio;

        public FrmAgregarModificarSocio(string operacion, string operacionConfirmar,Socio socio) 
        {
            InitializeComponent();
            this.Text = operacion;
            this.btnAceptar.Text = operacionConfirmar;
            this.socio = socio;
        }

        /// <summary>
        /// Carga a un socio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAgregarModificarSocio_Load(object sender, EventArgs e)
        {
            this.cmbSexo.DataSource = Enum.GetValues(typeof(ECampos.ESexo));
            this.cmbMembresia.DataSource = Enum.GetValues(typeof(ECampos.EMembresia));

            if (socio is not null)
            {
                this.txtDniSocio.Text = (socio.DniSocio).ToString();
                this.txtNombre.Text = socio.Nombre;
                this.txtApellido.Text = socio.Apellido;
                this.cmbSexo.SelectedIndex = (int)socio.Sexo;
                this.dtmFechaAlta.Text = (socio.FechaDeAlta).ToString();
                this.cmbMembresia.SelectedIndex = (int)socio.Membresia;
                if (socio.listaActividades.Contains(ECampos.Actividades.GimnasioLibre))
                {
                    this.chkGimnasioLibre.Checked = true;
                }
                if (socio.listaActividades.Contains(ECampos.Actividades.Aerobics))
                {
                    this.chkAerobics.Checked = true;
                }
                if (socio.ListaActividades.Contains(ECampos.Actividades.Spinning))
                {
                    this.chkSpinning.Checked = true;
                }
                if (socio.listaActividades.Contains(ECampos.Actividades.Pilates))
                {
                    this.chkPilates.Checked = true;
                }
                if (socio.listaActividades.Contains(ECampos.Actividades.Yoga))
                {
                    this.chkYoga.Checked = true;
                }
                if (socio.listaActividades.Contains(ECampos.Actividades.Natacion))
                {
                    this.chkNatacion.Checked = true;
                }
            }
        }

        /// <summary>
        /// Agrega o modifica a un socio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarTodosLosCampos())
                {
                    int dniIngresado = int.Parse(this.txtDniSocio.Text);
                    List<ECampos.Actividades> listaActividadesACargar = new List<ECampos.Actividades>();
                    if (this.chkGimnasioLibre.Checked)
                    {
                        listaActividadesACargar.Add(ECampos.Actividades.GimnasioLibre);
                    }
                    if (this.chkAerobics.Checked)
                    {
                        listaActividadesACargar.Add(ECampos.Actividades.Aerobics);
                    }
                    if (this.chkSpinning.Checked)
                    {
                        listaActividadesACargar.Add(ECampos.Actividades.Spinning);
                    }
                    if (this.chkPilates.Checked)
                    {
                        listaActividadesACargar.Add(ECampos.Actividades.Pilates);
                    }
                    if (this.chkYoga.Checked)
                    {
                        listaActividadesACargar.Add(ECampos.Actividades.Yoga);
                    }
                    if (this.chkNatacion.Checked)
                    {
                        listaActividadesACargar.Add(ECampos.Actividades.Natacion);
                    }
                    if (this.socio is null)
                    {
                        this.socio = new Socio(dniIngresado, this.txtNombre.Text, this.txtApellido.Text, (ECampos.ESexo)this.cmbSexo.SelectedIndex, this.dtmFechaAlta.Value, (ECampos.EMembresia)this.cmbMembresia.SelectedItem);
                        socio.listaActividades = listaActividadesACargar;
                    }
                    else
                    {
                        this.socio.DniSocio = dniIngresado;
                        this.socio.Nombre = this.txtNombre.Text;
                        this.socio.Apellido = this.txtApellido.Text;
                        this.socio.Sexo = (ECampos.ESexo)this.cmbSexo.SelectedIndex;
                        socio.FechaDeAlta = this.dtmFechaAlta.Value;
                        socio.Membresia = (ECampos.EMembresia)this.cmbMembresia.SelectedItem;
                        socio.listaActividades = listaActividadesACargar;
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
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Devuelve un objeto del tipo socio
        /// </summary>
        public Socio DevolverSocio
        {
            get
            {
                return this.socio;
            }
            set
            {
                this.socio = value;
            }
        }

        /// <summary>
        /// Verifica que un campo determinado no esté vacío
        /// </summary>
        /// <param name="campoAControlar">campo a controlar</param>
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
        /// Valida que se haya elegido un valor para el campo actividad
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CargaFormException"></exception>
        public bool ValidarEleccionSexo()
        {
            if (this.cmbSexo.SelectedIndex != -1)
            {
                return true;
            }
            else
            {
                throw new CargaFormException("Por favor, seleccione una opción en el campo sexo");
            }
        }

        /// <summary>
        /// Valida que se haya elegido un valor para el campo fecha
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CargaFormException"></exception>
        public bool ValidarEleccionFecha()
        {
            DateTime fechaDeHoy = DateTime.Now;
            if (this.dtmFechaAlta.Value.Date >= fechaDeHoy)
            {
                throw new CargaFormException("Por favor, seleccione una fecha válida");
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Valida que se haya elegido un valor para el campo membnesia
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CargaFormException"></exception>
        private bool ValidarEleccionMembresia()
        {
            if (this.cmbMembresia.SelectedIndex != -1)
            {
                return true;
            }
            else
            {
                throw new CargaFormException("Por favor, seleccione una opción en el campo membresia");
            }
        }

        /// <summary>
        /// Valida que se haya elegido un valor para el campo actividad
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CargaFormException"></exception>
        public bool ValidarEleccionActividad()
        {
            if (!(this.chkGimnasioLibre.Checked && this.chkAerobics.Checked && this.chkSpinning.Checked &&
                  this.chkPilates.Checked && this.chkYoga.Checked && this.chkNatacion.Checked))
            {
                return true;
            }
            else
            {
                throw new CargaFormException("Por favor, seleccione al menos una actividad");
            }
        }

        /// <summary>
        /// Valida todos los campos del formulario
        /// </summary>
        /// <returns></returns>
        private bool ValidarTodosLosCampos()
        {
            if (ElCampoNoEstaVacio(this.txtDniSocio.Text) &&
                this.txtDniSocio.Text.ValidarDni() &&
                ElCampoNoEstaVacio(this.txtNombre.Text) &&
                ElCampoNoEstaVacio(this.txtApellido.Text) &&
                ValidarEleccionSexo() &&
                ValidarEleccionFecha() &&
                ValidarEleccionMembresia() &&
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
        /// Valida que no se ingresen otros caracteres que no sean numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDniSocio_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se pueden ingresar letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }
    }
}
