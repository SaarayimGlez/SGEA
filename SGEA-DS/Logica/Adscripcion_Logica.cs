using DataAccess;
using System;
using System.Linq;

namespace Logica
{
    public class Adscripcion_Logica : ConexionBD_Logica
    {

        public Adscripcion_Logica() : base()
        {
        }

        public Modelo.Adscripcion RecuperarAdscripcion(int adscripcionId)
        {
            Modelo.Adscripcion adscripcionRecuperada = new Modelo.Adscripcion();
            try
            {
                var adscripcionOriginal = _context.AdscripcionSet.SingleOrDefault(
                    adscripcion => adscripcion.Id == adscripcionId);
                if (adscripcionOriginal != null)
                {
                    adscripcionRecuperada.Id = adscripcionOriginal.Id;
                    adscripcionRecuperada.nombre = adscripcionOriginal.nombre;
                    adscripcionRecuperada.ciudad = adscripcionOriginal.ciudad;
                    adscripcionRecuperada.correoElectronico = adscripcionOriginal.correoElectronico;
                    adscripcionRecuperada.direccion = adscripcionOriginal.direccion;
                    adscripcionRecuperada.estado = adscripcionOriginal.estado;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return adscripcionRecuperada;
        }

        public bool ModificarAdscripcion(Modelo.Adscripcion adscripcionModificada)
        {
            try
            {
                var adscripcionOriginal = _context.AdscripcionSet.SingleOrDefault(
                    adscripcion => adscripcion.Id == adscripcionModificada.Id);
                if (adscripcionOriginal != null)
                {
                    adscripcionOriginal.Id = adscripcionModificada.Id;
                    adscripcionOriginal.nombre = adscripcionModificada.nombre;
                    adscripcionOriginal.ciudad = adscripcionModificada.ciudad;
                    adscripcionOriginal.correoElectronico = adscripcionModificada.correoElectronico;
                    adscripcionOriginal.direccion = adscripcionModificada.direccion;
                    adscripcionOriginal.estado = adscripcionModificada.estado;
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

        public bool RegistrarAdscripcion(Modelo.Adscripcion adscripcion)
        {
            bool respuesta = false;
            try
            {
                _context.AdscripcionSet.Add(new Adscripcion()
                {
                    nombre = adscripcion.nombre,
                    ciudad = adscripcion.ciudad,
                    correoElectronico = adscripcion.correoElectronico,
                    direccion = adscripcion.direccion,
                    estado = adscripcion.estado
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
    }
}
