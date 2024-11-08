namespace Danchi.Models
{
    public class SoporteTecnico
    {
        public int IdSoporte { get; set; }
        public int IdResidente { get; set; }
        public int IdAdministrador { get; set; }
        public string ActividadAfectada { get; set; }
        public string Descripcion { get; set; }
        public string Prioridad { get; set; }
    }
}
