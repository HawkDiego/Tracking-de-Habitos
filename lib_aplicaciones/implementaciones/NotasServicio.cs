using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.implementaciones;

public class NotasServicio : ServicioBase<Notas>, INotasServicio
{
    public NotasServicio(IConexion conexion) : base(conexion) { }
}
