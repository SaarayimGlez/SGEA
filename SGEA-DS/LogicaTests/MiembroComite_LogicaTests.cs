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
    public class MiembroComite_LogicaTests
    {
        [TestMethod()]
        public void ActualizarMCLiderTest()
        {
            MiembroComite_Logica miembroComiteDAO = new MiembroComite_Logica();
            bool recibido = miembroComiteDAO.ActualizarMCLider(new MiembroComite()
            {
                nombre = "nombre PRUEBA",
                apellidoPaterno = "apellido paterno PRUEBA",
                apellidoMaterno = "apellido materno PRUEBA",
                ComiteId = 1
            }, 2);
            Assert.AreEqual(recibido, true);
        }

        [TestMethod()]
        public void RegistrarMCLiderTest()
        {
            MiembroComite_Logica miembroComiteDAO = new MiembroComite_Logica();
            bool recibido = miembroComiteDAO.RegistrarMCLider(new MiembroComite()
            {
                nombre = "nombre PRUEBA",
                apellidoPaterno = "apellido paterno PRUEBA",
                apellidoMaterno = "apellido materno PRUEBA",
                correoElectronico = "correroElectronico@PRUEBA.com",
                nivelExperiencia = "Licenciatura",
                evaluador = false,
                liderComite = true,
                ComiteId = 1
            }, 2);
            Assert.AreEqual(recibido, true);
        }

        [TestMethod()]
        public void RecuperarMCNoLiderTest()
        {
            MiembroComite_Logica miembroComiteDAO = new MiembroComite_Logica();
            List<MiembroComite> listaRecibida = miembroComiteDAO.RecuperarMCNoLider();
            List<MiembroComite> listaEsperada = new List<MiembroComite>();
            listaEsperada.Add(new MiembroComite()
            {
                nombre = "Huleria",
                apellidoPaterno = "Waltz",
                apellidoMaterno = "Becerra",
                correoElectronico = "huwab@uv.mx",
                nivelExperiencia = "Licenciatura"
            });
            listaEsperada.Add(new MiembroComite()
            {
                nombre = "Joaquin",
                apellidoPaterno = "Torres",
                apellidoMaterno = "Yatra",
                correoElectronico = "jotoya@uv.mx",
                nivelExperiencia = "Licenciatura"
            });

            listaRecibida.Should().BeEquivalentTo(listaEsperada);
        }

        [TestMethod()]
        public void RecuperarMiembroComiteTest()
        {
            MiembroComite_Logica miembroComite_Logica = new MiembroComite_Logica();
            MiembroComite miembroComiteRecibido = 
                miembroComite_Logica.RecuperarMiembroComite(2);
            MiembroComite miembroComiteEsperado = new MiembroComite()
            {
                Id = 2,
                idUsuario = 2,
                ComiteId = 1,
                evaluador = false,
                liderComite = false
            };

            miembroComiteRecibido.Should().BeEquivalentTo(miembroComiteEsperado);
        }

        [TestMethod()]
        public void RecuperarMiembroComitePorEventoTest()
        {
            MiembroComite_Logica miembroComiteDAO = new MiembroComite_Logica();
            List<MiembroComite> listaRecibida = 
                miembroComiteDAO.RecuperarMiembroComitePorEvento(1);
            List<MiembroComite> listaEsperada = new List<MiembroComite>();
            listaEsperada.Add(new MiembroComite()
            {
                nombre = "Junipero",
                apellidoPaterno = "Veraz",
                apellidoMaterno = "Loeira"
            });
            listaEsperada.Add(new MiembroComite()
            {
                nombre = "Huleria",
                apellidoPaterno = "Waltz",
                apellidoMaterno = "Becerra"
            });

            listaRecibida.Should().BeEquivalentTo(listaEsperada);
        }
    }
}