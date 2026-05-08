using lib_aplicaciones.entidades;
using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;

namespace test_aplicaciones;

[TestClass]
public sealed class RecordatoriosServicioUT
{
    private IConexion _conexion = null!;
    private IServicio<Recordatorios> _servicio = null!;

    [TestInitialize]
    public void Inicializar()
    {
        _conexion = new Conexion();
        _conexion.StringConexion = "server=localhost,1433;User Id=sa;Password=TuPassword123!;TrustServerCertificate=true;database=tracking_habitos;";
        _servicio = new Servicio<Recordatorios>(_conexion, _conexion.Recordatorios!);
    }

    [TestMethod]
    public void Listar()
    {
        var lista = _servicio.Listar();
        if (lista.Count > 0) return;
        throw new Exception("No se encontraron recordatorios");
    }

    [TestMethod]
    public void ObtenerPorId()
    {
        var recordatorio = _servicio.ObtenerPorId(1);
        if (recordatorio != null) return;
        throw new Exception("No se encontró el recordatorio");
    }

    [TestMethod]
    public void Insertar()
    {
        var recordatorio = new Recordatorios { Habito = 1, HoraEjecucion = "07:00", Mensaje = "Recordatorio de prueba", Estado = 1 };
        bool resultado = _servicio.Insertar(recordatorio);
        if (resultado) return;
        throw new Exception("No se pudo insertar el recordatorio");
    }

    [TestMethod]
    public void Actualizar()
    {
        var recordatorio = _servicio.ObtenerPorId(1);
        recordatorio!.Mensaje = "Mensaje actualizado";
        bool resultado = _servicio.Actualizar(recordatorio);
        if (resultado) return;
        throw new Exception("No se pudo actualizar el recordatorio");
    }

}
