using FluentAssertions;
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
    public class Autor_LogicaTests
    {
        [TestMethod()]
        public void RecuperarProgramaEventoTest()
        {
            Autor_Logica autor_Logica = new Autor_Logica();
            List<List<string>> listaRecibida = autor_Logica.RecuperarAutorEvento(1);
            List<List<string>> listaEsperada = new List<List<string>>();
            /*listaEsperada.Add(new List<string>(new string[]
                {
                    "",/*nombre completo/
                    ""/*fecha MM/dd/yyyy/
                }));*/

            listaRecibida.Should().BeEquivalentTo(listaEsperada);
        }

        [TestMethod()]
        public void RecuperarAutorTest()
        {
            Autor_Logica autor_Logica = new Autor_Logica();
            List<List<string>> listaRecibida = autor_Logica.RecuperarAutor();
            List<List<string>> listaEsperada = new List<List<string>>();
            listaEsperada.Add(new List<string>(new string[]
                {
                    "María José",/*nombre*/
                    "Lares",/*apellidoPaterno*/
                    "Fernandez",/*apellidoMaterno*/
                    "Fernandez",/*apellidoMaterno*/
                    "majo1991@outlook.com",/*correoElectronico*/
                    "(Ningún artículo)",/*articulo*/
                }));

            listaRecibida.Should().BeEquivalentTo(listaEsperada);
        }
    }
}
