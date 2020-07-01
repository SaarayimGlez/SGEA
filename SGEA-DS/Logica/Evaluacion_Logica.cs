using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Evaluacion_Logica : ConexionBD_Logica
    {

        public Evaluacion_Logica() : base()
        {
        }

        public void SendEmail(String email, String messageSubject, String message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("LisWhoUv@gmail.com", "LisWho");
                mail.To.Add(email);
                mail.Subject = messageSubject;
                mail.Body = message;
                SmtpServer.Port = 587;
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("LisWhoUv@gmail.com", "Fei17Guess19*");
                SmtpServer.Send(mail);
                SmtpServer.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public List<Modelo.Evaluacion> RecuperarEvaluaciones()
        {
            List<Modelo.Evaluacion> listaEvaluaciones = new List<Modelo.Evaluacion>();
            try
            {
                var listaBD = _context.EvaluacionSet.ToList();
                foreach (Evaluacion evaluacion in listaBD)
                {
                    listaEvaluaciones.Add(new Modelo.Evaluacion()
                    {
                        Id = evaluacion.Id,
                        descripcion = evaluacion.descripcion,
                        calificacion = evaluacion.calificacion,
                        fecha = evaluacion.fecha
                    });
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return listaEvaluaciones;
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

        public void RegistrarIdEvauacion(int idEvaluador, int idArticulo)
        {
            DateTime thisDay = DateTime.Today;
            try
            {
                _context.EvaluacionSet.Add(new Evaluacion()
                {
                    calificacion = 0,
                    fecha = thisDay,
                    descripcion = " ",
                    MiembroComite_Id = idEvaluador,
                    ArticuloId = idArticulo
                });
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }

        public void ModificarEvalucion(int id, String descripcion, int calificacion, System.DateTime fecha)
        {
            using (DataModelContainer database = new DataModelContainer())
            {
                var evaluacionM = database.EvaluacionSet.Where(evaluacion => evaluacion.Id == id).FirstOrDefault();
                evaluacionM.descripcion = descripcion;
                evaluacionM.calificacion = calificacion;
                evaluacionM.fecha = fecha;
                database.SaveChanges();
            }
        }

    }
}
