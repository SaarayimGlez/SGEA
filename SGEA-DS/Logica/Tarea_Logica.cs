using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Logica {
    public class Tarea_Logica : ConexionBD_Logica {

        public Tarea_Logica() : base (){
        }

        public void RegistrarTarea(Modelo.Tarea tarea)
        {
            try
            {
                _context.TareaSet.Add(new Tarea()
                {
                    nombre = tarea.nombre,
                    descripcion = tarea.descripcion,
                    ActividadId = tarea.actividadId
                });
                _context.SaveChanges();
            }catch(Exception e)
            {
                Console.Write(e);
            }
        }

    }
}
