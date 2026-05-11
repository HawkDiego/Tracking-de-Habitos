using lib_aplicaciones.entidades;
using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;

namespace test_aplicaciones;

[TestClass]
public sealed class DesafiosServicioUT
{
    private IConexion _conexion = null!;
    private IServicio<Desafios> _servicio = null!;

    [TestInitialize]
    public void Inicializar()
    {
        _conexion = new Conexion();
        _servicio = new DesafiosServicio(_conexion);
    }

    [TestMethod]
    public void Listar()
    {
        var lista = _servicio.Listar();
        if (lista.Count > 0) return;
        throw new Exception("No se encontraron desafios");
    }

    [TestMethod]
    public void ObtenerPorId()
    {
        var desafio = _servicio.ObtenerPorId(1);
        if (desafio != null) return;
        throw new Exception("No se encontró el desafio");
    }

    [TestMethod]
    public void Insertar()
    {
        var desafio = new Desafios { GrupoAdministrador = 1, Nombre = "Desafio Test", Descripcion = "Descripcion de prueba", FechaInicio = DateTime.Today, FechaFin = DateTime.Today.AddDays(7), XpBono = 50, Estado = 1 };
        bool resultado = _servicio.Insertar(desafio);
        if (resultado) return;
        throw new Exception("No se pudo insertar el desafio");
    }

    [TestMethod]
    public void Actualizar()
    {
        var desafio = _servicio.ObtenerPorId(1);
        desafio!.Descripcion = "Descripcion actualizada";
        bool resultado = _servicio.Actualizar(desafio);
        if (resultado) return;
        throw new Exception("No se pudo actualizar el desafio");
    }

}
