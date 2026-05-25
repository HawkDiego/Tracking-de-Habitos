using lib_aplicaciones.entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_aplicaciones.interfaces;

public interface IConexion
{
        string? StringConexion { get; set; }
        
        DbSet<Niveles>? Niveles { get; set; }
        DbSet<Categorias>? Categorias { get; set; }
        DbSet<Frecuencias>? Frecuencias { get; set; }
        DbSet<Logros>? Logros { get; set; }
        DbSet<Configuraciones>? Configuraciones { get; set; }
        DbSet<Recompensas>?       Recompensas       { get; set; }
        DbSet<Usuarios>?          Usuarios          { get; set; }
        DbSet<HabitosPlantilla>?  HabitosPlantilla  { get; set; }
        DbSet<Habitos>?           Habitos           { get; set; }
        DbSet<Grupos>?            Grupos            { get; set; }
        DbSet<UsuariosLogros>?       UsuariosLogros       { get; set; }
        DbSet<RegistroProgresos>?    RegistroProgresos    { get; set; }
        DbSet<Recordatorios>?        Recordatorios        { get; set; }
        DbSet<Rachas>?               Rachas               { get; set; }
        DbSet<HistorialesDesbloqueo>? HistorialesDesbloqueo { get; set; }
        DbSet<EstadisticasUsuarios>? EstadisticasUsuarios { get; set; }
        DbSet<MetricasGlobales>?     MetricasGlobales     { get; set; }
        DbSet<UsuariosGrupos>?       UsuariosGrupos       { get; set; }
        DbSet<Desafios>?             Desafios             { get; set; }
        DbSet<Notas>?                Notas                { get; set; }
        DbSet<ParticipacionDesafios>? ParticipacionDesafios { get; set; }
        DbSet<Auditorias>?            Auditorias            { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        DbSet<T>       Set<T>() where T : class;

        int SaveChanges();
}