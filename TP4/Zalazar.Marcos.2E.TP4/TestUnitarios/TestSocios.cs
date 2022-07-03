using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesNegocio;
using System;

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
        public void Gimnasio_CuandoSeEliminaUnSocio_NoDberiaFigurarEnLaListaDeSocios()
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
    }
}
