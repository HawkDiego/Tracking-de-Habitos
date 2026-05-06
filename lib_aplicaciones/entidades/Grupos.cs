using System.ComponentModel.DataAnnotations.Schema;

namespace lib_aplicaciones.entidades;

public class Grupos
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public int Administrador { get; set; }
    public int? Estado { get; set; }

    [ForeignKey("Administrador")]
    public Usuarios? _Administrador { get; set; }

    [NotMapped]
    public List<UsuariosGrupos>? UsuariosGrupos { get; set; }
}
