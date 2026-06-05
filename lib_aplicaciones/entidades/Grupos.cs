using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.entidades;

public class Grupos : IEntidad
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string? Nombre { get; set; }

    [StringLength(300)]
    public string? Descripcion { get; set; }

    [Range(1, int.MaxValue)]
    public int Administrador { get; set; }

    public int? Estado { get; set; }

    [ForeignKey("Administrador")]
    public Usuarios? _Administrador { get; set; }

    [NotMapped]
    public List<UsuariosGrupos>? UsuariosGrupos { get; set; }
}
