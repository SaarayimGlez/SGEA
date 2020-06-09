using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class Egreso_Logica : ConexionBD_Logica
    {

        public Egreso_Logica() : base()
        {
        }

        public bool RegistrarEgreso(Modelo.Egreso egreso)
        {
            bool respuesta = false;
            try
            {
                _context.EgresoSet.Add(new Egreso()
                {
                    concepto = egreso.concepto,
                    monto = egreso.monto,
                    fecha = egreso.fecha,
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

        public List<Modelo.Egreso> RecuperarEgreso()
        {
            List<Modelo.Egreso> listaEgreso = new List<Modelo.Egreso>();
            try
            {
                var listaEgresoBD = _context.EgresoSet.ToList();
                foreach (Egreso egresoBD in listaEgresoBD)
                {
                    listaEgreso.Add(new Modelo.Egreso()
                    {
                        Id = egresoBD.Id,
                        concepto = egresoBD.concepto,
                        fecha = egresoBD.fecha,
                        monto = egresoBD.monto
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listaEgreso;
        }

    }
}