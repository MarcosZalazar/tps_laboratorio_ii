using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesNegocio
{
    public class Socio
    {
        protected int dniSocio;
        protected string nombre;
        protected string apellido;
        protected ECampos.ESexo sexo;
        protected DateTime fechaDeAlta;
        protected ECampos.EMembresia membresia;
        public List<ECampos.Actividades> listaActividades;

        public Socio()
        {
            
        }
        
        public Socio(int dniSocio, string nombre, string apellido, ECampos.ESexo sexo, DateTime fechaDeAlta, ECampos.EMembresia membresia) 
        {
            this.dniSocio = dniSocio;
            this.nombre = nombre;
            this.apellido = apellido;
            this.sexo = sexo;
            this.fechaDeAlta = fechaDeAlta;
            this.membresia = membresia;
            this.listaActividades = new List<ECampos.Actividades>();
        }
        public int DniSocio
        { 
            get 
            { 
                return this.dniSocio; 
            }
            set
            {
                this.dniSocio = value;
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
        public DateTime FechaDeAlta
        {
            get
            {
                return this.fechaDeAlta;
            }
            set
            {
                this.fechaDeAlta = value;
            }
        }
        public ECampos.EMembresia Membresia
        {
            get
            {
                return this.membresia;
            }
            set
            {
                this.membresia = value;
            }
        }
        public List<ECampos.Actividades> ListaActividades
        {
            get
            {
                return this.listaActividades;
            }
            set
            {
                this.listaActividades = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Dni del socio: {this.DniSocio}  ");
            sb.AppendLine($"Nombre:{this.Nombre}  ");
            sb.AppendLine($"Apellido:{this.Apellido}  ");
            sb.AppendLine($"Sexo:{this.Sexo}  ");
            sb.AppendLine($"Fecha de alta:{this.FechaDeAlta}  ");
            sb.AppendLine($"Membresia:{this.Membresia}  ");
            sb.AppendLine($"Actividades: ");

            foreach (ECampos.Actividades actividad in listaActividades)
            {
                sb.AppendLine($" {actividad} ");
            }
            return sb.ToString();
        }

    }
}
