using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;
        public string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        /// <summary>
        /// Convierte un número binario en decimal
        /// </summary>
        /// <param name="binario"> número expresado en sistema binario </param>
        /// <returns> decimalString= número expresado en sistema decimal /returns>
        public string BinarioDecimal(string binario)
        {
            string decimalString = "Valor inválido";
            int decimalARetornar;

            if (EsBinario(binario))
            {
                decimalARetornar = Math.Abs(Convert.ToInt32(binario, 2));
                decimalString= decimalARetornar.ToString();
            }
            return decimalString;   
        }

        /// <summary>
        /// Convierte un número decimal en binario
        /// </summary>
        /// <param name="numero"> número expresado en sistema decimal </param>
        /// <returns> binarioString= número expresado en sistema decimal </returns>
        public string DecimalBinario(double numero)
        {
            string binarioString = "Valor inválido";
            int binarioADevolver;

            binarioADevolver=Math.Abs(Convert.ToInt32(numero));

            if (binarioADevolver >=0)
            {
                binarioString = Convert.ToString(binarioADevolver, 2);
            }

            return binarioString;
        }
        /// <summary>
        /// Convierte un número decimal en binario
        /// </summary>
        /// <param name="numero"> número expresado en sistema decimal </param>
        /// <returns> binarioString= número expresado en sistema decimal </returns>
        public string DecimalBinario(string numero)
        {
            string binarioString = "Valor inválido";
            double binarioADevolver;

            if (Double.TryParse(numero, out binarioADevolver))
            {
                binarioString = DecimalBinario(Math.Abs(binarioADevolver));
 
            }
            return binarioString;
        }
        /// <summary>
        /// Valida si un número recibido está expresado en sistema binario
        /// </summary>
        /// <param name="binario"> número a validar </param>
        /// <returns> esBinario= true: el número está expresado en sistema binario false:el número no está expresado en sistema binario </returns>
        private bool EsBinario(string binario)
        {
            bool esBinario=true;

            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                {
                    esBinario = false;
                    break;
                }
            }
            return esBinario;
        }
        public Operando()
        {
            this.numero = 0;
        }
        public Operando(double numero)
        {
            this.numero = numero; 
        }
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }
        public static double operator - (Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator * (Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator / (Operando n1, Operando n2)
        {
            double resultado;

            if (n2.numero != 0)
            {
                resultado=n1.numero/ n2.numero; 
            }
            else 
            {
                resultado = double.MinValue;
            }

            return resultado;
        }
        public static double operator + (Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Validará que el parámetro recibido sea un número
        /// </summary>
        /// <param name="strNumero"> parámetro a validar </param>
        /// <returns> numeroADevolver= número en formato double o "0" en caso de que no sea un número </returns>
        private double ValidarOperando(string strNumero)
        {
            double numeroADevolver = 0;

            Double.TryParse(strNumero, out numeroADevolver);

            return numeroADevolver;
        }           

    }
}
