﻿using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class RegistroArticuloDAO
    {
        private DataModelContainer _context;

        public RegistroArticuloDAO()
        {
            _context = new DataModelContainer();
        }

        public string RecuperarAutor(Articulo articulo)
        {
            string autor = "";
            try
            {
                var autorRecuperado = _context.RegistroArticuloSet
                    .Join(
                        _context.ArticuloSet,
                        registroArticulo => registroArticulo.Articulo.Id,
                        articuloArticulo => articulo.Id,
                        (registroArticulo, articuloArticulo) => new
                        {
                            Autorid = registroArticulo.AutorId
                        }
                     )
                     .Join(
                        _context.AutorSet,
                        registroArticulo => registroArticulo.Autorid,
                        autorArticulo => autorArticulo.Id,
                        (registroArticulo, autorArticulo) => new
                        {
                            NombreAutor = autorArticulo.nombre,
                            ApellidoPAutor = autorArticulo.apellidoPaterno,
                            ApellidoMAutor = autorArticulo.apellidoMaterno
                        }
                     );

                foreach (var parteNombre in autorRecuperado)
                {
                    autor = parteNombre.NombreAutor + " " + parteNombre.ApellidoPAutor + " " + parteNombre.ApellidoMAutor;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return autor;
        }
    }
}