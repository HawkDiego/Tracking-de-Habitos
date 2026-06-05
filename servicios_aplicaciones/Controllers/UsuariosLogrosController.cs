using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios_aplicaciones.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UsuariosLogrosController : ControllerBase
{
    private readonly IUsuariosLogrosServicio _servicio;
    public UsuariosLogrosController(IUsuariosLogrosServicio servicio) => _servicio = servicio;

    [HttpGet]
    public ActionResult<List<UsuariosLogros>> Listar() => Ok(_servicio.Listar());

    [HttpGet("{id:int}")]
    public ActionResult<UsuariosLogros> ObtenerPorId(int id)
    {
        var e = _servicio.ObtenerPorId(id);
        return e is null ? NotFound() : Ok(e);
    }

    [HttpPost]
    public ActionResult Insertar([FromBody] UsuariosLogros entidad)
        => _servicio.Insertar(entidad)
            ? CreatedAtAction(nameof(ObtenerPorId), new { id = entidad.Id }, entidad)
            : BadRequest();

    [HttpPut]
    public ActionResult Actualizar([FromBody] UsuariosLogros entidad)
        => _servicio.Actualizar(entidad) ? Ok() : NotFound();

    [HttpDelete("{id:int}")]
    public ActionResult Eliminar(int id)
        => _servicio.Eliminar(id) ? NoContent() : NotFound();
}
