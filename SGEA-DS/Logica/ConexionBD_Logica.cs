using DataAccess;
using System.Data.Common;

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
