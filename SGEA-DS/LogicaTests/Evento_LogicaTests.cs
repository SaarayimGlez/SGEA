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
    public class Evento_LogicaTests
    {
        [TestMethod()]
        public void RecuperarEventosTest()
        {
            Evento_Logica evento_Logica = new Evento_Logica();
            List<Evento> listaRecibida = evento_Logica.RecuperarEventos(1);
            List<Evento> listaEsperada = new List<Evento>();
            listaEsperada.Add(new Evento()
            {
                Id = 1,
                nombre = "Dia de la SALUD",
                institucionOrganizadora = "Licenciatura en Ingeniería de Software",
                lugar = "Facultad de Estadistica e Informatica"
            });

            listaRecibida.Should().BeEquivalentTo(listaEsperada);
        }

        [TestMethod()]
        public void RecuperarEventoTest()
        {
            Evento_Logica evento_Logica = new Evento_Logica();
            Evento eventoRecibida = evento_Logica.RecuperarEvento(1);
            Evento eventoEsperada = new Evento()
            {
                nombre = "Dia de la SALUD",
                institucionOrganizadora = "Licenciatura en Ingeniería de Software",
                lugar = "Facultad de Estadistica e Informatica",
                fechaInicio = new DateTime(2020, 01, 02),
                fechaFin = new DateTime(2020, 01, 02)
            };

            eventoRecibida.Should().BeEquivalentTo(eventoEsperada);
        }

        [TestMethod()]
        public void ModificarEventoTest()
        {
            Evento_Logica evento_Logica = new Evento_Logica();
            bool recibido = evento_Logica.ModificarEvento(new Evento()
            {
                nombre = "Dia de la SALUD",
                institucionOrganizadora = "Licenciatura en Ingeniería de Software",
                lugar = "Facultad de Estadistica e Informatica",
                fechaInicio = new DateTime(2020, 01, 02),
                fechaFin = new DateTime(2020, 01, 02)
            });
            Assert.AreEqual(recibido, true);
        }
    }
}
