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
