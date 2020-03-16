namespace SGEA_DS
{
    class MiembroComite
    {
        private string nombre;
        private string apellidoPaterno;
        private string apellidoMaterno;
        private string correoElectronico;
        private int nivelExperiencia;

        public MiembroComite()
        {

        }

        public MiembroComite(string nombre, string apellidoPaterno, string apellidoMaterno, string correoElectronico, int nivelExperiencia)
        {
            this.nombre = nombre;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.correoElectronico = correoElectronico;
            this.nivelExperiencia = nivelExperiencia;
        }

        public string Nombre
        {
            get => nombre; set => nombre = value;
        }

        public string ApellidoPaterno
        {
            get => apellidoPaterno; set => apellidoPaterno = value;
        }
        public string ApellidoMaterno
        {
            get => apellidoMaterno; set => apellidoMaterno = value;
        }
        public string CorreoElectronico
        {
            get => correoElectronico; set => correoElectronico = value;
        }
        public int NivelExperiencia
        {
            get => nivelExperiencia; set => nivelExperiencia = value;
        }
    }
}
