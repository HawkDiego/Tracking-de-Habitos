using lib_aplicaciones.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.implementaciones;

public class Servicio<T> : IServicio<T> where T : class
{
    private readonly IConexion _conexion;
    private readonly DbSet<T> _dbSet;

    public Servicio(IConexion conexion, DbSet<T> dbSet)
    {
        _conexion = conexion;
        _dbSet = dbSet;
    }

    public List<T> Listar()
        => _dbSet.ToList();

    public T? ObtenerPorId(int id)
        => _dbSet.Find(id);

    public bool Insertar(T entidad)
    {
        _dbSet.Add(entidad);
        return _conexion.SaveChanges() > 0;
    }

    public bool Actualizar(T entidad)
    {
        _dbSet.Update(entidad);
        return _conexion.SaveChanges() > 0;
    }

}
