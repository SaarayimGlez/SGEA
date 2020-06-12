using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Evaluacion_Logica : ConexionBD_Logica
    {

        public Evaluacion_Logica() : base()
        {
        }

        public bool RegistrarEvaluacion(Modelo.Evaluacion evaluacion)
        {
            bool respuesta = false;
            try
            {
                var evaluacionRelacion = _context.EvaluacionSet.SingleOrDefault(
                    evaluacionBD => evaluacionBD.calificacion == 0 && 
                    evaluacionBD.MiembroComite_Id == evaluacion.MiembroComite_Id &&
                    evaluacionBD.ArticuloId == evaluacion.ArticuloId);

                if (evaluacionRelacion != null)
                {
                    evaluacionRelacion.descripcion = evaluacion.descripcion;
                    evaluacionRelacion.calificacion = evaluacion.calificacion;
                    evaluacionRelacion.fecha = evaluacion.fecha;
                    _context.SaveChanges();
                    respuesta = true;
                } else
                {
                    _context.EvaluacionSet.Add(new Evaluacion()
                    {
                        descripcion = evaluacion.descripcion,
                        calificacion = evaluacion.calificacion,
                        fecha = evaluacion.fecha,
                        ArticuloId = evaluacion.ArticuloId,
                        MiembroComite_Id = evaluacion.MiembroComite_Id
                    });
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
    }
}
