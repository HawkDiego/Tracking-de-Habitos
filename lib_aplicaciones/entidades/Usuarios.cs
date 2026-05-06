using System.ComponentModel.DataAnnotations.Schema;

namespace lib_aplicaciones.entidades;

public class Usuarios
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Email { get; set; }
    public string? Clave { get; set; }
    public DateTime FechaRegistro { get; set; }
    public int? xpTotal { get; set; }
    public int? Nivel { get; set; }
    public int? Configuracion { get; set; }
    public int? Estado { get; set; }

    [ForeignKey("Nivel")]
    public Niveles? _Nivel { get; set; }

    [ForeignKey("Configuracion")]
    public Configuraciones? _Configuracion { get; set; }

    [NotMapped]
    public List<Habitos>? Habitos { get; set; }
    [NotMapped]
    public List<UsuariosLogros>? UsuariosLogros { get; set; }
    [NotMapped]
    public List<HistorialesDesbloqueo>? HistorialesDesbloqueo { get; set; }
    [NotMapped]
    public List<EstadisticasUsuarios>? EstadisticasUsuario { get; set; }
    [NotMapped]
    public List<UsuariosGrupos>? UsuariosGrupos { get; set; }
}
