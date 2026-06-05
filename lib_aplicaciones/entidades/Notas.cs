using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.entidades;

public class Notas : IEntidad
{
    public int Id { get; set; }

    [StringLength(500)]
    public string? Texto { get; set; }

    public DateTime FechaCreacion { get; set; }

    [StringLength(10)]
    public string? EstadoDeAnimoEmoji { get; set; }

    public bool EsPrivada { get; set; }
    public int? RegistroProgreso { get; set; }
    public int? Estado { get; set; }

    [ForeignKey("RegistroProgreso")]
    public RegistroProgresos? _RegistroProgreso { get; set; }
}
