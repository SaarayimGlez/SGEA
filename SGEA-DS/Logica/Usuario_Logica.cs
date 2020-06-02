using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class Usuario_Logica : ConexionBD_Logica
    {
        public Usuario_Logica() : base()
        {
        }

        public bool RegistrarUsuario(Modelo.Usuario usuario)
        {
            bool respuesta = false;
            try
            {
                _context.UsuarioSet.Add(new Usuario() {
                    contrasenia = usuario.contrasenia,
                    nombreUsuario = usuario.nombreUsuario
                });
                _context.SaveChanges();
                respuesta = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return respuesta;
        }

        public List<Modelo.Usuario> RecuperarUsuario()
        {
            List<Modelo.Usuario> listaUsuario = new List<Modelo.Usuario>();
            try
            {
                var listaUsuarioBD = _context.UsuarioSet.ToList();
                foreach (Usuario usuarioBD in listaUsuarioBD)
                {
                    listaUsuario.Add(new Modelo.Usuario()
                    {
                        Id = usuarioBD.Id,
                        contrasenia = usuarioBD.contrasenia,
                        nombreUsuario = usuarioBD.nombreUsuario
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listaUsuario;
        }

        public int ComprobarUsuario(string usuario, string contrasenia)
        {
            int idUsuario = 0;
            try
            {
                var usuarioBD = _context.UsuarioSet
                    .Where(
                        usuarioRecuperado => usuarioRecuperado.nombreUsuario == usuario
                        && usuarioRecuperado.contrasenia == contrasenia
                    ).First<Usuario>(); ;

                if (usuarioBD != null)
                {
                    idUsuario = usuarioBD.Id;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return idUsuario;
        }
    }
}
