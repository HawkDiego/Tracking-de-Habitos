using System.ComponentModel.DataAnnotations.Schema;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.entidades;

public class RegistroProgresos : IEntidad
{
    public int Id { get; set; }
    public int Habito { get; set; }
    public DateTime FechaLogro { get; set; }
    public bool Completado { get; set; }
    public int XpGanada { get; set; }
    public int? Estado { get; set; }

    [ForeignKey("Habito")]
    public Habitos? _Habito { get; set; }
    
    [NotMapped]
    public List<Notas>? Notas { get; set; }
}
