using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.implementaciones;

public class ConfiguracionesServicio : ServicioBase<Configuraciones>, IConfiguracionesServicio
{
    public ConfiguracionesServicio(IConexion conexion) : base(conexion) { }
}
