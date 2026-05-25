using System.Text.Json;
using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace servicios_aplicaciones.Auth;

public class AuditoriaFilter : IAsyncActionFilter
{
    private readonly IAuditoriasServicio _auditorias;
    public AuditoriaFilter(IAuditoriasServicio auditorias) => _auditorias = auditorias;

    public async Task OnActionExecutionAsync(ActionExecutingContext ctx, ActionExecutionDelegate next)
    {
        var modulo = ctx.RouteData.Values["controller"]?.ToString() ?? "";
        var accion = ctx.RouteData.Values["action"]?.ToString() ?? "";
        var metodo = ctx.HttpContext.Request.Method;

        if (modulo == "Usuarios" && accion == "Insertar")
        {
            await next();
            return;
        }

        var body = SerializarArgs(ctx.ActionArguments);
        var resultado = await next();

        int? usuarioId = null;

        if (modulo == "Usuarios" && accion == "Login")
        {
            if (resultado.Result is OkObjectResult ok && ok.Value is not null)
            {
                var prop = ok.Value.GetType().GetProperty("usuario");
                if (prop?.GetValue(ok.Value) is Usuarios u) usuarioId = u.Id;
            }
        }
        else
        {
            var claim = ctx.HttpContext.User.FindFirst("UsuarioId")?.Value;
            if (int.TryParse(claim, out var id)) usuarioId = id;
        }

        if (usuarioId is null) return;

        _auditorias.Insertar(new Auditorias
        {
            Usuario     = usuarioId.Value,
            Modulo      = modulo,
            Accion      = $"{metodo} {accion}",
            Endpoint    = ctx.HttpContext.Request.Path.Value ?? "",
            Body        = body,
            FechaAccion = DateTime.Now
        });
    }

    private static string? SerializarArgs(IDictionary<string, object?> args)
    {
        if (args.Count == 0) return null;

        var redactado = args.ToDictionary(
            kv => kv.Key,
            kv => kv.Value is Usuarios u ? RedactarClave(u) : kv.Value);

        return JsonSerializer.Serialize(redactado, new JsonSerializerOptions
        {
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
        });
    }

    private static Usuarios RedactarClave(Usuarios u) => new()
    {
        Id            = u.Id,
        Nombre        = u.Nombre,
        Email         = u.Email,
        FechaRegistro = u.FechaRegistro,
        xpTotal       = u.xpTotal,
        Nivel         = u.Nivel,
        Configuracion = u.Configuracion,
        Estado        = u.Estado
    };
}
