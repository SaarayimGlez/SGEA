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
    public class RegistroArticulo_LogicaTests
    {
        [TestMethod()]
        public void RecuperarAutorTest()
        {
            RegistroArticulo_Logica registroArticulo_Logica = new RegistroArticulo_Logica();
            string esperado = "";
            string recibido = registroArticulo_Logica.RecuperarAutor(new Articulo());
            Assert.AreEqual(esperado, recibido);
        }
    }
}