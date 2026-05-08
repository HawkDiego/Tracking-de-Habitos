using lib_aplicaciones.entidades;
using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;

namespace test_aplicaciones;

[TestClass]
public sealed class FrecuenciasServicioUT
{
    private IConexion _conexion = null!;
    private IServicio<Frecuencias> _servicio = null!;

    [TestInitialize]
    public void Inicializar()
    {
        _conexion = new Conexion();
        _conexion.StringConexion = "server=localhost,1433;User Id=sa;Password=TuPassword123!;TrustServerCertificate=true;database=tracking_habitos;";
        _servicio = new Servicio<Frecuencias>(_conexion, _conexion.Frecuencias!);
    }

    [TestMethod]
    public void Listar()
    {
        var lista = _servicio.Listar();
        if (lista.Count > 0) return;
        throw new Exception("No se encontraron frecuencias");
    }

    [TestMethod]
    public void ObtenerPorId()
    {
        var frecuencia = _servicio.ObtenerPorId(3);
        if (frecuencia != null) return;
        throw new Exception("No se encontró la frecuencia");
    }

    [TestMethod]
    public void Insertar()
    {
        var frecuencia = new Frecuencias { TipoIntervalo = "diario", DiasSemana = null, VecesPorDia = 1, esPersonalizada = false, Estado = 1 };
        bool resultado = _servicio.Insertar(frecuencia);
        if (resultado) return;
        throw new Exception("No se pudo insertar la frecuencia");
    }

    [TestMethod]
    public void Actualizar()
    {
        var frecuencia = _servicio.ObtenerPorId(3);
        frecuencia!.VecesPorDia = 3;
        bool resultado = _servicio.Actualizar(frecuencia);
        if (resultado) return;
        throw new Exception("No se pudo actualizar la frecuencia");
    }

}
