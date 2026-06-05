using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.implementaciones;

public class UsuariosGruposServicio : ServicioBase<UsuariosGrupos>, IUsuariosGruposServicio
{
    public UsuariosGruposServicio(IConexion conexion) : base(conexion) { }
}
