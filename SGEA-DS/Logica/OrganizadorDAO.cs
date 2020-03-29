using DataAccess;
using Modelo;

namespace Logica
{
    public class OrganizadorDAO
    {
        public bool RegistraroOrganizador(string nombreUsuario, string contrasenia)
        {
            Organizador organizador = new Organizador
            {
                nombreUsuario = nombreUsuario,
                contrasenia = contrasenia
            };

            using(var baseDatos = new DataModelContainer())
            {
                baseDatos.OrganizadorSet.Add(organizador);
            }
            return true;
        }
    }
}
