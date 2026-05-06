using System.ComponentModel.DataAnnotations.Schema;

namespace lib_aplicaciones.entidades;

public class Rachas
{
    public int Id { get; set; }
    public int Habito { get; set; }
    public int? ConteoActual { get; set; }
    public int? MaximaHistorica { get; set; }
    public DateTime? FechaUltimoIncremento { get; set; }
    public decimal? MultiplicadorXp { get; set; }
    public int? Estado { get; set; }

    [ForeignKey("Habito")]
    public Habitos? _Habito { get; set; }
}
