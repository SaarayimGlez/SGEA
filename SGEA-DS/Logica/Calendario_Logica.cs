using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Logica {
    public class Calendario_Logica : ConexionBD_Logica {
        public Calendario_Logica(): base()
        {
            
        }

        public void RegistrarCalendario(Modelo.Calendario calendario)
        {
            try
            {
                _context.CalendarioSet.Add(new Calendario()
                {
                    horaFin = calendario.horaFin,
                    horaInicio = calendario.horaInicio,
                    fecha = calendario.fecha,
                    ActividadId = calendario.actividadId
                });
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }

    }
}
