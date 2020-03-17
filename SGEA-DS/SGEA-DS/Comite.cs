namespace SGEA_DS
{
    class Comite
    {
        private string nombre;
        private string descripcion;

        public Comite(string nombre)
        {
            this.Nombre = nombre;
        }

        public Comite(string nombre, string descripcion)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
