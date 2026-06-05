using lib_aplicaciones.entidades;
using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;

namespace test_aplicaciones;

[TestClass]
public sealed class HabitosPlantillaServicioUT
{
    private IConexion _conexion = null!;
    private IServicio<HabitosPlantilla> _servicio = null!;

    [TestInitialize]
    public void Inicializar()
    {
        _conexion = new Conexion();
        _servicio = new HabitosPlantillaServicio(_conexion);
    }

    [TestMethod]
    public void Listar()
    {
        var lista = _servicio.Listar();
        if (lista.Count > 0) return;
        throw new Exception("No se encontraron habitos plantilla");
    }

    [TestMethod]
    public void ObtenerPorId()
    {
        var plantilla = _servicio.ObtenerPorId(1);
        if (plantilla != null) return;
        throw new Exception("No se encontró el habito plantilla");
    }

    [TestMethod]
    public void Insertar()
    {
        var plantilla = new HabitosPlantilla { Nombre = "Plantilla Test", Descripcion = "Descripcion de prueba", FechaCreacion = DateTime.Today, XpOtorgada = 10, Categoria = 1, EsOficial = false, Estado = 1 };
        bool resultado = _servicio.Insertar(plantilla);
        if (resultado) return;
        throw new Exception("No se pudo insertar el habito plantilla");
    }

    [TestMethod]
    public void Actualizar()
    {
        var plantilla = _servicio.ObtenerPorId(1);
        plantilla!.Descripcion = "Descripcion actualizada";
        bool resultado = _servicio.Actualizar(plantilla);
        if (resultado) return;
        throw new Exception("No se pudo actualizar el habito plantilla");
    }

}
