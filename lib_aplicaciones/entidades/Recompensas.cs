using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.entidades;

public class Recompensas : IEntidad
{
    public int     Id             { get; set; }

    [Required]
    [StringLength(100)]
    public string? Nombre         { get; set; }

    [StringLength(300)]
    public string? Descripcion    { get; set; }

    public int?    NivelRequerido { get; set; }
    public bool    EsEstetica     { get; set; }
    public int?    Estado         { get; set; }

    [ForeignKey("NivelRequerido")]
    public Niveles? _NivelRequerido { get; set; }
    [NotMapped]
    public List<HistorialesDesbloqueo>? HistorialesDesbloqueo { get; set; }
}
