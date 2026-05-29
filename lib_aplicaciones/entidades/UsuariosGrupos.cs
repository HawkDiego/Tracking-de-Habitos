using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.entidades;

public class UsuariosGrupos : IEntidad
{
    public int Id { get; set; }

    [Range(1, int.MaxValue)]
    public int Grupo { get; set; }

    [Range(1, int.MaxValue)]
    public int Usuario { get; set; }

    [StringLength(50)]
    public string? Rol { get; set; }

    public DateTime FechaUnion { get; set; }
    public int? Estado { get; set; }

    [ForeignKey("Grupo")]
    public Grupos? _Grupo { get; set; }

    [ForeignKey("Usuario")]
    public Usuarios? _Usuario { get; set; }
}
