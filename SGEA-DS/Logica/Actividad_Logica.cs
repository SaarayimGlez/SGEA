using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

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
                    if (lista.Actividad.ArticuloAct.FirstOrDefault() != null)
                    {
                        var autor = lista.Actividad.ArticuloAct.FirstOrDefault().
                            AutorArticulo.FirstOrDefault().Autor;
                        listaActividad[listaActividad.Count - 1].Add(autor.nombre +" "
                            + autor.apellidoPaterno + " " + autor.apellidoMaterno);
                    }
                    else if (lista.Actividad.MagistralAct != null)
                    {
                        listaActividad[listaActividad.Count - 1].Add(
                            lista.Actividad.MagistralAct.FirstOrDefault().nombre + " " 
                            + lista.Actividad.MagistralAct.FirstOrDefault().apellidoPaterno + " " 
                            + lista.Actividad.MagistralAct.FirstOrDefault().apellidoMaterno);
                    }
                    else if (lista.Actividad.ParticipanteAct != null)
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
                    else
                    {
                        listaActividad[listaActividad.Count - 1].Add("");
                    }
                    listaActividad[listaActividad.Count - 1].Add(lista.Actividad.ActividadId.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listaActividad;
        }

        public bool RegistrarActividadAsistente(int actvidadId, Asistente nuevoAsistente)
        {
            bool respuesta = false;
            try
            {
                var actividadARelacionar = _context.ActividadSet.SingleOrDefault(
                    actividad => actividad.Id == actvidadId);

                if (actividadARelacionar != null)
                {
                    var asistente = new Asistente() { Id = nuevoAsistente.Id };
                    _context.AsistenteSet.Attach(asistente);
                    actividadARelacionar.Asistente.Add(asistente);
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
