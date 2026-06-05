using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.implementaciones;

public class UsuariosLogrosServicio : ServicioBase<UsuariosLogros>, IUsuariosLogrosServicio
{
    public UsuariosLogrosServicio(IConexion conexion) : base(conexion) { }
}
