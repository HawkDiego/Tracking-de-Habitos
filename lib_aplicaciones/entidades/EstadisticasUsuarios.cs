using System.ComponentModel.DataAnnotations.Schema;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.entidades;

public class EstadisticasUsuarios : IEntidad
{
    public int Id { get; set; }
    public int Usuario { get; set; }
    public int Mes { get; set; }
    public int Anio { get; set; }
    public int HabitosCompletados { get; set; }
    public int XpGanadaMes { get; set; }
    public int MejorRacha { get; set; }
    public int TotalNotas { get; set; }
    public DateTime FechaCalculo { get; set; }
    public int? Estado { get; set; }

    [ForeignKey("Usuario")]
    public Usuarios? _Usuario { get; set; }
}
