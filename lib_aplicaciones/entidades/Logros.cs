using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.entidades;

public class Logros : IEntidad
{
    public int     Id                   { get; set; }

    [Required]
    [StringLength(100)]
    public string? Titulo               { get; set; }

    [StringLength(500)]
    public string? DescripcionRequisito { get; set; }

    public int?    XpOtorgada           { get; set; }

    [StringLength(300)]
    public string? ImagenUrl            { get; set; }

    public int?     Estado               { get; set; }

    [NotMapped]
    public List<UsuariosLogros>? UsuariosLogros { get; set; }
}
