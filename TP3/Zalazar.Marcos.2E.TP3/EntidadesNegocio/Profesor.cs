using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesNegocio
{
    public class Profesor
    {
        protected int dni;
        protected string nombre;
        protected string apellido;
        protected ECampos.ESexo sexo;
        protected DateTime fechaDeContratacion;
        protected decimal salario;
        protected ECampos.Actividades actividad;

        public Profesor()
        {

        }
        public Profesor(int dni, string nombre, string apellido, ECampos.ESexo sexo, DateTime fechaDeContratacion, decimal salario, ECampos.Actividades actividad)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.sexo = sexo;
            this.fechaDeContratacion = fechaDeContratacion;
            this.salario = salario;
            this.actividad = actividad;
        }

        /// <summary>
        /// Propiedad que asigna y devuelve el dni del profesor
        /// </summary>
        public int Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = value;
            }
        }

        /// <summary>
        /// Propiedad que asigna y devuelve el nombre del profesor
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
        /// Propiedad que asigna y devuelve el apellido del profesor
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }

        /// <summary>
        /// Propiedad que asigna y devuelve el sexo del profesor
        /// </summary>
        public ECampos.ESexo Sexo
        {
            get
            {
                return this.sexo;
            }
            set
            {
                this.sexo = value;
            }
        }

        /// <summary>
        /// Propiedad que asigna y devuelve la fecha de contratacion del profesor
        /// </summary>
        public DateTime FechaDeContratacion
        {
            get
            {
                return this.fechaDeContratacion;
            }
            set
            {
                this.fechaDeContratacion = value;
            }
        }

        /// <summary>
        /// Propiedad que asigna y devuelve el salario del profesor
        /// </summary>
        public decimal Salario
        {
            get
            {
                return this.salario;
            }
            set
            {
                this.salario = value;
            }
        }
        /// <summary>
        /// Propiedad que asigna y devuelve la actividad enseñada por el profesor
        /// </summary>
        public ECampos.Actividades Actividad
        {
            get
            {
                return this.actividad;
            }
            set
            {
                this.actividad = value;
            }
        }

        /// <summary>
        /// Método que devuelve los datos del profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Dni del socio: {this.Dni} - ");
            sb.AppendLine($"Nombre:{this.Nombre} - ");
            sb.AppendLine($"Apellido:{this.Apellido} - ");
            sb.AppendLine($"Sexo:{this.Sexo} -");
            sb.AppendLine($"Fecha de contratacion:{this.fechaDeContratacion} - ");
            sb.AppendLine($"Salario:{this.Salario} - ");
            sb.AppendLine($"Actividad:{this.Actividad} ");

            return sb.ToString();
        }
    }
}
