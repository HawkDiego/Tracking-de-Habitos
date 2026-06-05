using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.implementaciones;

public class NivelesServicio : ServicioBase<Niveles>, INivelesServicio
{
    public NivelesServicio(IConexion conexion) : base(conexion) { }
}
