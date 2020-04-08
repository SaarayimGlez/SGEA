using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                nombre = "",
                apellidoPaterno = "",
                apellidoMaterno = "",
                empresa = "",
                direccion = "",
                correoElectronico = "",
                numeroTelefono = ""
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
                nombre = "",
                apellidoPaterno = "",
                apellidoMaterno = "",
                empresa = "",
                direccion = "",
                correoElectronico = "",
                numeroTelefono = ""
            });
            listaEsperada.Add(new Patrocinador()
            {
                nombre = "",
                apellidoPaterno = "",
                apellidoMaterno = "",
                empresa = "",
                direccion = "",
                correoElectronico = "",
                numeroTelefono = ""
            });

            CollectionAssert.AreEqual(listaEsperada, listaRecibida);
        }
    }
}