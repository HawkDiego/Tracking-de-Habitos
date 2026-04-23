using System.ComponentModel.DataAnnotations.Schema;

namespace lib_aplicaciones.entidades;

public class HistorialesDesbloqueo
{
    public int Id { get; set; }
    public int Usuario { get; set; }
    public int Recompensa { get; set; }
    public DateTime FechaObtencion { get; set; }

    [ForeignKey("Usuario")]
    public Usuarios? _Usuario { get; set; }

    [ForeignKey("Recompensa")]
    public Recompensas? _Recompensa { get; set; }
}
