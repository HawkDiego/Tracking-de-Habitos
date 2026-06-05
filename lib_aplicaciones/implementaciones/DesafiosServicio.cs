using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.implementaciones;

public class DesafiosServicio : ServicioBase<Desafios>, IDesafiosServicio
{
    public DesafiosServicio(IConexion conexion) : base(conexion) { }
}
