using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Articulo_Logica : ConexionBD_Logica
    {
        public Articulo_Logica() : base()
        {
        }

        public List<List<object>> RecuperarArticuloEvaluador(int evaluadorId)
        {
            List<List<object>> listaArticulo = new List<List<object>> ();
            try
            {
                var articulosEvaluacion = _context.ArticuloSet
                    .Join(
                        _context.EvaluacionSet,
                        articulo => articulo.Id,
                        evaluacion => evaluacion.ArticuloId,
                        (articulo, evaluacion) => new
                        {
                            Id = articulo.Id,
                            Titulo = articulo.titulo,
                            Keyword = articulo.keyword,
                            Abstract = articulo.@abstract,
                            Documento = articulo.documento,
                            Status = articulo.status,
                            MiembroComiteId = evaluacion.MiembroComite_Id
                        }
                     ).Where(
                        evaluacion => evaluacion.MiembroComiteId == evaluadorId
                     );

                foreach (var articulo in articulosEvaluacion)
                {
                    listaArticulo.Add(new List<object>(new object[] {
                        articulo.Id,
                        articulo.Titulo,
                        articulo.Keyword,
                        articulo.Abstract,
                        articulo.Documento,
                        articulo.Status,
                        articulo.MiembroComiteId
                    }));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listaArticulo;
        }

        public bool RegistrarArticulo(Modelo.Articulo articulo, List<int> autorId)
        {
            bool respuesta = false;
            try
            {
                _context.ArticuloSet.Add(new Articulo()
                {
                    titulo = articulo.titulo,
                    @abstract = articulo.@abstract,
                    keyword = articulo.keyword,
                    documento = articulo.documento,
                    status = articulo.status
                });
                _context.SaveChanges();

                var nuevoArticulo = _context.ArticuloSet.ToList().Last<Articulo>();

                Autor_Logica autor_Logica = new Autor_Logica();
                respuesta = autor_Logica.RegistrarAutorArticulo(autorId, nuevoArticulo);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return respuesta;
        }
    }
}
