using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public bool RegistrarComite(Modelo.Comite comite)
        {
            bool respuesta = false;
            try
            {
                var comiteRepetido = _context.ComiteSet
                    .Where(
                        comiteR => comiteR.nombre.Equals(comite.nombre) &&
                        comiteR.EventoId == comite.EventoId
                    ).ToList();
                if (comiteRepetido.Count == 0)
                {
                    _context.ComiteSet.Add(new Comite() {
                        nombre = comite.nombre,
                        descripcion = comite.descripcion,
                        EventoId = comite.EventoId
                    });
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

        public List<Modelo.Comite> GenerarListaComite()
        {
            List<Modelo.Comite> listaComite = new List<Modelo.Comite>();
            try
            {
                var listaC = _context.ComiteSet.ToList();
                foreach (Comite comite in listaC)
                {
                    listaComite.Add(new Modelo.Comite()
                    {
                        Id = comite.Id,
                        nombre = comite.nombre
                    });
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return listaComite;
        }

        public Modelo.Comite RecuperarComite(int idComite)
        {
            Modelo.Comite comiteRecuperado = new Modelo.Comite();
            try
            {
                var comiteOriginal = _context.ComiteSet.SingleOrDefault(comite => comite.Id == idComite);
                if (comiteOriginal != null)
                {
                    comiteRecuperado.Id = comiteOriginal.Id;
                    comiteRecuperado.nombre = comiteOriginal.nombre;
                    comiteRecuperado.descripcion = comiteOriginal.descripcion;
                    comiteRecuperado.EventoId = comiteOriginal.EventoId;
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return comiteRecuperado;
        }

    }
}
