using System.ComponentModel.DataAnnotations.Schema;

namespace lib_aplicaciones.entidades;

public class Notas
{
    public int Id { get; set; }
    public string? Texto { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string? EstadoDeAnimoEmoji { get; set; }
    public bool EsPrivada { get; set; }
    public int? RegistroProgreso { get; set; }

    [ForeignKey("RegistroProgreso")]
    public RegistroProgresos? _RegistroProgreso { get; set; }
}
