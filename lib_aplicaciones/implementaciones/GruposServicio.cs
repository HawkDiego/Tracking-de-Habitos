using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.implementaciones;

public class GruposServicio : ServicioBase<Grupos>, IGruposServicio
{
    public GruposServicio(IConexion conexion) : base(conexion) { }
}
