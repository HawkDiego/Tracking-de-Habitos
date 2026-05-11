using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.implementaciones;

public class UsuariosServicio : ServicioBase<Usuarios>, IUsuariosServicio
{
    public UsuariosServicio(IConexion conexion) : base(conexion) { }
}
