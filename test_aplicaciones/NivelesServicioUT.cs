using lib_aplicaciones.entidades;
using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;

namespace test_aplicaciones;

[TestClass]
public sealed class NivelesServicioUT
{
    private IConexion _conexion = null!;
    private IServicio<Niveles> _servicio = null!;

    [TestInitialize]
    public void Inicializar()
    {
        _conexion = new Conexion();
        _conexion.StringConexion = "server=localhost,1433;User Id=sa;Password=TuPassword123!;TrustServerCertificate=true;database=tracking_habitos;";
        _servicio = new Servicio<Niveles>(_conexion, _conexion.Niveles!);
    }

    [TestMethod]
    public void Listar()
    {
        var lista = _servicio.Listar();
        if (lista.Count > 0) return;
        throw new Exception("No se encontraron niveles");
    }

    [TestMethod]
    public void ObtenerPorId()
    {
        var nivel = _servicio.ObtenerPorId(1);
        if (nivel != null) return;
        throw new Exception("No se encontró el nivel");
    }

    [TestMethod]
    public void Insertar()
    {
        var nivel = new Niveles { Nombre = "Test", LimiteInferiorXp = 500, LimiteSuperiorXp = 599, Descripcion = "Nivel de prueba", Estado = 1 };
        bool resultado = _servicio.Insertar(nivel);
        if (resultado) return;
        throw new Exception("No se pudo insertar el nivel");
    }

    [TestMethod]
    public void Actualizar()
    {
        var nivel = _servicio.ObtenerPorId(1);
        nivel!.Descripcion = "Descripcion actualizada";
        bool resultado = _servicio.Actualizar(nivel);
        if (resultado) return;
        throw new Exception("No se pudo actualizar el nivel");
    }

}
