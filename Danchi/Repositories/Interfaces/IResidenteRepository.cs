using Danchi.Models;
namespace Danchi.Repositories.Interfaces
{
    public interface IResidenteRepository
    {
        Task<List<Residente>> GetResidente();

        Task<Residente> GetResidenteById(int id);

        Task<Residente> GetResidenteByName(string NumApartamento);

        Task<bool> PostResidente(Residente Residente);

        Task<bool> PutResidente(Residente Residente);

        Task<bool> DeleteResidente(Residente Residente);
    }
}