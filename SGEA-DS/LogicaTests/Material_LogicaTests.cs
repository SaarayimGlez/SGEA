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
    public class Material_LogicaTests
    {
        [TestMethod()]
        public void RegistrarMaterialTest()
        {
            Material_Logica material_Logica = new Material_Logica();
            bool recibido = material_Logica.RegistrarMaterial(new Material()
            {
                cantidad = 1,
                costo = 1,
                tipo = "tipo"
            }, 1);

            Assert.AreEqual(recibido, true);
        }
    }
}
