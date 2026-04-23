using lib_aplicaciones.entidades;
using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;

namespace test_aplicaciones;

[TestClass]
public sealed class EstadisticasUsuariosServicioUT
{
    private IConexion _conexion = null!;
    private IServicio<EstadisticasUsuarios> _servicio = null!;

    [TestInitialize]
    public void Inicializar()
    {
        _conexion = new Conexion();
        _conexion.StringConexion = "server=localhost,1433;User Id=sa;Password=TuPassword123!;TrustServerCertificate=true;database=tracking_habitos;";
        _servicio = new Servicio<EstadisticasUsuarios>(_conexion, _conexion.EstadisticasUsuarios!);
    }

    [TestMethod]
    public void Listar()
    {
        var lista = _servicio.Listar();
        if (lista.Count > 0) return;
        throw new Exception("No se encontraron estadisticas de usuarios");
    }

    [TestMethod]
    public void ObtenerPorId()
    {
        var estadistica = _servicio.ObtenerPorId(1);
        if (estadistica != null) return;
        throw new Exception("No se encontró la estadistica");
    }

    [TestMethod]
    public void Insertar()
    {
        var estadistica = new EstadisticasUsuarios { Usuario = 1, Mes = 3, Anio = 2026, HabitosCompletados = 5, XpGanadaMes = 50, MejorRacha = 3, TotalNotas = 2, FechaCalculo = DateTime.Today };
        bool resultado = _servicio.Insertar(estadistica);
        if (resultado) return;
        throw new Exception("No se pudo insertar la estadistica");
    }

    [TestMethod]
    public void Actualizar()
    {
        var estadistica = _servicio.ObtenerPorId(1);
        estadistica!.HabitosCompletados = 20;
        bool resultado = _servicio.Actualizar(estadistica);
        if (resultado) return;
        throw new Exception("No se pudo actualizar la estadistica");
    }

}
