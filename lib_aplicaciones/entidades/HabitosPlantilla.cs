using System.ComponentModel.DataAnnotations.Schema;

namespace lib_aplicaciones.entidades;

public class HabitosPlantilla
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public bool Activo { get; set; }
    public int? XpOtorgada { get; set; }
    public int? Categoria { get; set; }
    public int? Frecuencia { get; set; }
    public bool EsOficial { get; set; }

    [ForeignKey("Categoria")]
    public Categorias? _Categoria { get; set; }

    [ForeignKey("Frecuencia")]
    public Frecuencias? _Frecuencia { get; set; }

    [NotMapped]
    public List<Habitos>? Habitos { get; set; }
    [NotMapped]
    public List<MetricasGlobales>? MetricasGlobales { get; set; }
}
