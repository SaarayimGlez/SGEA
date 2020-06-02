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
    public class Participante_LogicaTests
    {
        [TestMethod()]
        public void RecuperarParticipanteEventoTest()
        {
            Participante_Logica participante_Logica = new Participante_Logica();
            List<List<string>> listaRecibida = 
                participante_Logica.RecuperarParticipanteEvento(1);
            List<List<string>> listaEsperada = new List<List<string>>();
            listaEsperada.Add(new List<string>(new string[]
                {
                    "Andrea Williams Gomez",/*nombre completo*/
                    "02/02/2020"/*fecha MM/dd/yyyy*/
                }));

            listaRecibida.Should().BeEquivalentTo(listaEsperada);
        }
    }
}
