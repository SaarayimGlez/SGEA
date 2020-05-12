using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Actividad_Logica : ConexionBD_Logica
    {
        public Actividad_Logica() : base()
        {
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
                     ).Where(
                        evento => evento.Actividad.EventoId == eventoId
                     );
                
                actividadesEvento = actividadesEvento.OrderBy(calendario => calendario.Fecha);
                actividadesEvento = actividadesEvento.OrderBy(calendario => calendario.HoraInicio);

                foreach (var lista in actividadesEvento)
                {
                    listaActividad.Add(new List<string>(new string[] {
                        lista.Actividad.Nombre,
                        lista.Actividad.Costo.ToString(),
                        lista.Fecha.ToString("MM/dd/yyyy"),
                        lista.HoraInicio.ToString(@"hh\:mm"),
                        lista.HoraFin.ToString(@"hh\:mm"),
                        lista.Actividad.Aula,
                        lista.Actividad.Tipo
                    }));
                    if (lista.Actividad.ArticuloAct != null)
                    {
                        RegistroArticulo_Logica registroArticuloDAO = new RegistroArticulo_Logica();
                        listaActividad[listaActividad.Count - 1].Add(registroArticuloDAO.RecuperarAutor(lista.Actividad.ArticuloAct));
                    }
                    if (lista.Actividad.MagistralAct != null)
                    {
                        listaActividad[listaActividad.Count - 1].Add(
                            lista.Actividad.MagistralAct.nombre + " " 
                            + lista.Actividad.MagistralAct.apellidoPaterno + " " 
                            + lista.Actividad.MagistralAct.apellidoMaterno);
                    }
                    if (lista.Actividad.ParticipanteAct != null)
                    {
                        string participanteAct = "";
                        foreach (Participante participante in lista.Actividad.ParticipanteAct)
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
