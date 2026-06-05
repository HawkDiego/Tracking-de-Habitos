using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios_aplicaciones.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class HabitosPlantillaController : ControllerBase
{
    private readonly IHabitosPlantillaServicio _servicio;
    public HabitosPlantillaController(IHabitosPlantillaServicio servicio) => _servicio = servicio;

    [HttpGet]
    public ActionResult<List<HabitosPlantilla>> Listar() => Ok(_servicio.Listar());

    [HttpGet("{id:int}")]
    public ActionResult<HabitosPlantilla> ObtenerPorId(int id)
    {
        var e = _servicio.ObtenerPorId(id);
        return e is null ? NotFound() : Ok(e);
    }

    [HttpPost]
    public ActionResult Insertar([FromBody] HabitosPlantilla entidad)
        => _servicio.Insertar(entidad)
            ? CreatedAtAction(nameof(ObtenerPorId), new { id = entidad.Id }, entidad)
            : BadRequest();

    [HttpPut]
    public ActionResult Actualizar([FromBody] HabitosPlantilla entidad)
        => _servicio.Actualizar(entidad) ? Ok() : NotFound();

    [HttpDelete("{id:int}")]
    public ActionResult Eliminar(int id)
        => _servicio.Eliminar(id) ? NoContent() : NotFound();
}
