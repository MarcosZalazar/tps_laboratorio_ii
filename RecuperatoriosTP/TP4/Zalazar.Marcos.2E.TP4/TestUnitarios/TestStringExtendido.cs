using EntidadesNegocio;
using GimnasioException;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitarios
{
    [TestClass]
    public class TestStringExtendido
    {
        /// <summary>
        /// Esta prueba valida que al agregar un socio el método validarDni solo permite cargar dni válidos
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CargaFormException))]
        public void ValidarDni_CuandoSeAgregaUnDniConMenosDe7Digitos_DeberiaLanzarUnaCargaFormException()
        {
            //ARRANGE
            string dniDePrueba = "123456";


            //ACT
            bool resultado=dniDePrueba.ValidarDni();

            //ASSERT
        }

        /// <summary>
        /// Esta prueba valida que al agregar un socio el método validarDni solo permite cargar dni válidos
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CargaFormException))]
        public void ValidarDni_CuandoSeAgregaUnDniNegativo_DeberiaLanzarUnaCargaFormException()
        {
            //ARRANGE
            string dniDePrueba = "-1";


            //ACT
            bool resultado = dniDePrueba.ValidarDni();

            //ASSERT
        }
    }
}
