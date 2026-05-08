using lib_aplicaciones.entidades;
using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;

namespace test_aplicaciones;

[TestClass]
public sealed class NotasServicioUT
{
    private IConexion _conexion = null!;
    private IServicio<Notas> _servicio = null!;

    [TestInitialize]
    public void Inicializar()
    {
        _conexion = new Conexion();
        _conexion.StringConexion = "server=localhost,1433;User Id=sa;Password=TuPassword123!;TrustServerCertificate=true;database=tracking_habitos;";
        _servicio = new Servicio<Notas>(_conexion, _conexion.Notas!);
    }

    [TestMethod]
    public void Listar()
    {
        var lista = _servicio.Listar();
        if (lista.Count > 0) return;
        throw new Exception("No se encontraron notas");
    }

    [TestMethod]
    public void ObtenerPorId()
    {
        var nota = _servicio.ObtenerPorId(1);
        if (nota != null) return;
        throw new Exception("No se encontró la nota");
    }

    [TestMethod]
    public void Insertar()
    {
        var nota = new Notas { Texto = "Nota de prueba", FechaCreacion = DateTime.Today, EstadoDeAnimoEmoji = "😀", EsPrivada = true, RegistroProgreso = 1, Estado = 1 };
        bool resultado = _servicio.Insertar(nota);
        if (resultado) return;
        throw new Exception("No se pudo insertar la nota");
    }

    [TestMethod]
    public void Actualizar()
    {
        var nota = _servicio.ObtenerPorId(1);
        nota!.Texto = "Texto actualizado";
        bool resultado = _servicio.Actualizar(nota);
        if (resultado) return;
        throw new Exception("No se pudo actualizar la nota");
    }

}
