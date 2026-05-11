using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.implementaciones;

public class EstadisticasUsuariosServicio : ServicioBase<EstadisticasUsuarios>, IEstadisticasUsuariosServicio
{
    public EstadisticasUsuariosServicio(IConexion conexion) : base(conexion) { }
}
