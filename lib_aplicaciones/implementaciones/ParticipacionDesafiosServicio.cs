using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.implementaciones;

public class ParticipacionDesafiosServicio : ServicioBase<ParticipacionDesafios>, IParticipacionDesafiosServicio
{
    public ParticipacionDesafiosServicio(IConexion conexion) : base(conexion) { }
}
