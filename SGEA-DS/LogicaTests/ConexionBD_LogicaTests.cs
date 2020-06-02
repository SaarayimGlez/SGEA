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
    public class ConexionBD_LogicaTests
    {
        [TestMethod()]
        public void ComprobarConexionTest()
        {
            ConexionBD_Logica conexionBD_Logica = new ConexionBD_Logica();
            bool recibido = conexionBD_Logica.ComprobarConexion();
            Assert.AreEqual(recibido, true);
        }
    }
}
