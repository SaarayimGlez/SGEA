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
    public class Patrocinador_LogicaTests
    {
        [TestMethod()]
        public void RegistrarPatrocinadorTest()
        {
            Patrocinador_Logica patrocinadorDAO = new Patrocinador_Logica();
            bool recibido = patrocinadorDAO.RegistrarPatrocinador(new Patrocinador()
            {
                nombre = "nombre PRUEBA",
                apellidoPaterno = "apellido paterno PRUEBA",
                apellidoMaterno = "apellido materno PRUEBA",
                empresa = "empresa PRUEBA",
                direccion = "direccion PRUEBA",
                correoElectronico = "correoElectronico@PRUEBA.com",
                numeroTelefono = "1215920816"
            });
            Assert.AreEqual(recibido, true);
        }

        [TestMethod()]
        public void RecuperarPatrocinadorTest()
        {
            Patrocinador_Logica patrocinadorDAO = new Patrocinador_Logica();
            List<Patrocinador> listaRecibida = patrocinadorDAO.RecuperarPatrocinador();
            List<Patrocinador> listaEsperada = new List<Patrocinador>();
            listaEsperada.Add(new Patrocinador()
            {
                nombre = "Miguel",
                apellidoPaterno = "Hernandez",
                apellidoMaterno = "Duran",
                empresa = "Comex",
                direccion = "Lucio #15 Col. Lomas de Casa Blanca",
                correoElectronico = "promoComex@comex.com",
                numeroTelefono = "8465972"

            });
            listaEsperada.Add(new Patrocinador()
            {
                nombre = "Jimena",
                apellidoPaterno = "Suarez",
                apellidoMaterno = "Potrillo",
                empresa = "Chedraui",
                direccion = "Chedrahui Caram #20 Col. Centro",
                correoElectronico = "patrocinios@chedrahui.com",
                numeroTelefono = "8465963"
            });

            listaRecibida.Should().BeEquivalentTo(listaEsperada);
        }
    }
}