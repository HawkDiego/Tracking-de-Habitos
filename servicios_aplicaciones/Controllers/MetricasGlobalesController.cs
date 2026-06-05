using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios_aplicaciones.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class MetricasGlobalesController : ControllerBase
{
    private readonly IMetricasGlobalesServicio _servicio;
    public MetricasGlobalesController(IMetricasGlobalesServicio servicio) => _servicio = servicio;

    [HttpGet]
    public ActionResult<List<MetricasGlobales>> Listar() => Ok(_servicio.Listar());

    [HttpGet("{id:int}")]
    public ActionResult<MetricasGlobales> ObtenerPorId(int id)
    {
        var e = _servicio.ObtenerPorId(id);
        return e is null ? NotFound() : Ok(e);
    }

    [HttpPost]
    public ActionResult Insertar([FromBody] MetricasGlobales entidad)
        => _servicio.Insertar(entidad)
            ? CreatedAtAction(nameof(ObtenerPorId), new { id = entidad.Id }, entidad)
            : BadRequest();

    [HttpPut]
    public ActionResult Actualizar([FromBody] MetricasGlobales entidad)
        => _servicio.Actualizar(entidad) ? Ok() : NotFound();

    [HttpDelete("{id:int}")]
    public ActionResult Eliminar(int id)
        => _servicio.Eliminar(id) ? NoContent() : NotFound();
}
