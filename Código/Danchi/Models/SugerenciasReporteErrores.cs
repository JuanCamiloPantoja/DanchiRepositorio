namespace Danchi.Models
{
    public class SugerenciasReporteErrores
    {
        public int IdSugerenciaError { get; set; }
        public int IdResidente { get; set; }
        public string TipoDeReporte { get; set; }
        public string Descripcion { get; set; }
        public string Lugar { get; set; }
        public DateTime FechaYHora { get; set; }
    }
}
