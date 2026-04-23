using System.ComponentModel.DataAnnotations.Schema;

namespace lib_aplicaciones.entidades;

public class Recompensas
{
    public int     Id             { get; set; }
    public string? Nombre         { get; set; }
    public string? Descripcion    { get; set; }
    public int?    NivelRequerido { get; set; }
    public bool    EsEstetica     { get; set; }

    [ForeignKey("NivelRequerido")]
    public Niveles? _NivelRequerido { get; set; }
    [NotMapped]
    public List<HistorialesDesbloqueo>? HistorialesDesbloqueo { get; set; }
}