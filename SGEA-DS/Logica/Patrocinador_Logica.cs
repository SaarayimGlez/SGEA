using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class Patrocinador_Logica : ConexionBD_Logica
    {

        public Patrocinador_Logica() : base()
        {
        }

        public bool RegistrarPatrocinador(Modelo.Patrocinador patrocinador)
        {
            bool respuesta = false;
            try
            {
                var patrocinadorRepetido = _context.PatrocinadorSet
                    .Where(
                        patrocinadorR => patrocinadorR.empresa.Equals(patrocinador.empresa)
                    ).ToList();
                if (patrocinadorRepetido.Count == 0)
                {
                    _context.PatrocinadorSet.Add(new Patrocinador() {
                        apellidoMaterno = patrocinador.apellidoMaterno,
                        apellidoPaterno = patrocinador.apellidoPaterno,
                        correoElectronico = patrocinador.correoElectronico,
                        direccion = patrocinador.direccion,
                        empresa = patrocinador.empresa,
                        nombre = patrocinador.nombre,
                        numeroTelefono = patrocinador.numeroTelefono
                    });
                    _context.SaveChanges();
                    respuesta = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return respuesta;
        }

        public List<Modelo.Patrocinador> RecuperarPatrocinador()
        {
            List<Modelo.Patrocinador> listaPatrocinador = new List<Modelo.Patrocinador>();
            try
            {
                var listaPatrocinadorBD = _context.PatrocinadorSet.ToList();

                foreach (Patrocinador patrocinadorBD in listaPatrocinadorBD)
                {
                    listaPatrocinador.Add(new Modelo.Patrocinador()
                    {
                        apellidoMaterno = patrocinadorBD.apellidoMaterno,
                        apellidoPaterno = patrocinadorBD.apellidoPaterno,
                        correoElectronico = patrocinadorBD.correoElectronico,
                        direccion = patrocinadorBD.direccion,
                        empresa = patrocinadorBD.empresa,
                        nombre = patrocinadorBD.nombre,
                        numeroTelefono = patrocinadorBD.numeroTelefono
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listaPatrocinador;
        }
    }
}
