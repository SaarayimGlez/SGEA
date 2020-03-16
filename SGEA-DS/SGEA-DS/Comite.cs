namespace SGEA_DS
{
    class Comite
    {
        private string nombre;

        public Comite(string nombre)
        {
            this.Nombre = nombre;
        }

        public string Nombre
        {
            get => nombre; set => nombre = value;
        }
    }
}
