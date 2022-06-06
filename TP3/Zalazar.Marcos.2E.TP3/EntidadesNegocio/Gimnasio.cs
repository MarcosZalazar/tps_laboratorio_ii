using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesNegocio
{
    public class Gimnasio
    {
        protected string nombre;
        public List<Profesor> listaProfesores;
        public List<Socio> listaSocios;
        public Gestion<Egreso,Ingreso> periodoComercial;
        public Gimnasio()
        {
            this.listaProfesores = new List<Profesor>();
            this.listaSocios = new List<Socio>();
            this.periodoComercial = new Gestion<Egreso, Ingreso>();
        }
        public Gimnasio(string nombre) : this()
        {
            this.nombre = nombre;
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public List<Profesor> ListaProfesores
        {
            get
            {
                return this.listaProfesores;
            }
            set
            {
                this.listaProfesores = value;
            }
        }
        public List<Socio> ListaSocios
        {
            get
            {
                return this.listaSocios;
            }
            set
            {
                this.listaSocios = value;
            }
        }

        public Gestion<Egreso, Ingreso> PeriodoComercial
        {
            get
            {
                return this.periodoComercial;
            }
            set
            {
                this.periodoComercial = value;
            }
        }

        public string ImprimirFichaDelSocio(Socio socio)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"FICHA DEL SOCIO");
            sb.AppendLine($"------------------- ");
            sb.AppendLine($"  ");
            sb.AppendLine(socio.ToString());
            sb.AppendLine($"------------------- ");

            return sb.ToString();
        }

        public int CalcularTotalIngresos()
        {
            int totalIngresos=0;

            foreach (Socio socio in this.listaSocios)
            {
                if (socio.Membresia == ECampos.EMembresia.Smart)
                {
                    totalIngresos = totalIngresos+1000;
                }
                else 
                {
                    totalIngresos = totalIngresos + 2000;
                }
            }
            return totalIngresos;
        }

        public int ContarSociosBlack()
        {
            int cantidadSociosBlack = 0;

            foreach (Socio socio in this.listaSocios)
            {
                if (socio.Membresia == ECampos.EMembresia.Black)
                {
                    cantidadSociosBlack++;
                }
            }
            return cantidadSociosBlack;
        }

        public int ContarSociosSmart()
        {
            int cantidadSociosSmart = 0;

            foreach (Socio socio in this.listaSocios)
            {
                if (socio.Membresia == ECampos.EMembresia.Smart)
                {
                    cantidadSociosSmart++;
                }
            }
            return cantidadSociosSmart;
        }

        public int CalcularTotalEgresos()
        {
            int totalEgresos = 0;

            for (int i=0; i < periodoComercial.Egresos.Count; i++)
            {
                totalEgresos = totalEgresos+periodoComercial.Egresos[0].Importe;
            }
            
            return totalEgresos;
        }
        public int CalcularResultadoDelMes()
        {
            return this.CalcularTotalIngresos()-this.CalcularTotalEgresos();
        }

        public string InformacionGestion()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Total de socios Black: {this.ContarSociosBlack()}  ");
            sb.AppendLine($"Total de socios Smart: {this.ContarSociosBlack()}  ");
            sb.AppendLine($"Total de socios: {this.ListaSocios.Count}  ");
            sb.AppendLine($"---------------------------------------------------");
            sb.AppendLine($"Total de ingresos: {this.CalcularTotalIngresos()}  ");
            sb.AppendLine($"Total de egresos: {this.CalcularTotalEgresos()}  ");
            sb.AppendLine($"Resultado del mes: {this.CalcularResultadoDelMes()}  ");
            sb.AppendLine($"---------------------------------------------------");

            return sb.ToString();
        }
    }
}
