using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Autor_Logica : ConexionBD_Logica
    {

        public Autor_Logica() : base()
        {
        }

        public List<string> RecuperarAutorEvento(int eventoId)
        {
            List<string> listaAutor = new List<string>();
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
                            ArticuloAct = actividad.Articulo
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
                     ).Join(
                       _context.RegistroArticuloSet,
                       actividadActiculo => actividadActiculo.Actividad.ArticuloAct.Id,
                       registroArticulo => registroArticulo.Articulo.Id,
                       (actividadActiculo, registroArticulo) => new
                       {
                           EventoId = actividadActiculo.Actividad.EventoId,
                           Fecha = actividadActiculo.Fecha,
                           Autor = registroArticulo.Autor
                       }
                    ).Where(
                        evento => evento.EventoId == eventoId
                     );

                foreach (var actividad in actividadesEvento)
                {
                    listaAutor.Add(actividad.Autor.nombre + " " +
                            actividad.Autor.apellidoPaterno + " " +
                            actividad.Autor.apellidoMaterno + " - " +
                            actividad.Fecha);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listaAutor;
        }
    }
}
