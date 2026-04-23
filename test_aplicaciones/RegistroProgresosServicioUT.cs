using lib_aplicaciones.entidades;
using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;

namespace test_aplicaciones;

[TestClass]
public sealed class RegistroProgresosServicioUT
{
    private IConexion _conexion = null!;
    private IServicio<RegistroProgresos> _servicio = null!;

    [TestInitialize]
    public void Inicializar()
    {
        _conexion = new Conexion();
        _conexion.StringConexion = "server=localhost,1433;User Id=sa;Password=TuPassword123!;TrustServerCertificate=true;database=tracking_habitos;";
        _servicio = new Servicio<RegistroProgresos>(_conexion, _conexion.RegistroProgresos!);
    }

    [TestMethod]
    public void Listar()
    {
        var lista = _servicio.Listar();
        if (lista.Count > 0) return;
        throw new Exception("No se encontraron registros de progreso");
    }

    [TestMethod]
    public void ObtenerPorId()
    {
        var registro = _servicio.ObtenerPorId(1);
        if (registro != null) return;
        throw new Exception("No se encontró el registro de progreso");
    }

    [TestMethod]
    public void Insertar()
    {
        var registro = new RegistroProgresos { Habito = 1, FechaLogro = DateTime.Today, Completado = true, XpGanada = 20 };
        bool resultado = _servicio.Insertar(registro);
        if (resultado) return;
        throw new Exception("No se pudo insertar el registro de progreso");
    }

    [TestMethod]
    public void Actualizar()
    {
        var registro = _servicio.ObtenerPorId(1);
        registro!.XpGanada = 30;
        bool resultado = _servicio.Actualizar(registro);
        if (resultado) return;
        throw new Exception("No se pudo actualizar el registro de progreso");
    }

}
