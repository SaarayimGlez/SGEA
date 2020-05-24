using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool ModificarMagistral(Modelo.Magistral magistralModificado,
            Modelo.Adscripcion adscripcionModificada)
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
                    if (adscripcion_Logica.ModificarAdscripcion(adscripcionModificada))
                    {
                        _context.SaveChanges();
                        return true;
                    }
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
