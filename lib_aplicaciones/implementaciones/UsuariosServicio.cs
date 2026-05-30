using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using lib_aplicaciones.nucleo;

namespace lib_aplicaciones.implementaciones;

public class UsuariosServicio : ServicioBase<Usuarios>, IUsuariosServicio
{
    public UsuariosServicio(IConexion conexion) : base(conexion) { }

    public override bool Insertar(Usuarios entidad)
    {
        if (string.IsNullOrWhiteSpace(entidad.Email) || string.IsNullOrWhiteSpace(entidad.Clave))
            throw new InvalidOperationException("El email y la clave son obligatorios.");

        if (Set.Any(u => u.Email == entidad.Email && u.Estado != 99))
            throw new InvalidOperationException("El email ya está registrado.");

        entidad.Clave = Hash.Sha256(entidad.Clave);
        if (entidad.FechaRegistro == default) entidad.FechaRegistro = DateTime.Now;
        entidad.Estado ??= 1;
        entidad.xpTotal ??= 0;

        return base.Insertar(entidad);
    }

    public Usuarios? Login(string email, string clave)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(clave))
            return null;

        var hash = Hash.Sha256(clave);
        return Set.FirstOrDefault(u => u.Email == email && u.Clave == hash && u.Estado != 99);
    }
}
