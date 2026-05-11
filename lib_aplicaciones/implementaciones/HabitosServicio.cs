using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.implementaciones;

public class HabitosServicio : ServicioBase<Habitos>, IHabitosServicio
{
    public HabitosServicio(IConexion conexion) : base(conexion) { }
}
