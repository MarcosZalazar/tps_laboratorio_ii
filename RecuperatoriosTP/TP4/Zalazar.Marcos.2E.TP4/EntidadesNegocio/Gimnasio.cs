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
        public delegate void NotificadorNecesidadDeProfesores(string mensaje);
        public event NotificadorNecesidadDeProfesores NotificacionEnviada;

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
        /// Método que verifica si un socio se encuentra activo en la lista de socios
        /// </summary>
        /// <param name="socio">Socio a verificar</param>
        /// <returns></returns>
        public bool estaElSocioEnLaLista(Socio socioAEvaluar)
        {
            bool retorno = false;

            foreach (Socio socio in this.listaSocios)
            {
                if (socio.SocioActivo == true && socio.DniSocio == socioAEvaluar.DniSocio)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Método que verifica si un profesor se encuentra activo en la lista de profesores
        /// </summary>
        /// <param name="profesorAEvaluar">Profesor a verificar</param>
        /// <returns></returns>
        public bool estaElProfesorEnLaLista(Profesor profesorAEvaluar)
        {
            bool retorno = false;

            foreach (Profesor profesor in this.listaProfesores)
            {
                if (profesor.ProfesorActivo == true && profesor.Dni == profesorAEvaluar.Dni)
                {
                    retorno = true;
                }
            }
            return retorno;
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
        /// Método que compara la cantidad de socios y profesores y avisa en caso de que se necesiten contratar profesores.
        /// </summary>
        /// <returns> true= si se necesita contratar profesores false=la cantidad de profesores es adecuada</returns>
        public void EvaluarNecesidadDeProfesores()
        {
            Task nuevaTarea = Task.Run(() =>
            {
                int cantidadSocios = ContarSociosBlack() + ContarSociosSmart();
                int cantidadProfesores = 0;

                foreach (Profesor profesor in this.listaProfesores)
                {
                    if (profesor.ProfesorActivo == true)
                    {
                        cantidadProfesores++;
                    }
                }
                if (cantidadSocios > (cantidadProfesores * 3))
                {
                    NotificacionEnviada?.Invoke("Cantidad de profesores insuficiente. Para mantener la calidad del servicio, recuerde contratar profesores");
                }
                else 
                {
                    NotificacionEnviada?.Invoke("");
                }
            });
        }


        /// <summary>
        /// Calcula el total de ingresos en función del valor de las cuotas
        /// </summary>
        /// <returns></returns>
        public int CalcularTotalIngresos()
        {
            int totalIngresos=0;

            for (int i = 0; i < periodoComercial.Ingresos.Count; i++)
            {
                totalIngresos = totalIngresos + periodoComercial.Ingresos[i].Importe;
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
                if (socio.SocioActivo == true)
                {
                    if (socio.Membresia == ECampos.EMembresia.Black)
                    {
                        cantidadSociosBlack++;
                    }
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
                if (socio.SocioActivo == true)
                {
                    if (socio.Membresia == ECampos.EMembresia.Smart)
                    {
                        cantidadSociosSmart++;
                    }
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
                totalEgresos = totalEgresos+periodoComercial.Egresos[i].Importe;
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
            sb.AppendLine($"Total de socios: {this.ContarSociosBlack()+ this.ContarSociosSmart()}  ");
            sb.AppendLine($"---------------------------------------------------");
            sb.AppendLine($"Total de ingresos: {this.CalcularTotalIngresos()}  ");
            sb.AppendLine($"Total de egresos: {this.CalcularTotalEgresos()}  ");
            sb.AppendLine($"Resultado del mes: {this.CalcularResultadoDelMes()}  ");
            sb.AppendLine($"---------------------------------------------------");

            return sb.ToString();
        }
    }
}
