using Danchi.Models;

namespace Danchi.Repositories.Interfaces
{
    public interface IAdministradorRepository
    {
        Task<List<Administrador>> GetAdministrador();

        Task<Administrador> GetAdministradorById(int id);

        Task<Administrador> GetAdministradorByName(string name);

        Task<bool> PostAdministrador(Administrador administrador);

        Task<bool> PutAdministrador(Administrador Administrador);

        Task<bool> DeleteAdministrador(int id);
    }
}