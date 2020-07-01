using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class MiembroComite_Logica : ConexionBD_Logica
    {

        public MiembroComite_Logica() : base()
        {
        }

        public List<List<string>> RecuperarMCNoLider(int eventoId)
        {
            List<List<string>> listaMCNoLider = new List<List<string>>();
            try
            {
                var listaMCNoLiderBD = _context.MiembroComiteSet
                    .Where(
                        miembro => miembro.liderComite == false || 
                        miembro.Comite.EventoId != eventoId
                    ).ToList();

                foreach (MiembroComite mCNoLiderBD in listaMCNoLiderBD)
                {
                    listaMCNoLider.Add(new List<string> (new string[]
                    {
                        mCNoLiderBD.apellidoMaterno,
                        mCNoLiderBD.apellidoPaterno,
                        mCNoLiderBD.correoElectronico,
                        mCNoLiderBD.nivelExperiencia,
                        mCNoLiderBD.nombre,
                        mCNoLiderBD.Usuario.nombreUsuario,
                        mCNoLiderBD.Usuario.contrasenia
                    }));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listaMCNoLider;
        }

        public bool RegistrarMCLider(Modelo.MiembroComite miembroComite, int idUsuario)
        {
            bool respuesta = false;
            try
            {
                _context.MiembroComiteSet.Add(new MiembroComite() {
                    apellidoMaterno = miembroComite.apellidoMaterno,
                    apellidoPaterno = miembroComite.apellidoPaterno,
                    correoElectronico = miembroComite.correoElectronico,
                    nivelExperiencia = miembroComite.nivelExperiencia,
                    nombre = miembroComite.nombre,
                    ComiteId = miembroComite.ComiteId,
                    evaluador = miembroComite.evaluador,
                    liderComite = miembroComite.liderComite,
                    idUsuario = idUsuario
                });
                _context.SaveChanges();
                respuesta = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return respuesta;
        }

        public bool ActualizarMCLider(Modelo.MiembroComite miembroCLider)
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
                miembroLider.ComiteId = miembroCLider.ComiteId;
                miembroLider.evaluador = miembroCLider.evaluador;
                _context.SaveChanges();
                respuesta = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return respuesta;
        }

        public Modelo.MiembroComite RecuperarMiembroComite(int idUsuario)
        {
            Modelo.MiembroComite listaMiembroComite = null;
            try
            {
                var listaMiembroComiteBD = _context.MiembroComiteSet
                    .Where(
                        miembro => miembro.idUsuario == idUsuario
                    ).ToList();

                foreach (MiembroComite miembroComiteBD in listaMiembroComiteBD)
                {
                    listaMiembroComite = new Modelo.MiembroComite()
                    {
                        Id = miembroComiteBD.Id,
                        idUsuario = miembroComiteBD.idUsuario,
                        ComiteId = miembroComiteBD.ComiteId,
                        evaluador = miembroComiteBD.evaluador,
                        liderComite = miembroComiteBD.liderComite
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listaMiembroComite;
        }

        public List<Modelo.MiembroComite> RecuperarMiembroComitePorEvento(int idEvento)
        {
            List<Modelo.MiembroComite> listaMiembroC = new List<Modelo.MiembroComite>();
            try
            {
                var listaMiembroComiteBD = _context.MiembroComiteSet
                    .Where(
                        miembro => miembro.Comite.EventoId == idEvento
                    ).ToList();

                foreach (MiembroComite miembroComiteBD in listaMiembroComiteBD)
                {
                    listaMiembroC.Add(new Modelo.MiembroComite()
                    {
                        Id = miembroComiteBD.Id,
                        nombre = miembroComiteBD.nombre,
                        apellidoMaterno = miembroComiteBD.apellidoMaterno,
                        apellidoPaterno = miembroComiteBD.apellidoPaterno,
                        correoElectronico = miembroComiteBD.correoElectronico,
                        nivelExperiencia = miembroComiteBD.nivelExperiencia
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listaMiembroC;
        }

        public bool ModificarMiembroComite(Modelo.MiembroComite miembroComiteModificado)
        {
            try
            {
                var miembroComiteOriginal = _context.MiembroComiteSet.SingleOrDefault(
                    miembroComite => miembroComite.Id == miembroComiteModificado.Id);

                if (miembroComiteOriginal != null)
                {
                    miembroComiteOriginal.nombre = miembroComiteModificado.nombre;
                    miembroComiteOriginal.apellidoPaterno = miembroComiteModificado.apellidoPaterno;
                    miembroComiteOriginal.apellidoMaterno = miembroComiteModificado.apellidoMaterno;
                    miembroComiteOriginal.correoElectronico = 
                        miembroComiteModificado.correoElectronico;
                    miembroComiteOriginal.nivelExperiencia = miembroComiteModificado.nivelExperiencia;
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

        //Registra un nuevo miembro de comité en la base de datos
        public void RegistrarMiembroComite(Modelo.MiembroComite miembroComite)
        {
            _context.MiembroComiteSet.Add(new MiembroComite
            {
                nombre = miembroComite.nombre,
                apellidoPaterno = miembroComite.apellidoPaterno,
                apellidoMaterno = miembroComite.apellidoMaterno,
                nivelExperiencia = miembroComite.nivelExperiencia,
                correoElectronico = miembroComite.correoElectronico,
                liderComite = miembroComite.liderComite,
                ComiteId = miembroComite.ComiteId,
                idUsuario = miembroComite.idUsuario,
                evaluador = miembroComite.evaluador,
            });
            _context.SaveChanges();

        }

        public List<Modelo.MiembroComite> RecuperarMiembroComiteEvaluador()
        {
            List<Modelo.MiembroComite> listaMiembroC = new List<Modelo.MiembroComite>();
            try
            {
                var listaMiembroComiteBD = _context.MiembroComiteSet
                    .Where(
                        miembro => miembro.evaluador == true
                    ).ToList();

                foreach (MiembroComite miembroComiteBD in listaMiembroComiteBD)
                {
                    listaMiembroC.Add(new Modelo.MiembroComite()
                    {
                        Id = miembroComiteBD.Id,
                        nombre = miembroComiteBD.nombre,
                        apellidoMaterno = miembroComiteBD.apellidoMaterno,
                        apellidoPaterno = miembroComiteBD.apellidoPaterno,
                        correoElectronico = miembroComiteBD.correoElectronico,
                        nivelExperiencia = miembroComiteBD.nivelExperiencia
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listaMiembroC;
        }

        public List<Modelo.MiembroComite> RecuperarMiembroComitePorComite(int idComite)
        {
            List<Modelo.MiembroComite> listaMiembroC = new List<Modelo.MiembroComite>();
            try
            {
                var listaMiembroComiteBD = _context.MiembroComiteSet
                    .Where(
                        miembro => miembro.ComiteId == idComite
                    ).ToList();

                foreach (MiembroComite miembroComiteBD in listaMiembroComiteBD)
                {
                    listaMiembroC.Add(new Modelo.MiembroComite()
                    {
                        Id = miembroComiteBD.Id,
                        nombre = miembroComiteBD.nombre,
                        apellidoMaterno = miembroComiteBD.apellidoMaterno,
                        apellidoPaterno = miembroComiteBD.apellidoPaterno,
                        correoElectronico = miembroComiteBD.correoElectronico,
                        nivelExperiencia = miembroComiteBD.nivelExperiencia
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listaMiembroC;
        }

    }
}
