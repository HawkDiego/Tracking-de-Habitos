using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.entidades;

public class Categorias : IEntidad
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string? Nombre { get; set; }

    [StringLength(300)]
    public string? Descripcion { get; set; }

    [StringLength(7)]
    public string? Color{ get; set; }

    [StringLength(10)]
    public string? Icono { get; set; }

    public int? Estado { get; set; }

    [NotMapped]
    public List<Habitos>? Habitos { get; set; }
    [NotMapped]
    public List<HabitosPlantilla>? HabitosPlantilla { get; set; }
    [NotMapped]
    public List<MetricasGlobales>? MetricasGlobales { get; set; }
}
