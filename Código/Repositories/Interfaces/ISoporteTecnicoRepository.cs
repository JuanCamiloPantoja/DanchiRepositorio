using Danchi.Models;
namespace Danchi.Repositories.Interfaces
{
    public interface ISoporteTecnicoRepository
    {
        Task<List<SoporteTecnico>> GetSoporteTecnico();

        Task<SoporteTecnico> GetSoporteTecnicoById(int id);

        Task<SoporteTecnico> GetSoporteTecnicoByName(string ActividadAfectada);

        Task<bool> PostSoporteTecnico(SoporteTecnico soporteTecnico);

        Task<bool> PutSoporteTecnico(SoporteTecnico soporteTecnico);

        Task<bool> DeleteSoporteTecnico(int id);
    }
}