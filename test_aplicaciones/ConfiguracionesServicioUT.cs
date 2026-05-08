using lib_aplicaciones.entidades;
using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;

namespace test_aplicaciones;

[TestClass]
public sealed class ConfiguracionesServicioUT
{
    private IConexion _conexion = null!;
    private IServicio<Configuraciones> _servicio = null!;

    [TestInitialize]
    public void Inicializar()
    {
        _conexion = new Conexion();
        _conexion.StringConexion = "server=localhost,1433;User Id=sa;Password=TuPassword123!;TrustServerCertificate=true;database=tracking_habitos;";
        _servicio = new Servicio<Configuraciones>(_conexion, _conexion.Configuraciones!);
    }

    [TestMethod]
    public void Listar()
    {
        var lista = _servicio.Listar();
        if (lista.Count > 0) return;
        throw new Exception("No se encontraron configuraciones");
    }

    [TestMethod]
    public void ObtenerPorId()
    {
        var configuracion = _servicio.ObtenerPorId(3);
        if (configuracion != null) return;
        throw new Exception("No se encontró la configuracion");
    }

    [TestMethod]
    public void Insertar()
    {
        var configuracion = new Configuraciones { Tema = "claro", Idioma = "es", ZonaHoraria = "America/Bogota", Notificaciones = true, SonidoAlerta = true, Estado = 1 };
        bool resultado = _servicio.Insertar(configuracion);
        if (resultado) return;
        throw new Exception("No se pudo insertar la configuracion");
    }

    [TestMethod]
    public void Actualizar()
    {
        var configuracion = _servicio.ObtenerPorId(3);
        configuracion!.Tema = "oscuro";
        bool resultado = _servicio.Actualizar(configuracion);
        if (resultado) return;
        throw new Exception("No se pudo actualizar la configuracion");
    }

}
