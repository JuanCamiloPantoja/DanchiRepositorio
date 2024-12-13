using Danchi.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Danchi.Context
{
    public class Danchi_Context : DbContext
    {
        public Danchi_Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Administrador> administrador { get; set; }
        public DbSet<AnuncioAcontecimientos> anuncioAcontecimientos { get; set; }
        public DbSet<AutenticacionUsuario> autenticacionUsuario { get; set; }
        public DbSet<ChatInterno> chatInterno { get; set; }
        public DbSet<NotificacionEmergencias> notificacionEmergencias { get; set; }
        public DbSet<Residente> residente { get; set; }
        public DbSet<SoporteTecnico> soporteTecnico { get; set; }
        public DbSet<SugerenciasReporteErrores> sugerenciasReporteErrores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfuguration(modelBuilder);
        }

        private void EntityConfuguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>().ToTable("Administrador");
            modelBuilder.Entity<Administrador>().HasKey(u => u.IdAdministrador);
            modelBuilder.Entity<Administrador>().Property(u => u.IdAdministrador).HasColumnName("IdAdministrador").ValueGeneratedOnAdd();
            modelBuilder.Entity<Administrador>().Property(u => u.Nombre).HasColumnName("Nombre");
            modelBuilder.Entity<Administrador>().Property(u => u.CelularAdministrador).HasColumnName("CelularAdministrador");
            modelBuilder.Entity<Administrador>().Property(u => u.CorreoElectronicoAd).HasColumnName("CorreoElectronicoAd");

            modelBuilder.Entity<AnuncioAcontecimientos>().ToTable("AnuncioAcontecimientos");
            modelBuilder.Entity<AnuncioAcontecimientos>().HasKey(u => u.IdAcontecimiento);
            modelBuilder.Entity<AnuncioAcontecimientos>().Property(u => u.IdAcontecimiento).HasColumnName("IdAcontecimiento").ValueGeneratedOnAdd();
            modelBuilder.Entity<AnuncioAcontecimientos>().Property(u => u.TipoAcontecimiento).HasColumnName("TipoAcontecimiento");
            modelBuilder.Entity<AnuncioAcontecimientos>().Property(u => u.Descripcion).HasColumnName("Descripcion");
            modelBuilder.Entity<AnuncioAcontecimientos>().Property(u => u.EstadoAcontecimiento).HasColumnName("EstadoAcontecimiento");
            modelBuilder.Entity<AnuncioAcontecimientos>().Property(u => u.LugarAcontecimiento).HasColumnName("LugarAcontecimiento");
            modelBuilder.Entity<AnuncioAcontecimientos>().Property(u => u.FechaYHora).HasColumnName("FechaYHora");

            modelBuilder.Entity<AutenticacionUsuario>().ToTable("AutenticacionUsuario");
            modelBuilder.Entity<AutenticacionUsuario>().HasKey(u => u.IdAutenticacion);
            modelBuilder.Entity<AutenticacionUsuario>().Property(u => u.IdAutenticacion).HasColumnName("IdAutenticacion").ValueGeneratedOnAdd();
            modelBuilder.Entity<AutenticacionUsuario>().Property(u => u.TipoUsuario).HasColumnName("TipoUsuario");
            modelBuilder.Entity<AutenticacionUsuario>().Property(u => u.Usuario).HasColumnName("Usuario");
            modelBuilder.Entity<AutenticacionUsuario>().Property(u => u.Contraseña).HasColumnName("Contraseña");

            modelBuilder.Entity<ChatInterno>().ToTable("ChatInterno");
            modelBuilder.Entity<ChatInterno>().HasKey(u => u.IdChat);
            modelBuilder.Entity<ChatInterno>().Property(u => u.IdChat).HasColumnName("IdChat").ValueGeneratedOnAdd();
            modelBuilder.Entity<ChatInterno>().Property(u => u.IdAdministrador).HasColumnName("IdAdministrador");
            modelBuilder.Entity<ChatInterno>().Property(u => u.IdResidente).HasColumnName("IdResidente");
            modelBuilder.Entity<ChatInterno>().Property(u => u.Mensaje).HasColumnName("Mensaje");
            modelBuilder.Entity<ChatInterno>().Property(u => u.Fecha).HasColumnName("Fecha");
            modelBuilder.Entity<ChatInterno>().Property(u => u.Hora).HasColumnName("Hora");
            modelBuilder.Entity<ChatInterno>().Property(u => u.EstadoDelMensaje).HasColumnName("EstadoDelMensaje");
            modelBuilder.Entity<ChatInterno>().Property(u => u.Asunto).HasColumnName("Asunto");
            modelBuilder.Entity<ChatInterno>().Property(u => u.Adjuntos).HasColumnName("Adjuntos");

            modelBuilder.Entity<NotificacionEmergencias>().ToTable("NotificacionEmergencias");
            modelBuilder.Entity<NotificacionEmergencias>().HasKey(u => u.IdEmergencia);
            modelBuilder.Entity<NotificacionEmergencias>().Property(u => u.IdEmergencia).HasColumnName("IdEmergencia").ValueGeneratedOnAdd();
            modelBuilder.Entity<NotificacionEmergencias>().Property(u => u.Descripcion).HasColumnName("Descripcion");
            modelBuilder.Entity<NotificacionEmergencias>().Property(u => u.AccionesRecomendadas).HasColumnName("AccionesRecomendadas");
            modelBuilder.Entity<NotificacionEmergencias>().Property(u => u.EstadoEmergencia).HasColumnName("EstadoEmergencia");
            modelBuilder.Entity<NotificacionEmergencias>().Property(u => u.TipoEmergencia).HasColumnName("TipoEmergencia");
            modelBuilder.Entity<NotificacionEmergencias>().Property(u => u.Lugar).HasColumnName("Lugar");
            modelBuilder.Entity<NotificacionEmergencias>().Property(u => u.FechaYHora).HasColumnName("FechaYHora");

            modelBuilder.Entity<Residente>().ToTable("Residente");
            modelBuilder.Entity<Residente>().HasKey(u => u.IdResidente);
            modelBuilder.Entity<Residente>().Property(u => u.IdResidente).HasColumnName("IdResidente").ValueGeneratedOnAdd();
            modelBuilder.Entity<Residente>().Property(u => u.NumApartamento).HasColumnName("NumApartamento");
            modelBuilder.Entity<Residente>().Property(u => u.CorreoElectronico).HasColumnName("CorreoElectronico");
            modelBuilder.Entity<Residente>().Property(u => u.CelularResidente).HasColumnName("CelularResidente");
            modelBuilder.Entity<Residente>().Property(u => u.Nombre).HasColumnName("Nombre");

            modelBuilder.Entity<SoporteTecnico>().ToTable("SoporteTecnico");
            modelBuilder.Entity<SoporteTecnico>().HasKey(u => u.IdSoporte);
            modelBuilder.Entity<SoporteTecnico>().Property(u => u.IdSoporte).HasColumnName("IdSoporte").ValueGeneratedOnAdd();
            modelBuilder.Entity<SoporteTecnico>().Property(u => u.IdResidente).HasColumnName("IdResidente");
            modelBuilder.Entity<SoporteTecnico>().Property(u => u.IdAdministrador).HasColumnName("IdAdministrador");
            modelBuilder.Entity<SoporteTecnico>().Property(u => u.ActividadAfectada).HasColumnName("ActividadAfectada");
            modelBuilder.Entity<SoporteTecnico>().Property(u => u.Descripcion).HasColumnName("Descripcion");
            modelBuilder.Entity<SoporteTecnico>().Property(u => u.Prioridad).HasColumnName("Prioridad");

            modelBuilder.Entity<SugerenciasReporteErrores>().ToTable("SugerenciasReporteErrores");
            modelBuilder.Entity<SugerenciasReporteErrores>().HasKey(u => u.IdSugerenciaError);
            modelBuilder.Entity<SugerenciasReporteErrores>().Property(u => u.IdSugerenciaError).HasColumnName("IdSugerenciaError").ValueGeneratedOnAdd();
            modelBuilder.Entity<SugerenciasReporteErrores>().Property(u => u.IdResidente).HasColumnName("IdResidente");
            modelBuilder.Entity<SugerenciasReporteErrores>().Property(u => u.TipoDeReporte).HasColumnName("TipoDeReporte");
            modelBuilder.Entity<SugerenciasReporteErrores>().Property(u => u.Descripcion).HasColumnName("Descripcion");
            modelBuilder.Entity<SugerenciasReporteErrores>().Property(u => u.Lugar).HasColumnName("Lugar");
            modelBuilder.Entity<SugerenciasReporteErrores>().Property(u => u.FechaYHora).HasColumnName("FechaYHora");

        }

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }
    }
}
