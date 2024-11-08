using Danchi.Models;
using Danchi.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Danchi.Context;
using System;

namespace Danchi.Repositories
{
    public class ResidenteRepository : IResidenteRepository
    {
        private readonly Danchi_Context context;

        public ResidenteRepository(Danchi_Context context)
        {
            this.context = context;
        }

        public async Task<List<Residente>> GetResidente()
        {
            var data = await context.residente.ToListAsync();
            return data;
        }

        public async Task<Residente> GetResidenteById(int id)
        {
            var data = await context.residente.Where(x => x.IdResidente == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<Residente> GetResidenteByName(string NumApartamento)
        {
            var data = await context.residente.Where(x => x.NumApartamento == NumApartamento).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> PostResidente(Residente residente)
        {
            await context.residente.AddAsync(residente);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> PutResidente(Residente residente)
        {
            context.residente.Update(residente);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteResidente(Residente residente)
        {
            context.residente.Remove(residente);
            await context.SaveAsync();
            return true;
        }
    }
}