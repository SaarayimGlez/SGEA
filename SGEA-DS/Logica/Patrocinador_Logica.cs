using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Patrocinador_Logica
    {
        private DataModelContainer _context;

        public Patrocinador_Logica()
        {
            _context = new DataModelContainer();
        }

        public bool ComprobarConexion()
        {
            DbConnection conn = _context.Database.Connection;
            try
            {
                conn.Open();   // check the database connection
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RegistrarPatrocinador(Patrocinador patrocinador)
        {
            bool respuesta = false;
            try
            {
                var patrocinadorRepetido = _context.PatrocinadorSet
                    .Where(
                        patrocinadorR => patrocinadorR.empresa.Equals(patrocinador.empresa)
                    ).ToList();
                if (patrocinadorRepetido.Count == 0)
                {
                    _context.PatrocinadorSet.Add(patrocinador);
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

        public List<Patrocinador> RecuperarPatrocinador()
        {
            List<Patrocinador> listaPatrocinador = new List<Patrocinador>();
            try
            {
                listaPatrocinador = _context.PatrocinadorSet.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listaPatrocinador;
        }
    }
}
