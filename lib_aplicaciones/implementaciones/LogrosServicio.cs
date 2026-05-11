using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.implementaciones;

public class LogrosServicio : ServicioBase<Logros>, ILogrosServicio
{
    public LogrosServicio(IConexion conexion) : base(conexion) { }
}
