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
        /// <summary>
        /// Propiedad que asigna y devuelve el nombre del gimnasio
        /// </summary>
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

        /// <summary>
        /// Propiedad que asigna y devuelve la lista de profesores
        /// </summary>
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

        /// <summary>
        /// Propiedad que asigna y devuelve la lista de socios
        /// </summary>
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

        /// <summary>
        /// Propiedad que asigna y devuelve el periodo comercial
        /// </summary>
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

        /// <summary>
        /// Método que imprime la ficha del socio del gimnasio
        /// </summary>
        /// <param name="socio"> un objeto del tipo socio</param>
        /// <returns></returns>
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

        /// <summary>
        /// Calcula el total de ingresos en función del valor de las cuotas
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Cuenta la cantidad de socios Black
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Cuenta la cantidad de socios Smart
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Calcular el total de egresos
        /// </summary>
        /// <returns></returns>
        public int CalcularTotalEgresos()
        {
            int totalEgresos = 0;

            for (int i=0; i < periodoComercial.Egresos.Count; i++)
            {
                totalEgresos = totalEgresos+periodoComercial.Egresos[0].Importe;
            }
            
            return totalEgresos;
        }
        /// <summary>
        /// Calcula el resultado del periodo comercial
        /// </summary>
        /// <returns></returns>
        public int CalcularResultadoDelMes()
        {
            return this.CalcularTotalIngresos()-this.CalcularTotalEgresos();
        }

        /// <summary>
        /// Provee los datos de los principales indicadores del negocio
        /// </summary>
        /// <returns></returns>
        public string InformacionGestion()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Total de socios Black: {this.ContarSociosBlack()}  ");
            sb.AppendLine($"Total de socios Smart: {this.ContarSociosSmart()}  ");
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
