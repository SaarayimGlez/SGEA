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
    public class Comite_LogicaTests
    {
        [TestMethod()]
        public void RecuperarComitesSinLiderTest()
        {
            Comite_Logica comiteDAO = new Comite_Logica();
            List<string> listaRecibida = comiteDAO.RecuperarComitesSinLider(1);
            List<string> listaEsperada = new List<string>();
            listaEsperada.Add("Comite de promocion -- 1");
            listaEsperada.Add("Comite del dia -- 8");
            CollectionAssert.AreEqual
                (
                    listaEsperada.SelectMany(item => item).ToList(),
                    listaRecibida.SelectMany(item => item).ToList()
                );
        }

        [TestMethod()]
        public void RegistrarComiteTest()
        {
            Comite_Logica comiteDAO = new Comite_Logica();
            bool recibido = comiteDAO.RegistrarComite(new Comite()
            {
                nombre = "comite PRUEBA",
                descripcion = "descripcion PRUEBA",
                EventoId = 1
            });
            Assert.AreEqual(recibido, true);
        }
    }
}