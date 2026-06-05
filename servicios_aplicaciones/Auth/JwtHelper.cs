using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using lib_aplicaciones.entidades;
using Microsoft.IdentityModel.Tokens;

namespace servicios_aplicaciones.Auth;

public class JwtHelper
{
    private readonly IConfiguration _config;
    public JwtHelper(IConfiguration config) => _config = config;

    public string GenerarToken(Usuarios usuario)
    {
        var key   = _config["Jwt:Key"]!;
        var iss   = _config["Jwt:Issuer"]!;
        var aud   = _config["Jwt:Audience"]!;
        var mins  = int.Parse(_config["Jwt:ExpiraMinutos"]!);

        var claims = new[]
        {
            new Claim("UsuarioId", usuario.Id.ToString()),
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Email, usuario.Email ?? ""),
            new Claim(ClaimTypes.Name,  usuario.Nombre ?? "")
        };

        var creds = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: iss,
            audience: aud,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(mins),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
