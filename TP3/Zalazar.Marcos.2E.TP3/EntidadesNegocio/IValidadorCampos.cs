using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesNegocio
{
    public interface IValidadorCampos
    {
        /// <summary>
        /// Verifica que un campo determinado no esté vacío
        /// </summary>
        /// <param name="campo"> campo a evaluar</param>
        /// <returns></returns>
        public bool ElCampoNoEstaVacio(string campo);

        /// <summary>
        /// Valida que se haya elegido un valor para el campo sexo
        /// </summary>
        /// <returns></returns>
        public bool ValidarEleccionSexo();

        /// <summary>
        /// Valida que se haya elegido un valor para el campo fecha
        /// </summary>
        /// <returns></returns>
        public bool ValidarEleccionFecha();

        /// <summary>
        /// Valida que se haya elegido un valor para el campo actividad
        /// </summary>
        /// <returns></returns>
        public bool ValidarEleccionActividad();
    }
}
