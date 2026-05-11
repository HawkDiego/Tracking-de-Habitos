using System.ComponentModel.DataAnnotations.Schema;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.entidades;

public class HabitosPlantilla : IEntidad
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaCreacion { get; set; }

    public int? XpOtorgada { get; set; }
    public int? Categoria { get; set; }
    public int? Frecuencia { get; set; }
    public bool EsOficial { get; set; }
    public int? Estado { get; set; }

    [ForeignKey("Categoria")]
    public Categorias? _Categoria { get; set; }

    [ForeignKey("Frecuencia")]
    public Frecuencias? _Frecuencia { get; set; }

    [NotMapped]
    public List<Habitos>? Habitos { get; set; }
    [NotMapped]
    public List<MetricasGlobales>? MetricasGlobales { get; set; }
}
