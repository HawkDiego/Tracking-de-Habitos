using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.implementaciones;

public class RachasServicio : ServicioBase<Rachas>, IRachasServicio
{
    public RachasServicio(IConexion conexion) : base(conexion) { }
}
