using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesNegocio;
using System;
using GimnasioException;

namespace TestUnitarios
{
    [TestClass]
    public class TestSocios
    {
        [TestMethod]
        public void Gimnasio_CuandoSeCreaUnGimnasio_DeberiaTenerUnaListaDeSocios()
        {
            //ARRANGE
            Gimnasio gimnasioPrueba = new Gimnasio("GimnasioDePrueba");

            //ACT

            //ASSERT
            Assert.IsNotNull(gimnasioPrueba.ListaSocios);
        }
        [TestMethod]
        public void Gimnasio_CuandoSeCargaUnSocio_DeberiaFigurarEnLaListaDeSocios()
        {
            //ARRANGE
            Gimnasio gimnasioPrueba = new Gimnasio();
            Socio socioPrueba = new Socio(31661766,"Juan","Lopez", ECampos.ESexo.Femenino,new DateTime(2004,01,01),ECampos.EMembresia.Black);
            bool expected = true;
            bool actual=false;

            //ACT
            gimnasioPrueba.ListaSocios.Add(socioPrueba);
            foreach (Socio socio in gimnasioPrueba.ListaSocios)
            {
                if (socio == socioPrueba)
                { 
                    actual = true;
                }
            }

            //ASSERT
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void Gimnasio_CuandoSeEliminaUnSocio_NoDeberiaFigurarEnLaListaDeSocios()
        {
            //ARRANGE
            Gimnasio gimnasioPrueba2 = new Gimnasio();
            Socio socioPrueba2 = new Socio(45122356, "Miguel", "Lopez", ECampos.ESexo.Masculino, new DateTime(2002, 01, 01), ECampos.EMembresia.Smart);
            gimnasioPrueba2.ListaSocios.Add(socioPrueba2);
            bool fueBorradoExpected = true;
            bool fueBorradoActual = false;

            //ACT
            gimnasioPrueba2.ListaSocios.Remove(socioPrueba2);
            foreach (Socio socio in gimnasioPrueba2.ListaSocios)
            {
                if (socio == socioPrueba2)
                {
                    fueBorradoActual = true;
                }
            }

            //ASSERT
            Assert.AreNotEqual(fueBorradoExpected, fueBorradoActual);
        }

        [TestMethod]
        [ExpectedException(typeof(PersonaException))]
        public void Gimnasio_CuandoSeAgregaUnSocio_NoDeberiaEstarEnLaListaDeSociosActivos()
        {
            //ARRANGE
            Gimnasio gimnasioPrueba3 = new Gimnasio();
            Socio socioPrueba3 = new Socio(12345678, "Juan", "Almeyda", ECampos.ESexo.Masculino, new DateTime(2003, 01, 01), ECampos.EMembresia.Black);
            gimnasioPrueba3.ListaSocios.Add(socioPrueba3);

            //ACT
            Socio socioPrueba4 = new Socio(12345678, "Pedro", "Palacios", ECampos.ESexo.Masculino, new DateTime(2007, 01, 01), ECampos.EMembresia.Smart);
            if (gimnasioPrueba3.estaElSocioEnLaLista(socioPrueba4) == false)
            {
                gimnasioPrueba3.ListaSocios.Add(socioPrueba4);
            }
            else
            {
                throw new PersonaException("Intento de carga duplicada de profesor");
            }

            //ASSERT

        }

        [TestMethod]
        [ExpectedException(typeof(PersonaException))]
        public void Gimnasio_CuandoSeAgregaUnProfesor_NoDeberiaEstarEnLaListaDeProfesoresActivos()
        {
            //ARRANGE
            Gimnasio gimnasioPrueba4 = new Gimnasio();
            Profesor profesorPrueba1 = new Profesor(12345679, "Miguel", "Juarez", ECampos.ESexo.Masculino, new DateTime(2009, 01, 01),5500, ECampos.Actividades.Aerobics);
            gimnasioPrueba4.listaProfesores.Add(profesorPrueba1);

            //ACT
            Profesor profesorPrueba2 = new Profesor(12345679, "Lucas", "Palacios", ECampos.ESexo.Masculino, new DateTime(2008, 01, 01),10000, ECampos.Actividades.Spinning);
            if (gimnasioPrueba4.estaElProfesorEnLaLista(profesorPrueba2) == false)
            {
                gimnasioPrueba4.listaProfesores.Add(profesorPrueba2);
            }
            else
            {
                throw new PersonaException("Intento de carga duplicada de profesor");
            }

            //ASSERT

        }

        [TestMethod]
        public void Gimnasio_CuandoSeAgregaUnSocio_DeberiaTenerUnDniValido()
        {
            //ARRANGE
            string dniDePrueba="154523";
            bool expected=false;
            bool actual;

            //ACT
            if (dniDePrueba.ValidarDni())
            {
                actual = true;
            }
            else
            {
                actual = false;
            }

            //ASSERT
            Assert.AreEqual(expected, actual);
        }

    }
}
