using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Material_Logica : ConexionBD_Logica
    {

        public Material_Logica() : base()
        {
        }

        public bool RegistrarMaterial(Material material, int egresoId)
        {
            bool respuesta = false;
            try
            {
                material.EgresoMaterial_Material_Id = egresoId;
                _context.MaterialSet.Add(material);
                _context.SaveChanges();
                respuesta = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return respuesta;
        }
    }
}
