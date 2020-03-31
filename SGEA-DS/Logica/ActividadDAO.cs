using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ActividadDAO
    {
        private DataModelContainer _context;

        public ActividadDAO()
        {
            _context = new DataModelContainer();
        }

        public List<List<string>> RecuperarProgramaEvento(int eventoId)
        {
            List<List<string>> listaActividad = new List<List<string>>();
            try
            {
                var actividadesEvento = _context.ActividadSet
                    .Join(
                        _context.EventoSet,
                        actividad => actividad.EventoId,
                        evento => evento.Id,
                        (actividad, evento) => new
                        {
                            EventoId = evento.Id,
                            ActividadId = actividad.Id,
                            Nombre = actividad.nombre,
                            Costo = actividad.costo,
                            Aula = actividad.aula,
                            Tipo = actividad.tipo,
                            MagistralAct = actividad.Magistral,
                            ParticipanteAct = actividad.Participante,
                            ArticuloAct = actividad.Articulo
                        }
                     )
                     .Join(
                        _context.CalendarioSet,
                        actividad => actividad.ActividadId,
                        calendario => calendario.ActividadId,
                        (actividad, calendario) => new
                        {
                            Fecha = calendario.fecha,
                            HoraInicio = calendario.horaInicio,
                            HoraFin = calendario.horaFin,
                            Actividad = actividad
                        }
                     )
                     .GroupJoin(
                        _context.ArticuloSet,
                        actividad => actividad.Actividad.ActividadId,
                        articulo => articulo.Actividad.Id,
                        (x, y) => new
                        {
                            Actividad = x,
                            Articulo = y
                        }
                     )
                     .SelectMany(
                        x => x.Articulo.DefaultIfEmpty(),
                        (x, y) => new
                        {
                            Actividad = x.Actividad,
                            Articulo = y
                        }
                     ).Where(
                        evento => evento.Actividad.Actividad.EventoId == eventoId
                     );
                
                actividadesEvento = actividadesEvento.OrderBy(x => x.Actividad.Fecha);
                actividadesEvento = actividadesEvento.OrderBy(x => x.Actividad.HoraInicio);

                foreach (var lista in actividadesEvento)
                {
                    listaActividad.Add(new List<string>(new string[] {
                        lista.Actividad.Actividad.Nombre,
                        lista.Actividad.Actividad.Costo.ToString(),
                        lista.Actividad.Fecha.ToString("MM/dd/yyyy"),
                        lista.Actividad.HoraInicio.ToString(@"hh\:mm"),
                        lista.Actividad.HoraInicio.ToString(@"hh\:mm"),
                        lista.Actividad.Actividad.Aula,
                        lista.Actividad.Actividad.Tipo
                    }));
                    if (lista.Articulo != null)
                    {
                        RegistroArticuloDAO registroArticuloDAO = new RegistroArticuloDAO();
                        listaActividad[listaActividad.Count - 1].Add(registroArticuloDAO.RecuperarAutor(lista.Articulo));
                    }
                    if (lista.Actividad.Actividad.MagistralAct != null)
                    {
                        listaActividad[listaActividad.Count - 1].Add(
                            lista.Actividad.Actividad.MagistralAct.nombre + " " 
                            + lista.Actividad.Actividad.MagistralAct.apellidoPaterno + " " 
                            + lista.Actividad.Actividad.MagistralAct.apellidoMaterno);
                    }
                    if (lista.Actividad.Actividad.ParticipanteAct != null)
                    {
                        string participanteAct = "";
                        foreach (Participante participante in lista.Actividad.Actividad.ParticipanteAct)
                        {
                            if (participanteAct.Equals(""))
                            {
                                participanteAct = participante.nombre + " "
                                    + participante.apellidoPaterno + " "
                                    + participante.apellidoMaterno;
                            } else
                            {
                                participanteAct = participanteAct + ", " 
                                    + participante.nombre + " "
                                    + participante.apellidoPaterno + " "
                                    + participante.apellidoMaterno;
                            }
                            
                        }
                        listaActividad[listaActividad.Count - 1].Add(participanteAct);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listaActividad;
        }
    }
}
