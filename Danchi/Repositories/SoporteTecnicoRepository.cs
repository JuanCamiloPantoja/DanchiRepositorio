using Danchi.Models;
using Danchi.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Danchi.Context;
using System;

namespace Danchi.Repositories
{
    public class SoporteTecnicoRepository : ISoporteTecnicoRepository
    {
        private readonly Danchi_Context context;

        public SoporteTecnicoRepository(Danchi_Context context)
        {
            this.context = context;
        }

        public async Task<List<SoporteTecnico>> GetSoporteTecnico()
        {
            var data = await context.soporteTecnico.ToListAsync();
            return data;
        }

        public async Task<SoporteTecnico> GetSoporteTecnicoById(int id)
        {
            var data = await context.soporteTecnico.Where(x => x.IdResidente == id).FirstOrDefaultAsync();
            return data;
        }
        public async Task<SoporteTecnico> GetSoporteTecnicoByName(string ActividadAfectada)
        {
            var data = await context.soporteTecnico.Where(x => x.ActividadAfectada == ActividadAfectada).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> PostSoporteTecnico(SoporteTecnico soporteTecnico)
        {
            await context.soporteTecnico.AddAsync(soporteTecnico);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> PutSoporteTecnico(SoporteTecnico soporteTecnico)
        {
            context.soporteTecnico.Update(soporteTecnico);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteSoporteTecnico(int id)
        {
            var soporteTecnico = await context.soporteTecnico.FindAsync(id);

            if (soporteTecnico == null)
            {
                return false;
            }

            context.soporteTecnico.Remove(soporteTecnico);
            await context.SaveChangesAsync();
            return true;
        }

    }
}