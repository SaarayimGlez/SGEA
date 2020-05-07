using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Evento_Logica : ConexionBD_Logica
    {
        public Evento_Logica() : base()
        {
        }

        public List<Modelo.Evento> RecuperarEventos(int comiteId)
        {
            List<Modelo.Evento> listaEventos = new List<Modelo.Evento>();
            try
            {
                var listaEventosMCBD = _context.EventoSet
                    .Join(
                        _context.ComiteSet,
                        evento => evento.Id,
                        comite => comite.EventoId,
                        (evento, comite) => new
                        {
                            EventoId = evento.Id,
                            NombreEvento = evento.nombre,
                            ComiteId = comite.Id
                        }
                     ).Where(
                        comite => comite.ComiteId == comiteId
                     ).ToList();
                
                var listaEventosBD = _context.EventoSet.ToList();

                if (comiteId != 0)
                {
                    foreach (var eventoBD in listaEventosMCBD)
                    {
                        listaEventos.Add(new Modelo.Evento()
                        {
                            Id = eventoBD.EventoId,
                            nombre = eventoBD.NombreEvento
                        });
                    }
                } else
                {
                    foreach (var eventoBD in listaEventosBD)
                    {
                        listaEventos.Add(new Modelo.Evento()
                        {
                            Id = eventoBD.Id,
                            nombre = eventoBD.nombre
                        });
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listaEventos;
        }
    }
}
