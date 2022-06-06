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
        public void AgregarEgreso (Gestion<T, U> gestion, T egreso)
        {
            if (gestion is not null && egreso is not null)
            {
                gestion.egresos.Add(egreso);
            }
        }

        public void AgregarIngreso(Gestion<T, U> gestion, U ingreso)
        {
            if (gestion is not null && ingreso is not null)
            {
                gestion.ingresos.Add(ingreso);
            }
        }
    }
}
