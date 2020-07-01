using DataAccess;
using System;
using System.Linq;

namespace Logica
{
    public class RegistroArticulo_Logica : ConexionBD_Logica
    {
        public RegistroArticulo_Logica() : base()
        {
        }

        public void RegistrarPagoArticulo(Modelo.RegistroArticulo registro)
        {
            try
            {
                _context.RegistroArticuloSet.Add(new RegistroArticulo()
                {
                    comprobantePago = registro.comprobantePago,
                    fecha = registro.fecha,
                    hora = TimeSpan.Parse(registro.hora),
                    cantidadPago = registro.cantidadPago
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
