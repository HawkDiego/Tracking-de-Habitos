using System.ComponentModel.DataAnnotations.Schema;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.entidades;

public class Logros : IEntidad
{
    public int     Id                   { get; set; }
    public string? Titulo               { get; set; }
    public string? DescripcionRequisito { get; set; }
    public int?    XpOtorgada           { get; set; }
    public string? ImagenUrl            { get; set; }
    public int?     Estado               { get; set; }

    [NotMapped]
    public List<UsuariosLogros>? UsuariosLogros { get; set; }
}
