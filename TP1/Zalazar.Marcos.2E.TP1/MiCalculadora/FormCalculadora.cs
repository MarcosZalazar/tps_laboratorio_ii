using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class frmCalculadora : Form
    {
        public frmCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga el formulario en memoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.Items.Add("");
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("/");
            cmbOperador.Items.Add("*");
            Limpiar();
        }

        /// <summary>
        /// Invoca al método Limpiar()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Borra los datos de los TextBox, ComboBox y del Label
        /// </summary>
        private void Limpiar() 
        {
            txtNumero1.Clear();
            cmbOperador.SelectedIndex=0;
            txtNumero2.Clear();
            lblResultado.Text = "0";
        }

        /// <summary>
        /// Invoca al método Operar y registra el resultado que devuelve dicho método
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;

            resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            if (cmbOperador.SelectedItem.ToString() =="")
            {
                cmbOperador.Text = "+";
            }
            if (resultado == double.MinValue)
            {
                lblResultado.Text = "Valor inválido";
                lstOperaciones.Items.Add($"{txtNumero1.Text}{cmbOperador.Text}{txtNumero2.Text} = Operación inválida");
            }
            else 
            {
                lblResultado.Text = Math.Round(resultado,2).ToString();
                lstOperaciones.Items.Add($"{txtNumero1.Text}{cmbOperador.Text}{txtNumero2.Text} = {lblResultado.Text}");
            }
        }

        /// <summary>
        /// Recibe los números y la operación aritmética seleccionada y realiza el cálculo correspondiente
        /// </summary>
        /// <param name="numero1"> Primer Operando </param>
        /// <param name="numero2"> Segundo Operando </param>
        /// <param name="operador"> Operador aritmético </param>
        /// <returns> resultadoOperacion= resultado de la operación aritmética </returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            char operadorChar;
            double resultadoOperacion;

            Operando primerOperando =new Operando(numero1);
            Operando segundoOperando = new Operando(numero2);
            char.TryParse(operador, out operadorChar);

            resultadoOperacion =Calculadora.Operar(primerOperando, segundoOperando, operadorChar);

            return resultadoOperacion;
        }

        /// <summary>
        /// Verifica que el usuario esté seguro de querer abandonar la aplicación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason==CloseReason.UserClosing)
            {
                DialogResult respuesta =MessageBox.Show("¿Seguro de querer salir?","Salir",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta != DialogResult.Yes)
                { 
                    e.Cancel = true;    
                }
            }
        }

        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
        
        /// <summary>
        /// Convierte un número decimal en un número expresado en sistema binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando numeroAConvertir=new Operando();
            string auxiliarAntesDeConversión= lblResultado.Text;

            if (auxiliarAntesDeConversión != "Valor inválido" || lstOperaciones.Text != "Conversíón a decimal inválida")
            {
                lblResultado.Text = numeroAConvertir.DecimalBinario(lblResultado.Text);
                lstOperaciones.Items.Add($"{auxiliarAntesDeConversión}D = {lblResultado.Text}B");
                
            }
            else 
            {
                lstOperaciones.Items.Add($"Conversíón a binario inválida");
                MessageBox.Show("No se pudo realizar la conversión a binario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Convierte un número expresado en sistema binario a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando numeroBinarioAConvertir = new Operando();
            string auxiliarAntesDeConversión = lblResultado.Text;

            lblResultado.Text = numeroBinarioAConvertir.BinarioDecimal(auxiliarAntesDeConversión);

            if (lblResultado.Text == "Valor inválido" || lstOperaciones.Text == "Conversíón a binario inválida")
            {
                lstOperaciones.Items.Add($"Conversíón a decimal inválida");
                MessageBox.Show("No se pudo realizar la conversión a decimal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                lstOperaciones.Items.Add($"{auxiliarAntesDeConversión}B = {lblResultado.Text}D");
               
            }
        }
    }
}
