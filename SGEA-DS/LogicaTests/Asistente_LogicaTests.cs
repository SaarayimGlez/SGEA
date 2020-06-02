using FluentAssertions;
using Logica;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTests
{
    [TestClass()]
    public class Asistente_LogicaTests
    {
        [TestMethod()]
        public void RecuperarAsistenteEventoTest()
        {
            Asistente_Logica asistente_Logica = new Asistente_Logica();
            List<string> listaRecibida = asistente_Logica.RecuperarAsistenteEvento(1);
            List<string> listaEsperada = new List<string>();
            listaEsperada.Add("Erendira Xica Andrade");

            listaRecibida.Should().BeEquivalentTo(listaEsperada);
        }
    }
}
