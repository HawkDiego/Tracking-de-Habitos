using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.implementaciones;

public class RegistroProgresosServicio : ServicioBase<RegistroProgresos>, IRegistroProgresosServicio
{
    public RegistroProgresosServicio(IConexion conexion) : base(conexion) { }
}
