using lib_aplicaciones.entidades;
using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;

namespace test_aplicaciones;

[TestClass]
public sealed class ParticipacionDesafiosServicioUT
{
    private IConexion _conexion = null!;
    private IServicio<ParticipacionDesafios> _servicio = null!;

    [TestInitialize]
    public void Inicializar()
    {
        _conexion = new Conexion();
        _conexion.StringConexion = "server=localhost,1433;User Id=sa;Password=TuPassword123!;TrustServerCertificate=true;database=tracking_habitos;";
        _servicio = new Servicio<ParticipacionDesafios>(_conexion, _conexion.ParticipacionDesafios!);
    }

    [TestMethod]
    public void Listar()
    {
        var lista = _servicio.Listar();
        if (lista.Count > 0) return;
        throw new Exception("No se encontraron participaciones en desafios");
    }

    [TestMethod]
    public void ObtenerPorId()
    {
        var participacion = _servicio.ObtenerPorId(1);
        if (participacion != null) return;
        throw new Exception("No se encontró la participacion en desafio");
    }

    [TestMethod]
    public void Insertar()
    {
        var participacion = new ParticipacionDesafios { Desafio = 1, UsuariosGrupo = 1, ProgresoActual = 50.0m, RankingPosicion = 1 };
        bool resultado = _servicio.Insertar(participacion);
        if (resultado) return;
        throw new Exception("No se pudo insertar la participacion en desafio");
    }

    [TestMethod]
    public void Actualizar()
    {
        var participacion = _servicio.ObtenerPorId(1);
        participacion!.ProgresoActual = 95.0m;
        bool resultado = _servicio.Actualizar(participacion);
        if (resultado) return;
        throw new Exception("No se pudo actualizar la participacion en desafio");
    }

}
