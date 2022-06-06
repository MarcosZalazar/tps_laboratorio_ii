using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesNegocio
{
    public class Gestion<T, U> where T : class where U : class
    {
        private List<T> egresos;
        private List<U> ingresos;

        public Gestion()
        {
            this.egresos = new List<T>();
            this.ingresos = new List<U>();
        }
        /// <summary>
        /// Propiedad que asigna y devuelve la lista de egresos
        /// </summary>
        public List<T> Egresos
        {
            get
            {
                return this.egresos;
            }
            set
            {
                this.egresos = value;
            }
        }

        /// <summary>
        /// Propiedad que asigna y devuelve la lista de ingresos
        /// </summary>
        public List<U> Ingresos
        {
            get
            {
                return this.ingresos;
            }
            set
            {
                this.ingresos = value;
            }
        }
        /// <summary>
        /// Agrega un egreso a la lista
        /// </summary>
        /// <param name="gestion">lista genérica</param>
        /// <param name="egreso"> egreso</param>
        public void AgregarEgreso (Gestion<T, U> gestion, T egreso)
        {
            if (gestion is not null && egreso is not null)
            {
                gestion.egresos.Add(egreso);
            }
        }
        /// <summary>
        /// Agrega un ingreso a la lista
        /// </summary>
        /// <param name="gestion">lista genérica</param>
        /// <param name="ingreso">ingreso</param>
        public void AgregarIngreso(Gestion<T, U> gestion, U ingreso)
        {
            if (gestion is not null && ingreso is not null)
            {
                gestion.ingresos.Add(ingreso);
            }
        }
    }
}
