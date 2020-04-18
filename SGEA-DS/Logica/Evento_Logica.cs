using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Common;
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

                if(eventoOriginal != null)
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
