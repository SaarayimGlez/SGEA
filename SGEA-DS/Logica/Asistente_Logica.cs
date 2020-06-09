using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class Asistente_Logica : ConexionBD_Logica
    {

        public Asistente_Logica() : base()
        {
        }

        public List<string> RecuperarAsistenteEvento(int eventoId)
        {
            List<string> listaAsistente = new List<string>();
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
                            AsistenteAct = actividad.Asistente,
                        }
                     ).Where(
                        evento => evento.EventoId == eventoId
                     );

                foreach (var actividad in actividadesEvento)
                {
                    if (actividad.AsistenteAct != null)
                    {
                        foreach (Asistente asistente in actividad.AsistenteAct)
                        {
                            listaAsistente.Add(asistente.nombre + " " +
                            asistente.apellidoPaterno + " " +
                            asistente.apellidoMaterno);
                        }  
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listaAsistente;
        }
    }
}
