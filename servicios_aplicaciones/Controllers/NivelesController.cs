using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios_aplicaciones.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class NivelesController : ControllerBase
{
    private readonly INivelesServicio _servicio;
    public NivelesController(INivelesServicio servicio) => _servicio = servicio;

    [HttpGet]
    public ActionResult<List<Niveles>> Listar() => Ok(_servicio.Listar());

    [HttpGet("{id:int}")]
    public ActionResult<Niveles> ObtenerPorId(int id)
    {
        var e = _servicio.ObtenerPorId(id);
        return e is null ? NotFound() : Ok(e);
    }

    [HttpPost]
    public ActionResult Insertar([FromBody] Niveles entidad)
        => _servicio.Insertar(entidad)
            ? CreatedAtAction(nameof(ObtenerPorId), new { id = entidad.Id }, entidad)
            : BadRequest();

    [HttpPut]
    public ActionResult Actualizar([FromBody] Niveles entidad)
        => _servicio.Actualizar(entidad) ? Ok() : NotFound();

    [HttpDelete("{id:int}")]
    public ActionResult Eliminar(int id)
        => _servicio.Eliminar(id) ? NoContent() : NotFound();
}
