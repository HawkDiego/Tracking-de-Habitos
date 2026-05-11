using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.implementaciones;

public class MetricasGlobalesServicio : ServicioBase<MetricasGlobales>, IMetricasGlobalesServicio
{
    public MetricasGlobalesServicio(IConexion conexion) : base(conexion) { }
}
