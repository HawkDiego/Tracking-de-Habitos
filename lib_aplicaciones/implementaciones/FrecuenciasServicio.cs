using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.implementaciones;

public class FrecuenciasServicio : ServicioBase<Frecuencias>, IFrecuenciasServicio
{
    public FrecuenciasServicio(IConexion conexion) : base(conexion) { }
}
