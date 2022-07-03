using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

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
        [XmlIgnoreAttribute]
        public List<ECampos.Actividades> listaActividades;
        protected bool socioActivo;

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
            this.socioActivo = true;
        }

        /// <summary>
        /// Propiedad que asigna y devuelve el dni del socio
        /// </summary>
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

        /// <summary>
        /// Propiedad que asigna y devuelve el nombre del socio
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
        /// Propiedad que asigna y devuelve el apellido del socio
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
        /// Propiedad que asigna y devuelve el sexo del socio
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
        /// Propiedad que asigna y devuelve la fecha de alta del socio
        /// </summary>
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

        /// <summary>
        /// Propiedad que asigna y devuelve la membresia contratad por el socio
        /// </summary>
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

        /// <summary>
        /// Propiedad que asigna y devuelve la actividad elegida por el socio
        /// </summary>
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

        /// <summary>
        /// Propiedad que asigna y devuelve el estado del socio
        /// </summary>
        public bool SocioActivo
        {
            get
            {
                return this.socioActivo;
            }
            set
            {
                this.socioActivo = value;
            }
        }

        /// <summary>
        /// Método que devuelve los datos del socio
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Dni del socio: {this.dniSocio}  ");
            sb.AppendLine($"Nombre:{this.nombre}  ");
            sb.AppendLine($"Apellido:{this.apellido}  ");
            sb.AppendLine($"Sexo:{this.sexo}  ");
            sb.AppendLine($"Fecha de alta:{this.fechaDeAlta}  ");
            sb.AppendLine($"Membresia:{this.membresia}  ");
            sb.AppendLine($"Actividades: ");

            foreach (ECampos.Actividades actividad in listaActividades)
            {
                sb.AppendLine($" {actividad} ");
            }
            return sb.ToString();
        }

    }
}
