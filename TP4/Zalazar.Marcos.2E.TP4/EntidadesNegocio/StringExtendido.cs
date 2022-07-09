using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesNegocio
{
    public static class StringExtendido
    {
        /// <summary>
        /// Método que valida si el número ingresado es un dni válido
        /// </summary>
        /// <param name="dniAValidar"> Dni a validar</param>
        /// <returns></returns>
        public static bool ValidarDni(this string dniAValidar)
        {
            bool retorno = false;

            int auxDniInt = int.Parse(dniAValidar);

            if ((auxDniInt > 0 && auxDniInt < 99999999) && (dniAValidar.Length==7 || dniAValidar.Length== 8))
            { 
                retorno = true;
            }
            return retorno;
        }
    }
}
