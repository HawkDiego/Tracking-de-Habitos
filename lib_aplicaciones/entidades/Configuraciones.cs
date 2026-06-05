using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.entidades;

public class Configuraciones : IEntidad
{
    public int Id { get; set; }

    [StringLength(20)]
    public string? Tema { get; set; }

    [StringLength(10)]
    public string? Idioma { get; set; }

    [StringLength(100)]
    public string? ZonaHoraria { get; set; }

    public bool Notificaciones { get; set; }
    public bool SonidoAlerta { get; set; }
    public int? Estado { get; set; }

    [NotMapped]
    public List<Usuarios>? Usuarios { get; set; }
}
