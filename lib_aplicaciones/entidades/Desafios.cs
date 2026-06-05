using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.entidades;

public class Desafios : IEntidad
{
    public int Id { get; set; }

    [Range(1, int.MaxValue)]
    public int GrupoAdministrador { get; set; }

    [Required]
    [StringLength(100)]
    public string? Nombre { get; set; }

    [StringLength(300)]
    public string? Descripcion { get; set; }

    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public int XpBono { get; set; }
    public int? Estado { get; set; }

    [ForeignKey("GrupoAdministrador")]
    public Grupos? _Grupo { get; set; }
    [NotMapped]
    public List<ParticipacionDesafios>? ParticipacionDesafios { get; set; }
}
