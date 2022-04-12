using System;
using LogicaNegocio;

namespace LogicaNegocio
{
    public class Cliente
    {
        private string nombre;
        private int numero;

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
        public int Numero
        {
            get
            {
                return this.numero;
            }
        }

        public Cliente(int numero)
        { 
        }
        public Cliente()
        {
        }
    }
}
