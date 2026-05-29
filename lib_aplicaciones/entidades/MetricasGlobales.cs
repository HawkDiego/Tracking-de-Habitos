using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.entidades;

public class MetricasGlobales : IEntidad
{
    public int Id { get; set; }
    public int TotalUsuariosActivos { get; set; }
    public int PromedioXpPlataforma { get; set; }

    [Range(1, int.MaxValue)]
    public int HabitoMasPopular { get; set; }

    [Range(1, int.MaxValue)]
    public int CategoriaMasUsada { get; set; }

    public DateTime FechaCalculo { get; set; }
    public int? Estado { get; set; }

    [ForeignKey("HabitoMasPopular")]
    public HabitosPlantilla? _HabitoMasPopular { get; set; }

    [ForeignKey("CategoriaMasUsada")]
    public Categorias? _CategoriaMasUsada { get; set; }
}
