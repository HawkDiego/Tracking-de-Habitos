// See https://aka.ms/new-console-template for more information
using System.Data.Common;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");

public class Usuarios
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Email { get; set; }
    public string? Clave { get; set; }
    public DateTime FechaRegistro { get; set; }
    public int? xpTotal { get; set; }
    public int? Nivel { get; set; }
    public int? Configuracion { get; set; }
    public Niveles? _Nivel { get; set; }
    public Configuraciones? _Configuracion { get; set; }
    public List<Habitos>? Habitos { get; set; }
    public List<UsuariosLogros>? UsuariosLogros { get; set; }
    public List<HistorialesDesbloqueo>? HistorialesDesbloqueo { get; set; }
    public List<EstadisticasUsuarios>? EstadisticasUsuario { get; set; }
    public List<UsuariosGrupos>? UsuariosGrupos { get; set; }

}

public class Niveles
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public int LimiteInferiorXp { get; set; }
    public int LimiteSuperiorXp { get; set; }
    public string? Descripcion { get; set; }
    public List<Usuarios>? Usuarios { get; set; }
    public List<Recompensas>? Recompensas { get; set; }
}

public class Configuraciones
{
    public int Id { get; set; }
    public string? Tema { get; set; }
    public string? Idioma { get; set; }
    public string? ZonaHoraria { get; set; }
    public bool Notificaciones { get; set; }
    public bool SonidoAlerta { get; set; }
    public List<Usuarios>? Usuarios { get; set; }
}

public class BaseHabitos
{
    private int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public bool Activo { get; set; }
    public int? XpOtorgada { get; set; }
    public int? Categoria { get; set; }
    public int? Frecuencia { get; set; }
}

public class Habitos: BaseHabitos
{
    public int Id { get; set; }
    public int Usuario { get; set; }
    public Categorias? _Categoria { get; set; }
    public Frecuencias? _Frecuencia { get; set; }
    public HabitosPlantilla? _HabitoPlantilla { get; set; }
    public Usuarios? _Usuario { get; set; }
    public List<RegistroProgresos>? RegistroProgreso { get; set; }
    public List<Recordatorios>? Recordatorios { get; set; }
    public List<Rachas>? Rachas { get; set; }
}

public class HabitosPlantilla: BaseHabitos
{
    public int Id { get; set; }
    public bool EsOficial { get; set; }
    public Categorias? _Categoria { get; set; }
    public Frecuencias? _Frecuencia { get; set; }
    public List<Habitos>? Habitos { get; set; }
    public List<MetricasGlobales>? MetricasGlobales { get; set; }
}

public class Categorias
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public string? Color{ get; set; }
    public string? Icono { get; set; }
    public List<Habitos>? Habitos { get; set; }
    public List<HabitosPlantilla>? HabitosPlantilla { get; set; }
    public List<MetricasGlobales>? MetricasGlobales { get; set; }
}

public class Frecuencias
{
    public int Id { get; set; }
    public string? TipoIntervalo { get; set; }
    public string? DiasSemana { get; set; }
    public int? VecesPorDia { get; set; }
    public bool esPersonalizada { get; set; }
    public List<Habitos>? Habitos { get; set; }
}

public class RegistroProgresos
{
    public int Id { get; set; }
    public int Habito { get; set; }
    public DateTime FechaLogro { get; set; }
    public bool Completado { get; set; }
    public int XpGanada { get; set; }
    public Habitos? _Habito { get; set; }
    public List<Notas>? Notas { get; set; }
}

public class Notas
{
    public int Id { get; set; }
    public string? Texto { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string? EstadoDeAnimoEmoji { get; set; }
    public bool EsPrivada { get; set; }
    public int? RegistroProgreso { get; set; }
    public RegistroProgresos? _RegistroProgreso { get; set; }
}

public class Recordatorios
{
    public int Id { get; set; }
    public int Habito { get; set; }
    public string? HoraEjecucion { get; set; }
    public string? Mensaje { get; set; }
    public bool Activo { get; set; }
    public Habitos? _Habito { get; set; }
}

public class Rachas
{
    public int Id { get; set; }
    public int Habito { get; set; }
    public int? ConteoActual { get; set; }
    public int? MaximaHistorica { get; set; }
    public DateTime? FechaUltimoIncremento { get; set; }
    public decimal? MultiplicadorXp { get; set; }
    public Habitos? _Habito { get; set; }
}

public class Logros
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public string? DescripcionRequisito { get; set; }
    public int? XpOtorgada { get; set; }
    public string? ImagenUrl { get; set; }
    public List<UsuariosLogros>? UsuariosLogros { get; set; }
}

public class UsuariosLogros
{
    public int Id { get; set; }
    public int Usuario { get; set; }
    public int Logro { get; set; }
    public DateTime FechaObtencion { get; set; }
    public Usuarios? _Usuario { get; set; }
    public Logros? _Logro { get; set; }
}

public class Recompensas
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public int? NivelRequerido { get; set; }
    public bool EsEstetica { get; set; }
    public Niveles? _NivelRequerido { get; set; }
    public List<HistorialesDesbloqueo>? HistorialesDesbloqueo { get; set; }
}

public class HistorialesDesbloqueo
{
    public int Id { get; set; }
    public int Usuario { get; set; }
    public int Recompensa { get; set; }
    public DateTime FechaObtencion { get; set; }
    public Usuarios? _Usuario { get; set; }
    public Recompensas? _Recompensa { get; set; }
}

public class EstadisticasUsuarios
{
    public int Id { get; set; }
    public int Usuario { get; set; }
    public int Mes{ get; set; }
    public int Anio { get; set; }
    public int HabitosCompletados { get; set; }
    public int XpGanadaMes { get; set; }
    public int MejorRacha { get; set; }
    public int TotalNotas { get; set; }
    public DateTime FechaCalculo { get; set; }
    public Usuarios? _Usuario { get; set; }
}

public class MetricasGlobales
{
    public int Id { get; set; }
    public int TotalUsuariosActivos { get; set; }
    public int PromedioXpPlataforma { get; set; }
    public int HabitoMasPopular { get; set; }
    public int CategoriaMasUsada { get; set; }
    public DateTime FechaCalculo { get; set; }
    public HabitosPlantilla? _HabitoMasPopular { get; set; }
    public Categorias? _CategoriaMasUsada { get; set; }
}

public class Grupos
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public int Administrador { get; set; }
    public Usuarios? _Administrador { get; set; }
    public List<UsuariosGrupos>? UsuariosGrupos { get; set; }
}

public class UsuariosGrupos
{
    public int Id { get; set; }
    public int Grupo { get; set; }
    public int Usuario { get; set; }
    public string? Rol { get; set; }
    public DateTime FechaUnion { get; set; }
    public Grupos? _Grupo { get; set; }
    public Usuarios? _Usuario { get; set; }
    public UsuariosGrupos? _UsuariosGrupo { get; set; } 
}

public class Desafios
{
    public int Id { get; set; }
    public int GrupoAdministrador { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public int XpBono { get; set; }
    public Grupos? _Grupo { get; set; }
    public List<ParticipacionDesafios>? ParticipacionDesafios { get; set; }
}

public class ParticipacionDesafios
{
    public int Id { get; set; }
    public int Desafio { get; set; }
    public int UsuariosGrupo { get; set; }
    public decimal ProgresoActual { get; set; }
    public int RankingPosicion { get; set; }
    public Desafios? _Desafio { get; set; }
    public UsuariosGrupos? _UsuariosGrupo { get; set; }
}

