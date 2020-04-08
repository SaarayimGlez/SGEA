using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Comite_Logica : ConexionBD_Logica
    {

        public Comite_Logica() : base()
        {
        }

        public List<string> RecuperarComitesSinLider(int eventoId)
        {
            List<string> listaComite = new List<string>();
            try
            {
                var comiteSinLider = _context.ComiteSet
                    .Join(
                        _context.EventoSet,
                        comite => comite.EventoId,
                        evento => evento.Id,
                        (comite, evento) => new
                        {
                            EventoId = evento.Id,
                            ComiteId = comite.Id,
                            NombreComite = comite.nombre
                        }
                     )
                     .GroupJoin(
                        _context.MiembroComiteSet,
                        comite => comite.ComiteId,
                        miembro => miembro.ComiteId,
                        (comite, miembroC) => new
                        {
                            Comite = comite,
                            MiembroComite = miembroC
                        }
                     )
                     .SelectMany(
                        tempComite => tempComite.MiembroComite.DefaultIfEmpty(),
                        (tempComite, tempMiembroC) => new
                        {
                            Comite = tempComite.Comite,
                            MiembroComite = tempMiembroC
                        }
                     ).Where(
                        evento => evento.Comite.EventoId == eventoId 
                        && (
                            evento.MiembroComite.liderComite == false 
                            || evento.MiembroComite.liderComite == null
                        )
                     );

                foreach (var lista in comiteSinLider)
                {
                    listaComite.Add(lista.Comite.NombreComite + " -- " + lista.Comite.ComiteId);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listaComite;
        }

        public bool RegistrarComite(Comite comite)
        {
            bool respuesta = false;
            try
            {
                var comiteRepetido = _context.ComiteSet
                    .Where(
                        comiteR => comiteR.nombre.Equals(comite.nombre)
                    ).ToList();
                if (comiteRepetido.Count == 0)
                {
                    _context.ComiteSet.Add(comite);
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
