using lib_aplicaciones.entidades;
using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;

namespace test_aplicaciones;

[TestClass]
public sealed class CategoriasServicioUT
{
    private IConexion _conexion = null!;
    private IServicio<Categorias> _servicio = null!;

    [TestInitialize]
    public void Inicializar()
    {
        _conexion = new Conexion();
        _conexion.StringConexion = "server=localhost,1433;User Id=sa;Password=TuPassword123!;TrustServerCertificate=true;database=tracking_habitos;";
        _servicio = new Servicio<Categorias>(_conexion, _conexion.Categorias!);
    }

    [TestMethod]
    public void Listar()
    {
        var lista = _servicio.Listar();
        if (lista.Count > 0) return;
        throw new Exception("No se encontraron categorias");
    }

    [TestMethod]
    public void ObtenerPorId()
    {
        var categoria = _servicio.ObtenerPorId(4);
        if (categoria != null) return;
        throw new Exception("No se encontró la categoria");
    }

    [TestMethod]
    public void Insertar()
    {
        var categoria = new Categorias { Nombre = "Test2", Descripcion = "Categoria de prueba", Color = "#000000", Icono = "🔧" };
        bool resultado = _servicio.Insertar(categoria);
        if (resultado) return;
        throw new Exception("No se pudo insertar la categoria");
    }

    [TestMethod]
    public void Actualizar()
    {
        var categoria = _servicio.ObtenerPorId(4);
        categoria!.Descripcion = "Descripcion actualizada";
        bool resultado = _servicio.Actualizar(categoria);
        if (resultado) return;
        throw new Exception("No se pudo actualizar la categoria");
    }

}
