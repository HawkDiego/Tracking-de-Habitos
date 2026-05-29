using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.entidades;

public class UsuariosLogros : IEntidad
{
    public int Id { get; set; }

    [Range(1, int.MaxValue)]
    public int Usuario { get; set; }

    [Range(1, int.MaxValue)]
    public int Logro { get; set; }

    public DateTime FechaObtencion { get; set; }
    public int? Estado { get; set; }

    [ForeignKey("Usuario")]
    public Usuarios? _Usuario { get; set; }

    [ForeignKey("Logro")]
    public Logros? _Logro { get; set; }
}
