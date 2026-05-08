using lib_aplicaciones.entidades;
using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;

namespace test_aplicaciones;

[TestClass]
public sealed class RecompensasServicioUT
{
    private IConexion _conexion = null!;
    private IServicio<Recompensas> _servicio = null!;

    [TestInitialize]
    public void Inicializar()
    {
        _conexion = new Conexion();
        _conexion.StringConexion = "server=localhost,1433;User Id=sa;Password=TuPassword123!;TrustServerCertificate=true;database=tracking_habitos;";
        _servicio = new Servicio<Recompensas>(_conexion, _conexion.Recompensas!);
    }

    [TestMethod]
    public void Listar()
    {
        var lista = _servicio.Listar();
        if (lista.Count > 0) return;
        throw new Exception("No se encontraron recompensas");
    }

    [TestMethod]
    public void ObtenerPorId()
    {
        var recompensa = _servicio.ObtenerPorId(1);
        if (recompensa != null) return;
        throw new Exception("No se encontró la recompensa");
    }

    [TestMethod]
    public void Insertar()
    {
        var recompensa = new Recompensas { Nombre = "Recompensa Test", Descripcion = "Descripcion de prueba", NivelRequerido = 1, EsEstetica = true, Estado = 1 };
        bool resultado = _servicio.Insertar(recompensa);
        if (resultado) return;
        throw new Exception("No se pudo insertar la recompensa");
    }

    [TestMethod]
    public void Actualizar()
    {
        var recompensa = _servicio.ObtenerPorId(1);
        recompensa!.Descripcion = "Descripcion actualizada";
        bool resultado = _servicio.Actualizar(recompensa);
        if (resultado) return;
        throw new Exception("No se pudo actualizar la recompensa");
    }

}
