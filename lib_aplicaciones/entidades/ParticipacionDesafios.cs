using System.ComponentModel.DataAnnotations.Schema;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.entidades;

public class ParticipacionDesafios : IEntidad
{
    public int Id { get; set; }
    public int Desafio { get; set; }
    public int UsuariosGrupo { get; set; }
    public decimal ProgresoActual { get; set; }
    public int RankingPosicion { get; set; }
    public int? Estado { get; set; }

    [ForeignKey("Desafio")]
    public Desafios? _Desafio { get; set; }

    [ForeignKey("UsuariosGrupo")]
    public UsuariosGrupos? _UsuariosGrupo { get; set; }
}
