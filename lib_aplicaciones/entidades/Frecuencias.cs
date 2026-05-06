using System.ComponentModel.DataAnnotations.Schema;

namespace lib_aplicaciones.entidades;

public class Frecuencias
{
    public int    Id              { get; set; }
    public string? TipoIntervalo  { get; set; }
    public string? DiasSemana     { get; set; }
    public int?   VecesPorDia    { get; set; }
    public bool   esPersonalizada { get; set; }
    public int?   Estado          { get; set; }

    [NotMapped]
    public List<Habitos>? Habitos { get; set; }
    
}
