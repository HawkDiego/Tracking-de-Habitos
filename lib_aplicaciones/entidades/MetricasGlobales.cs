using System.ComponentModel.DataAnnotations.Schema;

namespace lib_aplicaciones.entidades;

public class MetricasGlobales
{
    public int Id { get; set; }
    public int TotalUsuariosActivos { get; set; }
    public int PromedioXpPlataforma { get; set; }
    public int HabitoMasPopular { get; set; }
    public int CategoriaMasUsada { get; set; }
    public DateTime FechaCalculo { get; set; }

    [ForeignKey("HabitoMasPopular")]
    public HabitosPlantilla? _HabitoMasPopular { get; set; }

    [ForeignKey("CategoriaMasUsada")]
    public Categorias? _CategoriaMasUsada { get; set; }
}
