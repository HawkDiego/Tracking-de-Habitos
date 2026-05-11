using System.ComponentModel.DataAnnotations.Schema;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.entidades;

public class Recordatorios : IEntidad
{
    public int Id { get; set; }
    public int Habito { get; set; }
    public string? HoraEjecucion { get; set; }
    public string? Mensaje { get; set; }

    public int? Estado { get; set; }

    [ForeignKey("Habito")]
    public Habitos? _Habito { get; set; }
}
