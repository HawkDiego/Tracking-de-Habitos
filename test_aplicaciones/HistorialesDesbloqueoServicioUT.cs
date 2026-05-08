using lib_aplicaciones.entidades;
using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;

namespace test_aplicaciones;

[TestClass]
public sealed class HistorialesDesbloqueoServicioUT
{
    private IConexion _conexion = null!;
    private IServicio<HistorialesDesbloqueo> _servicio = null!;

    [TestInitialize]
    public void Inicializar()
    {
        _conexion = new Conexion();
        _conexion.StringConexion = "server=localhost,1433;User Id=sa;Password=TuPassword123!;TrustServerCertificate=true;database=tracking_habitos;";
        _servicio = new Servicio<HistorialesDesbloqueo>(_conexion, _conexion.HistorialesDesbloqueo!);
    }

    [TestMethod]
    public void Listar()
    {
        var lista = _servicio.Listar();
        if (lista.Count > 0) return;
        throw new Exception("No se encontraron historiales de desbloqueo");
    }

    [TestMethod]
    public void ObtenerPorId()
    {
        var historial = _servicio.ObtenerPorId(1);
        if (historial != null) return;
        throw new Exception("No se encontró el historial de desbloqueo");
    }

    [TestMethod]
    public void Insertar()
    {
        var historial = new HistorialesDesbloqueo { Usuario = 1, Recompensa = 1, FechaObtencion = DateTime.Today, Estado = 1 };
        bool resultado = _servicio.Insertar(historial);
        if (resultado) return;
        throw new Exception("No se pudo insertar el historial de desbloqueo");
    }

    [TestMethod]
    public void Actualizar()
    {
        var historial = _servicio.ObtenerPorId(1);
        historial!.FechaObtencion = DateTime.Today;
        bool resultado = _servicio.Actualizar(historial);
        if (resultado) return;
        throw new Exception("No se pudo actualizar el historial de desbloqueo");
    }

}
