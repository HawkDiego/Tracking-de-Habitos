using lib_aplicaciones.entidades;
using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;

namespace test_aplicaciones;

[TestClass]
public sealed class UsuariosServicioUT
{
    private IConexion _conexion = null!;
    private IServicio<Usuarios> _servicio = null!;

    [TestInitialize]
    public void Inicializar()
    {
        _conexion = new Conexion();
        _servicio = new UsuariosServicio(_conexion);
    }

    [TestMethod]
    public void Listar()
    {
        var lista = _servicio.Listar();
        if (lista.Count > 0) return;
        throw new Exception("No se encontraron usuarios");
    }

    [TestMethod]
    public void ObtenerPorId()
    {
        var usuario = _servicio.ObtenerPorId(1);
        if (usuario != null) return;
        throw new Exception("No se encontró el usuario");
    }

    [TestMethod]
    public void Insertar()
    {
        var usuario = new Usuarios { Nombre = "Test User", Email = "test@habitapp.com", Clave = "ClaveTest#2026", FechaRegistro = DateTime.Today, xpTotal = 0, Nivel = 1, Configuracion = 1, Estado = 1 };
        bool resultado = _servicio.Insertar(usuario);
        if (resultado) return;
        throw new Exception("No se pudo insertar el usuario");
    }

    [TestMethod]
    public void Actualizar()
    {
        var usuario = _servicio.ObtenerPorId(1);
        usuario!.Nombre = "Nombre actualizado";
        bool resultado = _servicio.Actualizar(usuario);
        if (resultado) return;
        throw new Exception("No se pudo actualizar el usuario");
    }

}
