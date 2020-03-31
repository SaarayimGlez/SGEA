using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class PatrocinadorDAO
    {
        private DataModelContainer _context;

        public PatrocinadorDAO()
        {
            _context = new DataModelContainer();
        }

        public bool RegistrarPatrocinador(Patrocinador patrocinador)
        {
            bool respuesta = false;
            try
            {
                var patrocinadorRepetido = _context.PatrocinadorSet
                    .Where(
                        patrocinadorR => patrocinadorR.nombre.Equals(patrocinador.nombre)
                        && patrocinadorR.apellidoPaterno.Equals(patrocinador.apellidoPaterno)
                        && patrocinadorR.apellidoMaterno.Equals(patrocinador.apellidoMaterno)
                    ).ToList();
                if (patrocinadorRepetido.Count == 0)
                {
                    _context.PatrocinadorSet.Add(patrocinador);
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
    }
}
