using System.ComponentModel.DataAnnotations.Schema;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.entidades;

public class UsuariosLogros : IEntidad
{
    public int Id { get; set; }
    public int Usuario { get; set; }
    public int Logro { get; set; }
    public DateTime FechaObtencion { get; set; }
    public int? Estado { get; set; }

    [ForeignKey("Usuario")]
    public Usuarios? _Usuario { get; set; }

    [ForeignKey("Logro")]
    public Logros? _Logro { get; set; }
}
