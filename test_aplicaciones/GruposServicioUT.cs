using lib_aplicaciones.entidades;
using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;

namespace test_aplicaciones;

[TestClass]
public sealed class GruposServicioUT
{
    private IConexion _conexion = null!;
    private IServicio<Grupos> _servicio = null!;

    [TestInitialize]
    public void Inicializar()
    {
        _conexion = new Conexion();
        _servicio = new GruposServicio(_conexion);
    }

    [TestMethod]
    public void Listar()
    {
        var lista = _servicio.Listar();
        if (lista.Count > 0) return;
        throw new Exception("No se encontraron grupos");
    }

    [TestMethod]
    public void ObtenerPorId()
    {
        var grupo = _servicio.ObtenerPorId(1);
        if (grupo != null) return;
        throw new Exception("No se encontró el grupo");
    }

    [TestMethod]
    public void Insertar()
    {
        var grupo = new Grupos { Nombre = "Grupo Test", Descripcion = "Descripcion de prueba", Administrador = 1, Estado = 1 };
        bool resultado = _servicio.Insertar(grupo);
        if (resultado) return;
        throw new Exception("No se pudo insertar el grupo");
    }

    [TestMethod]
    public void Actualizar()
    {
        var grupo = _servicio.ObtenerPorId(1);
        grupo!.Descripcion = "Descripcion actualizada";
        bool resultado = _servicio.Actualizar(grupo);
        if (resultado) return;
        throw new Exception("No se pudo actualizar el grupo");
    }

}
