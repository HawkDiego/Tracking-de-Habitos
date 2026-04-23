using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.implementaciones;

public class Conexion: DbContext, IConexion
{
    public string? StringConexion { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
    
    public DbSet<Niveles>? Niveles { get; set; }
    public DbSet<Categorias>? Categorias { get; set; }
    public DbSet<Frecuencias>? Frecuencias { get; set; }
    public DbSet<Logros>? Logros { get; set; }
    public DbSet<Configuraciones>? Configuraciones { get; set; }
    public DbSet<Recompensas>? Recompensas { get; set; }
    public DbSet<Usuarios>? Usuarios { get; set; }
    public DbSet<HabitosPlantilla>? HabitosPlantilla { get; set; }
    public DbSet<Habitos>? Habitos { get; set; }
    public DbSet<Grupos>? Grupos { get; set; }
    public DbSet<UsuariosLogros>? UsuariosLogros { get; set; }
    public DbSet<RegistroProgresos>? RegistroProgresos { get; set; }
    public DbSet<Recordatorios>? Recordatorios { get; set; }
    public DbSet<Rachas>? Rachas { get; set; }
    public DbSet<HistorialesDesbloqueo>? HistorialesDesbloqueo { get; set; }
    public DbSet<EstadisticasUsuarios>? EstadisticasUsuarios { get; set; }
    public DbSet<MetricasGlobales>? MetricasGlobales { get; set; }
    public DbSet<UsuariosGrupos>? UsuariosGrupos { get; set; }
    public DbSet<Desafios>? Desafios { get; set; }
    public DbSet<Notas>? Notas { get; set; }
    public DbSet<ParticipacionDesafios>? ParticipacionDesafios { get; set; }
}