using System.ComponentModel.DataAnnotations.Schema;

namespace lib_aplicaciones.entidades;

public class Categorias
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public string? Color{ get; set; }
    public string? Icono { get; set; }
    public int? Estado { get; set; }
    
    [NotMapped]
    public List<Habitos>? Habitos { get; set; }
    [NotMapped]
    public List<HabitosPlantilla>? HabitosPlantilla { get; set; }
    [NotMapped]
    public List<MetricasGlobales>? MetricasGlobales { get; set; } 
}