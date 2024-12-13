using Danchi.Models;

namespace Danchi.Repositories.Interfaces
{
    public interface IAnuncioAcontecimientosRepository
    {
        Task<List<AnuncioAcontecimientos>> GetAnuncioAcontecimientos();

        Task<AnuncioAcontecimientos> GetAnuncioAcontecimientosById(int id);

        Task<AnuncioAcontecimientos> GetAnuncioAcontecimientosByName(string Acontecimient);

        Task<bool> PostAnuncioAcontecimientos(AnuncioAcontecimientos AnuncioAcontecimientos);

        Task<bool> PutAnuncioAcontecimientos(AnuncioAcontecimientos anuncioAcontecimientos);

        Task<bool> DeleteAnuncioAcontecimientos(int id);
    }
}
