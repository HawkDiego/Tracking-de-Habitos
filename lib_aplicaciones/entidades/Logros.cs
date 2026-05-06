using System.ComponentModel.DataAnnotations.Schema;

namespace lib_aplicaciones.entidades;

public class Logros
{
    public int     Id                   { get; set; }
    public string? Titulo               { get; set; }
    public string? DescripcionRequisito { get; set; }
    public int?    XpOtorgada           { get; set; }
    public string? ImagenUrl            { get; set; }
    public int?    Estado               { get; set; }

    [NotMapped]
    public List<UsuariosLogros>? UsuariosLogros { get; set; }
}
