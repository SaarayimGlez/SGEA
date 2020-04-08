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
    public class Actividad_LogicaTests
    {
        [TestMethod()]
        public void RecuperarProgramaEventoTest()
        {
            Actividad_Logica actividadDAO = new Actividad_Logica();
            List<List<string>> listaRecibida = actividadDAO.RecuperarProgramaEvento(1);
            List<List<string>> listaEsperada = new List<List<string>>();
            listaEsperada.Add(new List<string>(new string[] 
                {
                    "Inauguracion",
                    "0"/*costo*/,
                    "02/02/2020"/*fecha*/,
                    "13:00"/*horaInicio*/,
                    "14:00"/*horaFin*/,
                    "Explanada",
                    "Acto protocolario",
                    ""/*particpante*//*,
                    magistral o autor*/
                }));

            CollectionAssert.AreEqual(
                    listaEsperada.SelectMany(item => item).ToList(),
                    listaRecibida.SelectMany(item => item).ToList()
                );
        }
    }
}