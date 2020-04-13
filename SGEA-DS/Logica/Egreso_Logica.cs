using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Egreso_Logica : ConexionBD_Logica
    {

        public Egreso_Logica() : base()
        {
        }

        public bool RegistrarEgreso(Egreso egreso)
        {
            bool respuesta = false;
            try
            {
                _context.EgresoSet.Add(egreso);
                _context.SaveChanges();
                respuesta = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return respuesta;
        }

        public List<Egreso> RecuperarEgreso()
        {
            List<Egreso> listaEgreso = new List<Egreso>();
            try
            {
                listaEgreso = _context.EgresoSet.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listaEgreso;
        }

    }
}
