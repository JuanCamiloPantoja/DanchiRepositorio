using Danchi.Context;
using Danchi.Repositories;
using Danchi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Danchi
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration _configuration)
        {
            string connectionString = "";
            connectionString = _configuration["ConnectionStrings:SQLConnectionStrings"];

            services.AddDbContext<Danchi_Context>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IAdministradorRepository, AdministradorRepository>();
            services.AddScoped<IAnuncioAcontecimientosRepository, AnuncioAcontecimientosRepository>();
            services.AddScoped<IAutenticacionUsuarioRepository, AutenticacionUsuarioRepository>();
            services.AddScoped<IChatInternoRepository, ChatInternoRepository>();
            services.AddScoped<INotificacionEmergenciasRepository, NotificacionEmergenciasRepository>();
            services.AddScoped<IResidenteRepository, ResidenteRepository>();
            services.AddScoped<ISoporteTecnicoRepository, SoporteTecnicoRepository>();
            services.AddScoped<ISugerenciasReporteErroresRepository, SugerenciasReporteErroresRepository>();





            return services;
        }
    }
}
