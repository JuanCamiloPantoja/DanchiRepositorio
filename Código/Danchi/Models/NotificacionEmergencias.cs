namespace Danchi.Models
{
    public class NotificacionEmergencias
    {
        public int IdEmergencia { get; set; }
        public string Descripcion { get; set; }
        public string AccionesRecomendadas { get; set; }
        public string EstadoEmergencia { get; set; }
        public string TipoEmergencia { get; set; }
        public string Lugar { get; set; }
        public DateTime FechaYHora { get; set; }
    }
}
