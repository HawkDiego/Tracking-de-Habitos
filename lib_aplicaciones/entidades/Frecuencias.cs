using System.ComponentModel.DataAnnotations.Schema;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.entidades;

public class Frecuencias : IEntidad
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
