using Danchi.Models;

namespace Danchi.Repositories.Interfaces
{
    public interface IAutenticacionUsuarioRepository
    {
        Task<List<AutenticacionUsuario>> GetAutenticacionUsuario();

        Task<AutenticacionUsuario> GetAutenticacionUsuarioByName(string Usuario);

        Task<bool> PostAutenticacionUsuario(AutenticacionUsuario autenticacionUsuario);

        Task<bool> PutAutenticacionUsuario(AutenticacionUsuario autenticacionUsuario);

        Task<bool> DeleteAutenticacionUsuario(int id);
    }
}