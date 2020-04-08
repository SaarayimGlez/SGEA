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
    public class MiembroComite_LogicaTests
    {
        [TestMethod()]
        public void ActualizarMCLiderTest()
        {
            MiembroComite_Logica miembroComiteDAO = new MiembroComite_Logica();
            bool recibido = miembroComiteDAO.ActualizarMCLider(new MiembroComite()
            {
                nombre = "",
                apellidoPaterno = "",
                apellidoMaterno = "",
                nombreUsuario = "",
                contrasenia = "",
                ComiteId = 1
            });
            Assert.AreEqual(recibido, true);
        }

        [TestMethod()]
        public void RegistrarMCLiderTest()
        {
            MiembroComite_Logica miembroComiteDAO = new MiembroComite_Logica();
            bool recibido = miembroComiteDAO.RegistrarMCLider(new MiembroComite()
            {
                nombre = "",
                apellidoPaterno = "",
                apellidoMaterno = "",
                correoElectronico = "",
                nivelExperiencia = "",
                nombreUsuario = "",
                contrasenia = "",
                evaluador = false,
                liderComite = true,
                ComiteId = 1
            });
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
                nombre = "",
                apellidoPaterno = "",
                apellidoMaterno = "",
                correoElectronico = "",
                nivelExperiencia = "",
                nombreUsuario = "",
                contrasenia = "",
                evaluador = false,
                liderComite = true,
                ComiteId = 1
            });

            CollectionAssert.AreEqual(listaEsperada, listaRecibida);
        }
    }
}