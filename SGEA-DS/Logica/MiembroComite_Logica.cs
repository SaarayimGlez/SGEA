using DataAccess;
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

        public List<Modelo.MiembroComite> RecuperarMCNoLider()
        {
            List<Modelo.MiembroComite> listaMCNoLider = new List<Modelo.MiembroComite>();
            try
            {
                var listaMCNoLiderBD = _context.MiembroComiteSet
                    .Where(
                        miembro => miembro.liderComite == false
                    ).ToList();

                foreach (MiembroComite mCNoLiderBD in listaMCNoLiderBD)
                {
                    listaMCNoLider.Add(new Modelo.MiembroComite()
                    {
                        apellidoMaterno = mCNoLiderBD.apellidoMaterno,
                        apellidoPaterno = mCNoLiderBD.apellidoPaterno,
                        correoElectronico = mCNoLiderBD.correoElectronico,
                        nivelExperiencia = mCNoLiderBD.nivelExperiencia,
                        nombre = mCNoLiderBD.nombre
                    });
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

        public bool ActualizarMCLider(Modelo.MiembroComite miembroCLider, int idUsuario)
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
                miembroLider.idUsuario = idUsuario;
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
    }
}
