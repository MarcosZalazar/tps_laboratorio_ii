using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesNegocio
{
    public interface IValidadorCampos
    {
        public bool ElCampoNoEstaVacio(string campo);
        public bool ValidarEleccionSexo();
        public bool ValidarEleccionFecha();
        public bool ValidarEleccionActividad();
    }
}
