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
                this.numero = value;
            }
        }

        public string BinarioDecimal(string binario)
        { 

        }
        public string DecimalBinario(double numero)
        {

        }
        public string DecimalBinario(string numero)
        {

        }
        private bool EsBinario(string binario)
        {

        }
        public Operando()
        {
            this.Numero = 0;
        }
        public Operando(double numero)
        {
            this.numero = numero; 
        }
        public Operando(string strNumero)
        {
            this.numero = strNumero;
        }
        public double operator - (Operando n1, Operando n2)
        {
            return;
        }
        public double operator *(Operando n1, Operando n2)
        {
            return;
        }
        public double operator /(Operando n1, Operando n2)
        {
            return;
        }
        public double operator *(Operando n1, Operando n2)
        {
            return;
        }
        private double ValidarOperando (string strNumero)
        {

            return;
        }


    }
}
