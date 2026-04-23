using lib_aplicaciones.entidades;
using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;

namespace test_aplicaciones;

[TestClass]
public sealed class UsuariosLogrosServicioUT
{
    private IConexion _conexion = null!;
    private IServicio<UsuariosLogros> _servicio = null!;

    [TestInitialize]
    public void Inicializar()
    {
        _conexion = new Conexion();
        _conexion.StringConexion = "server=localhost,1433;User Id=sa;Password=TuPassword123!;TrustServerCertificate=true;database=tracking_habitos;";
        _servicio = new Servicio<UsuariosLogros>(_conexion, _conexion.UsuariosLogros!);
    }

    [TestMethod]
    public void Listar()
    {
        var lista = _servicio.Listar();
        if (lista.Count > 0) return;
        throw new Exception("No se encontraron usuarios logros");
    }

    [TestMethod]
    public void ObtenerPorId()
    {
        var usuarioLogro = _servicio.ObtenerPorId(1);
        if (usuarioLogro != null) return;
        throw new Exception("No se encontró el usuario logro");
    }

    [TestMethod]
    public void Insertar()
    {
        var usuarioLogro = new UsuariosLogros { Usuario = 1, Logro = 1, FechaObtencion = DateTime.Today };
        bool resultado = _servicio.Insertar(usuarioLogro);
        if (resultado) return;
        throw new Exception("No se pudo insertar el usuario logro");
    }

    [TestMethod]
    public void Actualizar()
    {
        var usuarioLogro = _servicio.ObtenerPorId(1);
        usuarioLogro!.FechaObtencion = DateTime.Today;
        bool resultado = _servicio.Actualizar(usuarioLogro);
        if (resultado) return;
        throw new Exception("No se pudo actualizar el usuario logro");
    }

}
