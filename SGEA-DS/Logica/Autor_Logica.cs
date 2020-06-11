using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;

namespace Logica
{
    public class Autor_Logica : ConexionBD_Logica
    {

        public Autor_Logica() : base()
        {
        }

        public List<List<string>> RecuperarAutorEvento(int eventoId)
        {
            List<List<string>> listaAutor = new List<List<string>>();
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
                       _context.AutorArticuloSet,
                       actividadActiculo => actividadActiculo.Actividad.ArticuloAct.FirstOrDefault().Id,
                       autorArticulo => autorArticulo.Articulo.Id,
                       (actividadActiculo, autorArticulo) => new
                       {
                           EventoId = actividadActiculo.Actividad.EventoId,
                           Fecha = actividadActiculo.Fecha,
                           Autor = autorArticulo.Autor
                       }
                    ).Where(
                        evento => evento.EventoId == eventoId
                     );

                foreach (var actividad in actividadesEvento)
                {
                    string autor = actividad.Autor.nombre + " " +
                        actividad.Autor.apellidoPaterno + " " +
                        actividad.Autor.apellidoMaterno;

                    listaAutor.Add(new List<string>(new string[] {
                                autor
                            }));
                    listaAutor[listaAutor.Count - 1].Add(
                        actividad.Fecha.ToString("MM/dd/yyyy"));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listaAutor;
        }

        public List<List<string>> RecuperarAutor()
        {
            List<List<string>> listaAutor = new List<List<string>>();
            try
            {
                var listaAutorBD = _context.AutorSet
                     .GroupJoin(
                        _context.AutorArticuloSet,
                        autor => autor.Id,
                        autorArticulo => autorArticulo.AutorId,
                        (autor, autorArticulo) => new
                        {
                            Autor = autor,
                            AutorArticulo = autorArticulo
                        }
                     )
                     .SelectMany(
                        tempAutorArticulo => tempAutorArticulo.
                        AutorArticulo.DefaultIfEmpty(),
                        (tempAutor, tempAutorArticulo) => new
                        {
                            Autor = tempAutor.Autor,
                            AutorArticulo = tempAutorArticulo
                        }
                     );

                listaAutorBD = listaAutorBD.OrderBy(autor => autor.Autor.nombre);

                foreach (var autorBD in listaAutorBD)
                {
                    if (listaAutor.Count > 0 &&
                            listaAutor.Last()[0] == autorBD.Autor.nombre)
                    {
                        listaAutor.Last()[4] += ", "
                                    + autorBD.AutorArticulo.Articulo.titulo;
                    }
                    else
                    {
                        listaAutor.Add(new List<string>(new string[] {
                            autorBD.Autor.nombre,
                            autorBD.Autor.apellidoPaterno,
                            autorBD.Autor.apellidoMaterno,
                            autorBD.Autor.correoElectronico
                        }));
                        if (autorBD.AutorArticulo != null)
                        {
                            listaAutor[listaAutor.Count - 1].Add(autorBD.AutorArticulo.Articulo.titulo);
                        }
                        else
                        {
                            listaAutor[listaAutor.Count - 1].Add("(Ningún artículo)");
                        }
                        listaAutor[listaAutor.Count - 1].Add(autorBD.Autor.Id.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listaAutor;
        }

        internal bool RegistrarAutorArticulo(List<int> autorId, Articulo nuevoArticulo)
        {
            bool respuesta = false;
            try
            {
                foreach (int id in autorId)
                {
                    _context.AutorArticuloSet.Add(new AutorArticulo()
                    {
                        AutorId = id,
                        ArticuloId = nuevoArticulo.Id
                    });
                    _context.SaveChanges();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return respuesta;
        }
    }
}