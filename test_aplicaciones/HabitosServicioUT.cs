using lib_aplicaciones.entidades;
using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;

namespace test_aplicaciones;

[TestClass]
public sealed class HabitosServicioUT
{
    private IConexion _conexion = null!;
    private IServicio<Habitos> _servicio = null!;

    [TestInitialize]
    public void Inicializar()
    {
        _conexion = new Conexion();
        _conexion.StringConexion = "server=localhost,1433;User Id=sa;Password=TuPassword123!;TrustServerCertificate=true;database=tracking_habitos;";
        _servicio = new Servicio<Habitos>(_conexion, _conexion.Habitos!);
    }

    [TestMethod]
    public void Listar()
    {
        var lista = _servicio.Listar();
        if (lista.Count > 0) return;
        throw new Exception("No se encontraron habitos");
    }

    [TestMethod]
    public void ObtenerPorId()
    {
        var habito = _servicio.ObtenerPorId(1);
        if (habito != null) return;
        throw new Exception("No se encontró el habito");
    }

    [TestMethod]
    public void Insertar()
    {
        var habito = new Habitos { Usuario = 1, Nombre = "Habito Test", Descripcion = "Descripcion de prueba", FechaCreacion = DateTime.Today, XpOtorgada = 15, Categoria = 1, Frecuencia = 1, Estado = 1 };
        bool resultado = _servicio.Insertar(habito);
        if (resultado) return;
        throw new Exception("No se pudo insertar el habito");
    }

    [TestMethod]
    public void Actualizar()
    {
        var habito = _servicio.ObtenerPorId(1);
        habito!.Descripcion = "Descripcion actualizada";
        bool resultado = _servicio.Actualizar(habito);
        if (resultado) return;
        throw new Exception("No se pudo actualizar el habito");
    }

}
