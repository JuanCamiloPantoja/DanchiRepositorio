namespace Danchi.Models
{
    public class ChatInterno
    {
        public int IdChat { get; set; }
        public int IdAdministrador { get; set; }
        public int IdResidente { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string EstadoDelMensaje { get; set; }
        public string Asunto { get; set; }
        public string Adjuntos { get; set; }
    }
}
