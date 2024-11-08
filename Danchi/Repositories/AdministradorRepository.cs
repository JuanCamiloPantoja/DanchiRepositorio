using Danchi.Models;
using Danchi.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Danchi.Context;
using System;

namespace Danchi.Repositories
{
    public class AdministradorRepository : IAdministradorRepository
    {
        private readonly Danchi_Context context;

        public AdministradorRepository(Danchi_Context context)
        {
            this.context = context;
        }

        public async Task<List<Administrador>> GetAdministrador()
        {
            var data = await context.administrador.ToListAsync();
            return data;
        }

        public async Task<Administrador> GetAdministradorById(int id)
        {
            var data = await context.administrador.Where(x => x.IdAdministrador == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<Administrador> GetAdministradorByName(string name)
        {
            var data = await context.administrador.Where(x => x.Nombre == name).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> PostAdministrador(Administrador administrador)
        {
            await context.administrador.AddAsync(administrador);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> PutAdministrador(Administrador administrador)
        {
            context.administrador.Update(administrador);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAdministrador(Administrador administrador)
        {
            context.administrador.Remove(administrador);
            await context.SaveAsync();
            return true;
        }
    }
}