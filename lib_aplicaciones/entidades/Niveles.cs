using System.ComponentModel.DataAnnotations.Schema;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.entidades;

public class Niveles : IEntidad
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public int LimiteInferiorXp { get; set; }
    public int LimiteSuperiorXp { get; set; }
    public string? Descripcion { get; set; }
    public int? Estado { get; set; }
    [NotMapped]
    public List<Usuarios>? Usuarios { get; set; }
    [NotMapped]
    public List<Recompensas>? Recompensas { get; set; }
}