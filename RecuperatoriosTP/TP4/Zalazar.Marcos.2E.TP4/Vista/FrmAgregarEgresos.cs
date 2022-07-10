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
    public partial class FrmAgregarEgresos : Form
    {
        private Egreso egreso;
        public FrmAgregarEgresos(Egreso egreso)
        {
            InitializeComponent();
            this.egreso = egreso;
        }

        /// <summary>
        /// Carga los egresos del gimnasio en forma manual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargaManual_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarLosCampos())
                {
                    int egresoACargar = int.Parse(this.txtImporteEgreso.Text);

                    this.egreso = new Egreso(this.txtTipoEgreso.Text,egresoACargar);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (CargaFormException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Verifique la correcta carga de los campos ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Propiedad que asigna y devuelve a un objeto egreso
        /// </summary>
        public Egreso DevolverEgreso
        {
            get
            {
                return this.egreso;
            }
            set
            {
                this.egreso = value;
            }
        }

        /// <summary>
        /// Verifica que un campo determinado no esté vacío
        /// </summary>
        /// <param name="campoAControlar"> campo a evuluar</param>
        /// <returns> si está vació, false. Sino, true</returns>
        /// <exception cref="CargaFormException"></exception>
        public bool ElCampoNoEstaVacio(string campoAControlar)
        {
            if (campoAControlar != String.Empty)
            {
                return true;
            }
            else
            {
                throw new CargaFormException("Existen campos vacios. Por favor, completarlos");
            }
        }

        /// <summary>
        /// Valida todos los campos del formulario
        /// </summary>
        /// <returns></returns>
        private bool ValidarLosCampos()
        {
            if (ElCampoNoEstaVacio(this.txtTipoEgreso.Text) && ElCampoNoEstaVacio(this.txtImporteEgreso.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Valida que no se ingresen otros caracteres que no sean letras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTipoEgreso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se pueden ingresar letras", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Valida que no se ingresen otros caracteres que no sean números
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtImporteEgreso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se pueden ingresar números", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }
    }
}
