using lib_aplicaciones.entidades;

namespace lib_aplicaciones.interfaces;

public interface IUsuariosServicio : IServicio<Usuarios>
{
    Usuarios? Login(string email, string clave);
}
