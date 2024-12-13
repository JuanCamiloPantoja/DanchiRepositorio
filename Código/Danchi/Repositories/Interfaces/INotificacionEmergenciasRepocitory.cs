using Danchi.Models;
namespace Danchi.Repositories.Interfaces
{
    public interface INotificacionEmergenciasRepository
    {
        Task<List<NotificacionEmergencias>> GetNotificacionEmergencias();

        Task<NotificacionEmergencias> GetNotificacionEmergenciasById(int id);

        Task<NotificacionEmergencias> GetNotificacionEmergenciasByName(string Descripcion);

        Task<bool> PostNotificacionEmergencias(NotificacionEmergencias notificacionEmergencias);

        Task<bool> PutNotificacionEmergencias(NotificacionEmergencias notificacionEmergencias);

        Task<bool> DeleteNotificacionEmergencias(int id);
    }
}