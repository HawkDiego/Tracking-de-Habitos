using System.ComponentModel.DataAnnotations.Schema;

namespace lib_aplicaciones.entidades;

public class Configuraciones
{
    public int Id { get; set; }
    public string? Tema { get; set; }
    public string? Idioma { get; set; }
    public string? ZonaHoraria { get; set; }
    public bool Notificaciones { get; set; }
    public bool SonidoAlerta { get; set; }
    
    [NotMapped]
    public List<Usuarios>? Usuarios { get; set; }
}