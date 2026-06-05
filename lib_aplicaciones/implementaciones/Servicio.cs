using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using lib_aplicaciones.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.implementaciones;

public abstract class ServicioBase<T> : IServicio<T> where T : class, IEntidad
{
    protected readonly IConexion _conexion;
    protected DbSet<T> Set => _conexion.Set<T>();

    private static readonly string[] _propiedadesNavegacion = typeof(T)
        .GetProperties()
        .Where(propiedad => propiedad.GetCustomAttribute<ForeignKeyAttribute>() != null)
        .Select(propiedad => propiedad.Name)
        .ToArray();

    protected ServicioBase(IConexion conexion) => _conexion = conexion;

    private IQueryable<T> ConIncludes()
    {
        IQueryable<T> consulta = Set;
        foreach (var propiedadNavegacion in _propiedadesNavegacion)
            consulta = consulta.Include(propiedadNavegacion);
        return consulta;
    }

    public virtual List<T> Listar()
        => ConIncludes().Where(e => e.Estado != 99).ToList();

    public virtual T? ObtenerPorId(int id)
        => ConIncludes().FirstOrDefault(e => e.Id == id && e.Estado != 99);

    public virtual bool Insertar(T entidad)
    {
        Set.Add(entidad);
        return _conexion.SaveChanges() > 0;
    }

    public virtual bool Actualizar(T entidad)
    {
        Set.Update(entidad);
        return _conexion.SaveChanges() > 0;
    }

    public virtual bool Eliminar(int id)
    {
        var e = Set.Find(id);
        if (e is null || e.Estado == 99) return false;
        e.Estado = 99;
        Set.Update(e);
        return _conexion.SaveChanges() > 0;
    }
}
