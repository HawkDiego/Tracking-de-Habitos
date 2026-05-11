using lib_aplicaciones.entidades;
using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;

namespace test_aplicaciones;

[TestClass]
public sealed class MetricasGlobalesServicioUT
{
    private IConexion _conexion = null!;
    private IServicio<MetricasGlobales> _servicio = null!;

    [TestInitialize]
    public void Inicializar()
    {
        _conexion = new Conexion();
        _servicio = new MetricasGlobalesServicio(_conexion);
    }

    [TestMethod]
    public void Listar()
    {
        var lista = _servicio.Listar();
        if (lista.Count > 0) return;
        throw new Exception("No se encontraron metricas globales");
    }

    [TestMethod]
    public void ObtenerPorId()
    {
        var metrica = _servicio.ObtenerPorId(1);
        if (metrica != null) return;
        throw new Exception("No se encontró la metrica global");
    }

    [TestMethod]
    public void Insertar()
    {
        var metrica = new MetricasGlobales { TotalUsuariosActivos = 100, PromedioXpPlataforma = 150, HabitoMasPopular = 1, CategoriaMasUsada = 1, FechaCalculo = DateTime.Today, Estado = 1 };
        bool resultado = _servicio.Insertar(metrica);
        if (resultado) return;
        throw new Exception("No se pudo insertar la metrica global");
    }

    [TestMethod]
    public void Actualizar()
    {
        var metrica = _servicio.ObtenerPorId(1);
        metrica!.TotalUsuariosActivos = 200;
        bool resultado = _servicio.Actualizar(metrica);
        if (resultado) return;
        throw new Exception("No se pudo actualizar la metrica global");
    }

}
