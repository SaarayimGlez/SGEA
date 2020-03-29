using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ComiteDAO
    {
        private DataModelContainer _context;

        public ComiteDAO()
        {
            _context = new DataModelContainer();
        }

        public List<string> RecuperarComitesSinLider(int eventoId)
        {
            List<string> listaComite = new List<string>();
            try
            {
                var comiteSinLider = _context.ComiteSet
                    .Join(
                        _context.EventoSet,
                        comite => comite.EventoId,
                        evento => evento.Id,
                        (comite, evento) => new
                        {
                            EventoId = evento.Id,
                            ComiteId = comite.Id,
                            NombreComite = comite.nombre
                        }
                     )
                     .GroupJoin(
                        _context.MiembroComiteSet,
                        comite => comite.ComiteId,
                        miembro => miembro.ComiteId,
                        (x, y) => new
                        {
                            Comite = x,
                            MiembroComite = y
                        }
                     )
                     .SelectMany(
                        x => x.MiembroComite.DefaultIfEmpty(),
                        (x, y) => new
                        {
                            Comite = x.Comite,
                            MiembroComite = y
                        }
                     ).Where(
                        evento => evento.Comite.EventoId == eventoId 
                        && (
                            evento.MiembroComite.liderComite == false 
                            || evento.MiembroComite.liderComite == null
                        )
                     );

                foreach (var lista in comiteSinLider)
                {
                    listaComite.Add(lista.Comite.NombreComite + " -- " + lista.Comite.ComiteId);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listaComite;
        }

        public bool RegistrarComite(Comite comite)
        {
            bool respuesta = false;
            try
            {
                _context.ComiteSet.Add(comite);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return respuesta;
        }
    }
}
