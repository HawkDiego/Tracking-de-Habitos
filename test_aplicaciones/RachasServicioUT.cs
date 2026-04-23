using lib_aplicaciones.entidades;
using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;

namespace test_aplicaciones;

[TestClass]
public sealed class RachasServicioUT
{
    private IConexion _conexion = null!;
    private IServicio<Rachas> _servicio = null!;

    [TestInitialize]
    public void Inicializar()
    {
        _conexion = new Conexion();
        _conexion.StringConexion = "server=localhost,1433;User Id=sa;Password=TuPassword123!;TrustServerCertificate=true;database=tracking_habitos;";
        _servicio = new Servicio<Rachas>(_conexion, _conexion.Rachas!);
    }

    [TestMethod]
    public void Listar()
    {
        var lista = _servicio.Listar();
        if (lista.Count > 0) return;
        throw new Exception("No se encontraron rachas");
    }

    [TestMethod]
    public void ObtenerPorId()
    {
        var racha = _servicio.ObtenerPorId(1);
        if (racha != null) return;
        throw new Exception("No se encontró la racha");
    }

    [TestMethod]
    public void Insertar()
    {
        var racha = new Rachas { Habito = 1, ConteoActual = 1, MaximaHistorica = 1, FechaUltimoIncremento = DateTime.Today, MultiplicadorXp = 1.0m };
        bool resultado = _servicio.Insertar(racha);
        if (resultado) return;
        throw new Exception("No se pudo insertar la racha");
    }

    [TestMethod]
    public void Actualizar()
    {
        var racha = _servicio.ObtenerPorId(1);
        racha!.ConteoActual = 10;
        bool resultado = _servicio.Actualizar(racha);
        if (resultado) return;
        throw new Exception("No se pudo actualizar la racha");
    }

}
