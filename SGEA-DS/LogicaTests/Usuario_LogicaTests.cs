using FluentAssertions;
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
    public class Usuario_LogicaTests
    {
        [TestMethod()]
        public void RegistrarUsuarioTest()
        {
            Usuario_Logica usuario_Logica = new Usuario_Logica();
            bool recibido = usuario_Logica.RegistrarUsuario(new Usuario()
            {
                contrasenia = "contrasena",
                nombreUsuario = "usuario"
            });
            Assert.AreEqual(recibido, true);
        }

        [TestMethod()]
        public void RecuperarUsuarioTest()
        {
            Usuario_Logica usuario_Logica = new Usuario_Logica();
            List<Usuario> listaRecibida = usuario_Logica.RecuperarUsuario();
            List<Usuario> listaEsperada = new List<Usuario>();
            listaEsperada.Add(new Usuario()
            {
                Id = 1,
                contrasenia = "88loona",
                nombreUsuario = "organizador1"
            });
            listaEsperada.Add(new Usuario()
            {
                Id = 2,
                contrasenia = "1m4o",
                nombreUsuario = "miembro2"
            });
            listaEsperada.Add(new Usuario()
            {
                Id = 4,
                contrasenia = "aa",
                nombreUsuario = "miembroL"
            });
            listaEsperada.Add(new Usuario()
            {
                Id = 5,
                contrasenia = "aa",
                nombreUsuario = "miembroEv"
            });
            listaEsperada.Add(new Usuario()
            {
                Id = 6,
                contrasenia = "aa",
                nombreUsuario = "miembroLEv"
            });

            listaRecibida.Should().BeEquivalentTo(listaEsperada);
        }

        [TestMethod()]
        public void ComprobarUsuarioTest()
        {
            Usuario_Logica usuario_Logica = new Usuario_Logica();
            int recibido = 
                usuario_Logica.ComprobarUsuario("organizador1", "88loona");
            Assert.AreEqual(recibido, 1);
        }
    }
}
