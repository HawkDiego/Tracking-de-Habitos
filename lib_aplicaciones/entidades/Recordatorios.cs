using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.entidades;

public class Recordatorios : IEntidad
{
    public int Id { get; set; }

    [Range(1, int.MaxValue)]
    public int Habito { get; set; }

    [Required]
    [StringLength(10)]
    public string? HoraEjecucion { get; set; }

    [StringLength(300)]
    public string? Mensaje { get; set; }

    public int? Estado { get; set; }

    [ForeignKey("Habito")]
    public Habitos? _Habito { get; set; }
}
