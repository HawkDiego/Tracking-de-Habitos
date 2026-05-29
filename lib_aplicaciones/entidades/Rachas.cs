using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.entidades;

public class Rachas : IEntidad
{
    public int Id { get; set; }

    [Range(1, int.MaxValue)]
    public int Habito { get; set; }

    public int? ConteoActual { get; set; }
    public int? MaximaHistorica { get; set; }
    public DateTime? FechaUltimoIncremento { get; set; }
    public decimal? MultiplicadorXp { get; set; }
    public int? Estado { get; set; }

    [ForeignKey("Habito")]
    public Habitos? _Habito { get; set; }
}
