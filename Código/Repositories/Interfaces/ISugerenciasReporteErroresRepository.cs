using Danchi.Models;
namespace Danchi.Repositories.Interfaces
{
    public interface ISugerenciasReporteErroresRepository
    {
        Task<List<SugerenciasReporteErrores>> GetSugerenciasReporteErrores();

        Task<SugerenciasReporteErrores> GetSugerenciasReporteErroresById(int id);

        Task<SugerenciasReporteErrores> GetSugerenciasReporteErroresByName(string TipoDeReporte);

        Task<bool> PostSugerenciasReporteErrores(SugerenciasReporteErrores sugerenciasReporteErrores);

        Task<bool> PutSugerenciasReporteErrores(SugerenciasReporteErrores sugerenciasReporteErrores);

        Task<bool> DeleteSugerenciasReporteErrores(int id);
    }
}