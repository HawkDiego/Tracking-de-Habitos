using lib_aplicaciones.entidades;
using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;

namespace test_aplicaciones;

[TestClass]
public sealed class UsuariosGruposServicioUT
{
    private IConexion _conexion = null!;
    private IServicio<UsuariosGrupos> _servicio = null!;

    [TestInitialize]
    public void Inicializar()
    {
        _conexion = new Conexion();
        _conexion.StringConexion = "server=localhost,1433;User Id=sa;Password=TuPassword123!;TrustServerCertificate=true;database=tracking_habitos;";
        _servicio = new Servicio<UsuariosGrupos>(_conexion, _conexion.UsuariosGrupos!);
    }

    [TestMethod]
    public void Listar()
    {
        var lista = _servicio.Listar();
        if (lista.Count > 0) return;
        throw new Exception("No se encontraron usuarios grupos");
    }

    [TestMethod]
    public void ObtenerPorId()
    {
        var usuarioGrupo = _servicio.ObtenerPorId(1);
        if (usuarioGrupo != null) return;
        throw new Exception("No se encontró el usuario grupo");
    }

    [TestMethod]
    public void Insertar()
    {
        var usuarioGrupo = new UsuariosGrupos { Grupo = 1, Usuario = 2, Rol = "miembro", FechaUnion = DateTime.Today, Estado = 1 };
        bool resultado = _servicio.Insertar(usuarioGrupo);
        if (resultado) return;
        throw new Exception("No se pudo insertar el usuario grupo");
    }

    [TestMethod]
    public void Actualizar()
    {
        var usuarioGrupo = _servicio.ObtenerPorId(1);
        usuarioGrupo!.Rol = "moderador";
        bool resultado = _servicio.Actualizar(usuarioGrupo);
        if (resultado) return;
        throw new Exception("No se pudo actualizar el usuario grupo");
    }

}
