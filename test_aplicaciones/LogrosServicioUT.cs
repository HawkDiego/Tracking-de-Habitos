using lib_aplicaciones.entidades;
using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;

namespace test_aplicaciones;

[TestClass]
public sealed class LogrosServicioUT
{
    private IConexion _conexion = null!;
    private IServicio<Logros> _servicio = null!;

    [TestInitialize]
    public void Inicializar()
    {
        _conexion = new Conexion();
        _conexion.StringConexion = "server=localhost,1433;User Id=sa;Password=TuPassword123!;TrustServerCertificate=true;database=tracking_habitos;";
        _servicio = new Servicio<Logros>(_conexion, _conexion.Logros!);
    }

    [TestMethod]
    public void Listar()
    {
        var lista = _servicio.Listar();
        if (lista.Count > 0) return;
        throw new Exception("No se encontraron logros");
    }

    [TestMethod]
    public void ObtenerPorId()
    {
        var logro = _servicio.ObtenerPorId(4);
        if (logro != null) return;
        throw new Exception("No se encontró el logro");
    }

    [TestMethod]
    public void Insertar()
    {
        var logro = new Logros { Titulo = "Logro Test", DescripcionRequisito = "Requisito de prueba", XpOtorgada = 10 };
        bool resultado = _servicio.Insertar(logro);
        if (resultado) return;
        throw new Exception("No se pudo insertar el logro");
    }

    [TestMethod]
    public void Actualizar()
    {
        var logro = _servicio.ObtenerPorId(3);
        logro!.DescripcionRequisito = "Requisito actualizado";
        bool resultado = _servicio.Actualizar(logro);
        if (resultado) return;
        throw new Exception("No se pudo actualizar el logro");
    }

}
