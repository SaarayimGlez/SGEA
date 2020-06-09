using System;
using System.Collections.Generic;
using System.Linq;

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
                            InstitucionOrganizadora = evento.institucionOrganizadora,
                            Lugar = evento.lugar,
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
                            nombre = eventoBD.NombreEvento,
                            institucionOrganizadora = eventoBD.InstitucionOrganizadora,
                            lugar = eventoBD.Lugar
                        });
                    }
                } else
                {
                    foreach (var eventoBD in listaEventosBD)
                    {
                        listaEventos.Add(new Modelo.Evento()
                        {
                            Id = eventoBD.Id,
                            nombre = eventoBD.nombre,
                            institucionOrganizadora = eventoBD.institucionOrganizadora,
                            lugar = eventoBD.lugar
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

        public Modelo.Evento RecuperarEvento(int eventoId)
        {
            Modelo.Evento eventoRecuperado = new Modelo.Evento();
            try
            {
                var listaEventoBD = _context.EventoSet.ToList();
                foreach (Evento eventoBD in listaEventoBD)
                {
                    if (eventoBD.Id == eventoId)
                    {
                        eventoRecuperado.nombre = eventoBD.nombre;
                        eventoRecuperado.lugar = eventoBD.lugar;
                        eventoRecuperado.institucionOrganizadora =
                            eventoBD.institucionOrganizadora;
                        eventoRecuperado.fechaInicio = eventoBD.fechaInicio;
                        eventoRecuperado.fechaFin = eventoBD.fechaFin;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return eventoRecuperado;
        }

        public bool ModificarEvento(Modelo.Evento eventoModificado)
        {
            try
            {
                var eventoOriginal = _context.EventoSet.SingleOrDefault(
                    evento => evento.Id == eventoModificado.Id);

                if (eventoOriginal != null)
                {
                    eventoOriginal.nombre = eventoModificado.nombre;
                    eventoOriginal.lugar = eventoModificado.lugar;
                    eventoOriginal.institucionOrganizadora =
                        eventoModificado.institucionOrganizadora;
                    eventoOriginal.fechaInicio = eventoModificado.fechaInicio;
                    eventoOriginal.fechaFin = eventoModificado.fechaFin;
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return false;
        }
    }
}
