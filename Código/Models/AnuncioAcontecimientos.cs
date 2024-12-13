namespace Danchi.Models
{
    public class AnuncioAcontecimientos
    {
        public int IdAcontecimiento { get; set; }
        public string TipoAcontecimiento { get; set; }
        public string Descripcion { get; set; }
        public string EstadoAcontecimiento { get; set; }
        public string LugarAcontecimiento { get; set; }
        public DateTime FechaYHora { get; set; }
    }
}
