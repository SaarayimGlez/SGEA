using FluentAssertions;
using Logica;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTests
{
    [TestClass()]
    public class Egreso_LogicaTests
    {
        [TestMethod()]
        public void RegistrarEgresoTest()
        {
            Egreso_Logica egreso_Logica = new Egreso_Logica();
            bool recibido = egreso_Logica.RegistrarEgreso(new Egreso()
            {
                concepto = "conceptoNuevo",
                monto = 1,
                fecha = DateTime.Now
            });

            Assert.AreEqual(recibido, true);
        }

        [TestMethod()]
        public void RecuperarEgresoTest()
        {
            Egreso_Logica egreso_Logica = new Egreso_Logica();
            List<Egreso> listaRecibida = egreso_Logica.RecuperarEgreso();
            List<Egreso> listaEsperada = new List<Egreso>();
            listaEsperada.Add(new Egreso()
            {
                Id = 2,
                concepto = "compra sillas",
                fecha = new DateTime(2020, 04, 12),
                monto = 150
            });
            listaEsperada.Add(new Egreso()
            {
                Id = 3,
                concepto = "prueba parte dos",
                fecha = new DateTime(2020, 04, 12),
                monto = 46485
            });
            listaEsperada.Add(new Egreso()
            {
                Id = 7,
                concepto = "PruebaFinal",
                fecha = new DateTime(2020, 04, 17),
                monto = 38
            });


            listaRecibida.Should().BeEquivalentTo(listaEsperada);
        }
    }
}
