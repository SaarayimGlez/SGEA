using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Logica {
    public class Ingreso_Logica : ConexionBD_Logica {

        public Ingreso_Logica() : base()
        {

        }

        public void RegistrarIngreso(Modelo.Ingreso ingreso)
        {
            _context.IngresoSet.Add(new Ingreso()
            {
                concepto = ingreso.concepto,
                monto = ingreso.monto,
                fecha = ingreso.fecha
            });
            _context.SaveChanges();
        }
    }
}
