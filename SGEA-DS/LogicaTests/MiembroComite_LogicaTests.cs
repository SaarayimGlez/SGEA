using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

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
                nombre = "Antonio",
                apellidoPaterno = "Morales",
                apellidoMaterno = "Lopez",
                correoElectronico = "anmolo@uv.mx",
                nivelExperiencia = "Doctorado",
                evaluador = false,
                liderComite = false,
                ComiteId = 1,
                idUsuario = 2
            });
            foreach (var miembro in listaRecibida.Zip(listaEsperada, Tuple.Create))
            {
                Assert.AreEqual(miembro.Item1.nombre, miembro.Item2.nombre);
                Assert.AreEqual(miembro.Item1.apellidoPaterno, miembro.Item2.apellidoPaterno);
                Assert.AreEqual(miembro.Item1.apellidoMaterno, miembro.Item2.apellidoMaterno);
                Assert.AreEqual(miembro.Item1.correoElectronico, miembro.Item2.correoElectronico);
                Assert.AreEqual(miembro.Item1.nivelExperiencia, miembro.Item2.nivelExperiencia);
                Assert.AreEqual(miembro.Item1.idUsuario, miembro.Item2.idUsuario);
                Assert.AreEqual(miembro.Item1.evaluador, miembro.Item2.evaluador);
                Assert.AreEqual(miembro.Item1.liderComite, miembro.Item2.liderComite);
                Assert.AreEqual(miembro.Item1.ComiteId, miembro.Item2.ComiteId);
            }
        }
    }
}