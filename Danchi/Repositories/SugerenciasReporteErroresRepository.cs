using Danchi.Models;
using Danchi.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Danchi.Context;
using System;

namespace Danchi.Repositories
{
    public class SugerenciasReporteErroresRepository : ISugerenciasReporteErroresRepository
    {
        private readonly Danchi_Context context;

        public SugerenciasReporteErroresRepository(Danchi_Context context)
        {
            this.context = context;
        }

        public async Task<List<SugerenciasReporteErrores>> GetSugerenciasReporteErrores()
        {
            var data = await context.sugerenciasReporteErrores.ToListAsync();
            return data;
        }

        public async Task<SugerenciasReporteErrores> GetSugerenciasReporteErroresById(int id)
        {
            var data = await context.sugerenciasReporteErrores.Where(x => x.IdResidente == id).FirstOrDefaultAsync();
            return data;
        }
        public async Task<SugerenciasReporteErrores> GetSugerenciasReporteErroresByName(string TipoDeReporte)
        {
            var data = await context.sugerenciasReporteErrores.Where(x => x.TipoDeReporte == TipoDeReporte).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> PostSugerenciasReporteErrores(SugerenciasReporteErrores sugerenciasReporteErrores)
        {
            await context.sugerenciasReporteErrores.AddAsync(sugerenciasReporteErrores);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> PutSugerenciasReporteErrores(SugerenciasReporteErrores sugerenciasReporteErrores)
        {
            context.sugerenciasReporteErrores.Update(sugerenciasReporteErrores);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteSugerenciasReporteErrores(int id)
        {
            var sugerenciaReporteErrores = await context.sugerenciasReporteErrores.FindAsync(id);

            if (sugerenciaReporteErrores == null)
            {
                return false;
            }

            context.sugerenciasReporteErrores.Remove(sugerenciaReporteErrores);
            await context.SaveChangesAsync();
            return true;
        }

    }
}