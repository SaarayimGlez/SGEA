﻿using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class MiembroComite_Logica : ConexionBD_Logica
    {

        public MiembroComite_Logica() : base()
        {
        }

        public List<MiembroComite> RecuperarMCNoLider()
        {
            List<MiembroComite> listaMCNoLider = new List<MiembroComite>();
            try
            {
                listaMCNoLider = _context.MiembroComiteSet
                    .Where(
                        miembro => miembro.liderComite == false
                    ).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listaMCNoLider;
        }

        public bool RegistrarMCLider(MiembroComite miembroComite)
        {
            bool respuesta = false;
            try
            {
                _context.MiembroComiteSet.Add(miembroComite);
                _context.SaveChanges();
                respuesta = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return respuesta;
        }

        public bool ActualizarMCLider(MiembroComite miembroCLider)
        {
            bool respuesta = false;
            try
            {
                var miembroLider = _context.MiembroComiteSet
                    .Where(
                        miembroNLider => miembroNLider.nombre == miembroCLider.nombre
                        && miembroNLider.apellidoPaterno == miembroCLider.apellidoPaterno
                        && miembroNLider.apellidoMaterno == miembroCLider.apellidoMaterno
                    ).First<MiembroComite>();
                miembroLider.liderComite = true;
                miembroLider.nombreUsuario = miembroCLider.nombreUsuario;
                miembroLider.contrasenia = miembroCLider.contrasenia;
                miembroLider.ComiteId = miembroCLider.ComiteId;
                _context.SaveChanges();
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