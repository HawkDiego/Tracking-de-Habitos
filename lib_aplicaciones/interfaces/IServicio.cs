namespace lib_aplicaciones.interfaces;

public interface IServicio<T> where T : class
{
    List<T> Listar();
    T?      ObtenerPorId(int id);
    bool    Insertar(T entidad);
    bool    Actualizar(T entidad);
}
