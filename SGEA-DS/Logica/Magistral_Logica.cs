using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class Magistral_Logica : ConexionBD_Logica
    {

        public Magistral_Logica() : base()
        {
        }


        public List<Modelo.Magistral> RecuperarMagistral()
        {
            List<Modelo.Magistral> listaMagistral = new List<Modelo.Magistral>();
            try
            {
                var listaMagistralBD = _context.MagistralSet.ToList();
                foreach (Magistral magistralBD in listaMagistralBD)
                {
                    listaMagistral.Add(new Modelo.Magistral() {
                        Id = magistralBD.Id,
                        nombre = magistralBD.nombre,
                        apellidoPaterno = magistralBD.apellidoPaterno,
                        apellidoMaterno = magistralBD.apellidoMaterno,
                        AdscripcionId = magistralBD.AdscripcionId
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listaMagistral;
        }

        public bool ModificarMagistral(Modelo.Magistral magistralModificado)
        {
            Adscripcion_Logica adscripcion_Logica = new Adscripcion_Logica();
            try
            {
                var magistralOriginal = _context.MagistralSet.SingleOrDefault(
                    magistral => magistral.Id == magistralModificado.Id);

                if(magistralOriginal != null)
                {
                    magistralOriginal.nombre = magistralModificado.nombre;
                    magistralOriginal.apellidoPaterno = magistralModificado.apellidoPaterno;
                    magistralOriginal.apellidoMaterno = magistralModificado.apellidoMaterno;
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

        public List<List<string>> RecuperarMagistralEvento(int eventoId)
        {
            List<List<string>> listaMagistral= new List<List<string>>();
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
                            MagistralAct = actividad.Magistral
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
                    if (lista.Actividad.MagistralAct != null)
                    {
                        string magistral = "";
                        magistral = lista.Actividad.MagistralAct.nombre + " "
                            + lista.Actividad.MagistralAct.apellidoPaterno + " "
                            + lista.Actividad.MagistralAct.apellidoMaterno;

                        listaMagistral.Add(new List<string>(new string[] {
                            magistral
                        }));
                        listaMagistral[listaMagistral.Count - 1].Add(
                            lista.Fecha.ToString("MM/dd/yyyy"));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listaMagistral;
        }
    }
}
