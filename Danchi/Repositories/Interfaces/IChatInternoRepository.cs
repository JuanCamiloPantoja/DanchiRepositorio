using Danchi.Models;
namespace Danchi.Repositories.Interfaces
{
    public interface IChatInternoRepository
    {
        Task<List<ChatInterno>> GetChatInterno();

        Task<ChatInterno> GetChatInternoById(int id);

        Task<ChatInterno> GetChatInternoByName(int IdResidente);

        Task<bool> PostChatInterno(ChatInterno chatInterno);

        Task<bool> PutChatInterno(ChatInterno chatInterno);

        Task<bool> DeleteChatInterno(ChatInterno chatInterno);
    }
}
