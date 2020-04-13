using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ConexionBD_Logica
    {
        public DataModelContainer _context;

        public ConexionBD_Logica()
        {
            _context = new DataModelContainer();
        }

        public bool ComprobarConexion()
        {
            DbConnection conn = _context.Database.Connection;
            try
            {
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
