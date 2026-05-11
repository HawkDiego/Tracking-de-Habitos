using System.ComponentModel.DataAnnotations.Schema;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.entidades;

public class Habitos : IEntidad
{
    public int Id { get; set; }
    public int Usuario { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaCreacion { get; set; }

    public int? XpOtorgada { get; set; }
    public int? Categoria { get; set; }
    public int? Frecuencia { get; set; }
    public int? Estado { get; set; }

    [ForeignKey("Usuario")]
    public Usuarios? _Usuario { get; set; }

    [ForeignKey("Categoria")]
    public Categorias? _Categoria { get; set; }

    [ForeignKey("Frecuencia")]
    public Frecuencias? _Frecuencia { get; set; }

    [NotMapped]
    public List<RegistroProgresos>? RegistroProgreso { get; set; }
    [NotMapped]
    public List<Recordatorios>? Recordatorios { get; set; }
    [NotMapped]
    public List<Rachas>? Rachas { get; set; }
}
