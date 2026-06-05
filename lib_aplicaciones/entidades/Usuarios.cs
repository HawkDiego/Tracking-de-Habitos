using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.entidades;

public class Usuarios : IEntidad
{
    public int Id { get; set; }

    [StringLength(100)]
    public string? Nombre { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(200)]
    public string? Email { get; set; }

    [Required]
    [StringLength(200)]
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
