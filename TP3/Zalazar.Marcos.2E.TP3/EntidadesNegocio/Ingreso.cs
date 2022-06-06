using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesNegocio
{
    public class Ingreso
    {
        protected string concepto;
        protected int importe;

        public Ingreso(string concepto, int importe)
        {
            this.concepto = concepto;
            this.importe = importe;
        }

        /// <summary>
        /// Propiedad que asigna y devuelve el valor al atributo concepto
        /// </summary>
        public string Concepto
        {
            get
            {
                return this.concepto;
            }
            set
            {
                this.concepto = value;
            }
        }

        /// <summary>
        /// Propiedad que asigna y devuelve el valor al atributo importe
        /// </summary>
        public int Importe
        {
            get
            {
                return this.importe;
            }
            set
            {
                this.importe = value;
            }
        }
    }
}
