using Danchi.Models;
using Danchi.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Danchi.Context;
using System;

namespace Danchi.Repositories
{
    public class NotificacionEmergenciasRepository : INotificacionEmergenciasRepository
    {
        private readonly Danchi_Context context;

        public NotificacionEmergenciasRepository(Danchi_Context context)
        {
            this.context = context;
        }

        public async Task<List<NotificacionEmergencias>> GetNotificacionEmergencias()
        {
            var data = await context.notificacionEmergencias.ToListAsync();
            return data;
        }

        public async Task<NotificacionEmergencias> GetNotificacionEmergenciasById(int id)
        {
            var data = await context.notificacionEmergencias.Where(x => x.IdEmergencia == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<NotificacionEmergencias> GetNotificacionEmergenciasByName(string Descripcion)
        {
            var data = await context.notificacionEmergencias.Where(x => x.Descripcion == Descripcion).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> PostNotificacionEmergencias(NotificacionEmergencias notificacionEmergencias)
        {
            await context.notificacionEmergencias.AddAsync(notificacionEmergencias);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> PutNotificacionEmergencias(NotificacionEmergencias notificacionEmergencias)
        {
            context.notificacionEmergencias.Update(notificacionEmergencias);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteNotificacionEmergencias(NotificacionEmergencias notificacionEmergencias)
        {
            context.notificacionEmergencias.Remove(notificacionEmergencias);
            await context.SaveAsync();
            return true;
        }
    }
}