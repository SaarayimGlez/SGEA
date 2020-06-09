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
    public class Magistral_LogicaTests
    {
        [TestMethod()]
        public void RecuperarMagistralTest()
        {
            Magistral_Logica magistral_Logica = new Magistral_Logica();
            List<Magistral> listaRecibida = magistral_Logica.RecuperarMagistral();
            List<Magistral> listaEsperada = new List<Magistral>();
            listaEsperada.Add(new Magistral()
            {
                Id = 2,
                nombre = "Herendira",
                apellidoPaterno = "Joaquines",
                apellidoMaterno = "Gutierrez",
                AdscripcionId = 1
            });

            listaRecibida.Should().BeEquivalentTo(listaEsperada);
        }

        [TestMethod()]
        public void ModificarMagistralTest()
        {
            Magistral_Logica magistral_Logica = new Magistral_Logica();
            bool recibido = magistral_Logica.ModificarMagistral(new Magistral()
            {
                nombre = "Herendira",
                apellidoPaterno = "Joaquines",
                apellidoMaterno = "Gutierrez"
            });
            Assert.AreEqual(recibido, true);
        }

        [TestMethod()]
        public void RecuperarMagistralEventoTest()
        {
            Magistral_Logica magistral_Logica = new Magistral_Logica();
            List<List<string>> listaRecibida = magistral_Logica.RecuperarMagistralEvento(1);
            List<List<string>> listaEsperada = new List<List<string>>();
            listaEsperada.Add(new List<string>(new string[]
                {
                    "Herendira Joaquines Gutierrez",/*nombre completo*/
                    "02/02/2020"/*fecha MM/dd/yyyy*/
                }));

            listaRecibida.Should().BeEquivalentTo(listaEsperada);
        }
    }
}
