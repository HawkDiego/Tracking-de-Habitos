using System.ComponentModel.DataAnnotations.Schema;

namespace lib_aplicaciones.entidades;

public class Auditorias
{
    public int      Id          { get; set; }
    public int      Usuario     { get; set; }
    public string?  Modulo      { get; set; }
    public string?  Accion      { get; set; }
    public string?  Endpoint    { get; set; }
    public string?  Body        { get; set; }
    public DateTime FechaAccion { get; set; }

    [ForeignKey("Usuario")]
    public Usuarios? _Usuario { get; set; }
}
