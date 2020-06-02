using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using FluentAssertions;

namespace Logica.Tests
{
    [TestClass()]
    public class Adscripcion_LogicaTests
    {
        [TestMethod()]
        public void RecuperarAdscripcionTest()
        {
            Adscripcion_Logica adscripcion_Logica = new Adscripcion_Logica();
            Adscripcion adscripcionRecibida = adscripcion_Logica.RecuperarAdscripcion(1);
            Adscripcion adscripcionEsperada = new Adscripcion {
                    Id = 1,
                    ciudad = "Xalapa",
                    direccion = "Merida #20 Col. Vasconcelos",
                    correoElectronico = "hejogu@uv.mx",
                    estado = "Veracruz",
                    nombre = "Canal 11 (Canal Once)"
            };

            adscripcionRecibida.Should().BeEquivalentTo(adscripcionEsperada);
        }

        [TestMethod()]
        public void ModificarAdscripcionTest()
        {
            Adscripcion_Logica adscripcion_Logica = new Adscripcion_Logica();
            bool recibido = adscripcion_Logica.ModificarAdscripcion(new Adscripcion()
            {
                ciudad = "Xalapa",
                direccion = "Merida #20 Col. Vasconcelos",
                correoElectronico = "hejogu@uv.mx",
                estado = "Veracruz",
                nombre = "Canal 11 (Canal Once)"
            });
            Assert.AreEqual(recibido, true);
        }
    }
}