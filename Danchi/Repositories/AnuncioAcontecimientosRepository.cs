using Danchi.Models;
using Danchi.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Danchi.Context;
using System;

namespace Danchi.Repositories
{
    public class AnuncioAcontecimientosRepository : IAnuncioAcontecimientosRepository
    {
        private readonly Danchi_Context context;

        public AnuncioAcontecimientosRepository(Danchi_Context context)
        {
            this.context = context;
        }

        public async Task<List<AnuncioAcontecimientos>> GetAnuncioAcontecimientos()
        {
            var data = await context.anuncioAcontecimientos.ToListAsync();
            return data;
        }

        public async Task<AnuncioAcontecimientos> GetAnuncioAcontecimientosById(int id)
        {
            var data = await context.anuncioAcontecimientos.Where(x => x.IdAcontecimiento == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<AnuncioAcontecimientos> GetAnuncioAcontecimientosByName(string Acontecimient)
        {
            var data = await context.anuncioAcontecimientos.Where(x => x.TipoAcontecimiento == Acontecimient).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> PostAnuncioAcontecimientos(AnuncioAcontecimientos anuncioAcontecimientos)
        {
            await context.anuncioAcontecimientos.AddAsync(anuncioAcontecimientos);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> PutAnuncioAcontecimientos(AnuncioAcontecimientos anuncioAcontecimientos)
        {
            context.anuncioAcontecimientos.Update(anuncioAcontecimientos);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAnuncioAcontecimientos(AnuncioAcontecimientos anuncioAcontecimientos)
        {
            context.anuncioAcontecimientos.Remove(anuncioAcontecimientos);
            await context.SaveAsync();
            return true;
        }
    }
}