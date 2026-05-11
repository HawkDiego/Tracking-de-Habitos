using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.implementaciones;

public class HabitosPlantillaServicio : ServicioBase<HabitosPlantilla>, IHabitosPlantillaServicio
{
    public HabitosPlantillaServicio(IConexion conexion) : base(conexion) { }
}
