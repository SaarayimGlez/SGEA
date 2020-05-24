using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Asistente_Logica : ConexionBD_Logica
    {

        public Asistente_Logica() : base()
        {
        }

        public List<string> RecuperarAsistenteEvento(int eventoId)
        {
            Asistente asistente = new Asistente();
            

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
                            ActividadId = actividad.Id,
                            AsistenteAct = actividad.Magistral,
                        }
                     ).Join(
                        _context.CalendarioSet,
                        actividad => actividad.ActividadId,
                        calendario => calendario.ActividadId,
                        (actividad, calendario) => new
                        {
                            Fecha = calendario.fecha,
                            Actividad = actividad
                        }
                     ).Where(
                        evento => evento.Actividad.EventoId == eventoId
                     );

                foreach (var actividad in actividadesEvento)
                {
                    if (actividad.Actividad.MagistralAct != null)
                    {
                        listaAsistente.Add(actividad.Actividad.MagistralAct.nombre + " " +
                            actividad.Actividad.MagistralAct.apellidoPaterno + " " +
                            actividad.Actividad.MagistralAct.apellidoMaterno + " - " +
                            actividad.Fecha);
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
