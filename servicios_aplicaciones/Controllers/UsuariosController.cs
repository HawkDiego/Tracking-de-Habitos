using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using servicios_aplicaciones.Auth;

namespace servicios_aplicaciones.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuariosServicio _servicio;
    private readonly JwtHelper _jwt;
    public UsuariosController(IUsuariosServicio servicio, JwtHelper jwt)
    {
        _servicio = servicio;
        _jwt = jwt;
    }

    [HttpGet]
    public ActionResult<List<Usuarios>> Listar() => Ok(_servicio.Listar());

    [HttpGet("{id:int}")]
    public ActionResult<Usuarios> ObtenerPorId(int id)
    {
        var e = _servicio.ObtenerPorId(id);
        return e is null ? NotFound() : Ok(e);
    }

    [AllowAnonymous]
    [HttpPost]
    public ActionResult Insertar([FromBody] Usuarios entidad)
        => _servicio.Insertar(entidad)
            ? CreatedAtAction(nameof(ObtenerPorId), new { id = entidad.Id }, entidad)
            : BadRequest();

    [HttpPut]
    public ActionResult Actualizar([FromBody] Usuarios entidad)
        => _servicio.Actualizar(entidad) ? Ok() : NotFound();

    [HttpDelete("{id:int}")]
    public ActionResult Eliminar(int id)
        => _servicio.Eliminar(id) ? NoContent() : NotFound();

    [AllowAnonymous]
    [HttpPost]
    public ActionResult Login([FromBody] Usuarios credenciales)
    {
        var u = _servicio.Login(credenciales.Email ?? "", credenciales.Clave ?? "");
        if (u is null) return Unauthorized();

        var token = _jwt.GenerarToken(u);
        return Ok(new { usuario = u, token });
    }

    [HttpPost]
    public ActionResult Logout()
    {
        var usuarioId = User.FindFirst("UsuarioId")?.Value;
        return Ok(new { mensaje = "Sesion cerrada. Descarta el token en el cliente.", usuarioId });
    }
}
