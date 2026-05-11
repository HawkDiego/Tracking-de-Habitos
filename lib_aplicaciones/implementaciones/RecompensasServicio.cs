using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.implementaciones;

public class RecompensasServicio : ServicioBase<Recompensas>, IRecompensasServicio
{
    public RecompensasServicio(IConexion conexion) : base(conexion) { }
}
