using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class Participante_Logica : ConexionBD_Logica
    {

        public Participante_Logica() : base()
        {
        }

        public List<List<string>> RecuperarParticipanteEvento(int eventoId)
        {
            List<List<string>> listaParticipante = new List<List<string>>();
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
                            ParticipanteAct = actividad.Participante
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
                            Actividad = actividad
                        }
                     ).Where(
                        evento => evento.Actividad.EventoId == eventoId
                     );

                actividadesEvento = actividadesEvento.OrderBy(calendario => calendario.Fecha);
                actividadesEvento = actividadesEvento.OrderBy(calendario => calendario.HoraInicio);

                foreach (var lista in actividadesEvento)
                {
                    if (lista.Actividad.ParticipanteAct != null)
                    {
                        string participanteAct = "";
                        foreach (Participante participante in lista.Actividad.ParticipanteAct)
                        {
                            participanteAct = participante.nombre + " "
                                    + participante.apellidoPaterno + " "
                                    + participante.apellidoMaterno;

                            listaParticipante.Add(new List<string>(new string[] {
                                participanteAct
                            }));
                            listaParticipante[listaParticipante.Count - 1].Add(
                                lista.Fecha.ToString("MM/dd/yyyy"));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listaParticipante;
        }
    }
}
