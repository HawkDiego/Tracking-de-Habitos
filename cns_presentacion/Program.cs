using lib_aplicaciones.entidades;
using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;

var conexion = new Conexion();
conexion.StringConexion = "server=localhost,1433;User Id=sa;Password=TuPassword123!;TrustServerCertificate=true;database=tracking_habitos;";

IServicio<Niveles>          nivelesServicio          = new NivelesServicio(conexion);
IServicio<Categorias>       categoriasServicio       = new CategoriasServicio(conexion);
IServicio<Frecuencias>      frecuenciasServicio      = new FrecuenciasServicio(conexion);
IServicio<Logros>           logrosServicio           = new LogrosServicio(conexion);
IServicio<Configuraciones>  configuracionesServicio  = new ConfiguracionesServicio(conexion);
IServicio<Recompensas>      recompensasServicio      = new RecompensasServicio(conexion);
IServicio<Usuarios>         usuariosServicio         = new UsuariosServicio(conexion);
IServicio<HabitosPlantilla> habitosPlantillaServicio = new HabitosPlantillaServicio(conexion);
IServicio<Habitos>          habitosServicio          = new HabitosServicio(conexion);
IServicio<Grupos>           gruposServicio           = new GruposServicio(conexion);
IServicio<UsuariosLogros>          usuariosLogrosServicio          = new UsuariosLogrosServicio(conexion);
IServicio<RegistroProgresos>       registroProgresosServicio       = new RegistroProgresosServicio(conexion);
IServicio<Recordatorios>           recordatoriosServicio           = new RecordatoriosServicio(conexion);
IServicio<Rachas>                  rachasServicio                  = new RachasServicio(conexion);
IServicio<HistorialesDesbloqueo>   historialesDesbloqueoServicio   = new HistorialesDesbloqueoServicio(conexion);
IServicio<EstadisticasUsuarios>    estadisticasUsuariosServicio    = new EstadisticasUsuariosServicio(conexion);
IServicio<MetricasGlobales>        metricasGlobalesServicio        = new MetricasGlobalesServicio(conexion);
IServicio<UsuariosGrupos>          usuariosGruposServicio          = new UsuariosGruposServicio(conexion);
IServicio<Desafios>                desafiosServicio                = new DesafiosServicio(conexion);
IServicio<Notas>                   notasServicio                   = new NotasServicio(conexion);
IServicio<ParticipacionDesafios>   participacionDesafiosServicio   = new ParticipacionDesafiosServicio(conexion);

Console.WriteLine("=== NIVELES ===");
foreach (var n in nivelesServicio.Listar())
    Console.WriteLine($"  [{n.Id}] {n.Nombre} | XP: {n.LimiteInferiorXp} - {n.LimiteSuperiorXp} | {n.Descripcion}");

Console.WriteLine("\n=== CATEGORIAS ===");
foreach (var c in categoriasServicio.Listar())
    Console.WriteLine($"  [{c.Id}] {c.Nombre} | {c.Color} {c.Icono} | {c.Descripcion}");

Console.WriteLine("\n=== FRECUENCIAS ===");
foreach (var f in frecuenciasServicio.Listar())
    Console.WriteLine($"  [{f.Id}] {f.TipoIntervalo} | Veces/día: {f.VecesPorDia} | Personalizada: {f.esPersonalizada}");

Console.WriteLine("\n=== LOGROS ===");
foreach (var l in logrosServicio.Listar())
    Console.WriteLine($"  [{l.Id}] {l.Titulo} | XP: {l.XpOtorgada} | {l.DescripcionRequisito}");

Console.WriteLine("\n=== CONFIGURACIONES ===");
foreach (var c in configuracionesServicio.Listar())
    Console.WriteLine($"  [{c.Id}] Tema: {c.Tema} | Idioma: {c.Idioma} | Zona: {c.ZonaHoraria}");

Console.WriteLine("\n=== RECOMPENSAS ===");
foreach (var r in recompensasServicio.Listar())
    Console.WriteLine($"  [{r.Id}] {r.Nombre} | Nivel requerido: {r.NivelRequerido} | Estética: {r.EsEstetica}");

Console.WriteLine("\n=== USUARIOS ===");
foreach (var u in usuariosServicio.Listar())
    Console.WriteLine($"  [{u.Id}] {u.Nombre} | {u.Email} | XP: {u.xpTotal} | Nivel: {u.Nivel}");

Console.WriteLine("\n=== HABITOS PLANTILLA ===");
foreach (var hp in habitosPlantillaServicio.Listar())
    Console.WriteLine($"  [{hp.Id}] {hp.Nombre} | XP: {hp.XpOtorgada} | Oficial: {hp.EsOficial}");

Console.WriteLine("\n=== HABITOS ===");
foreach (var h in habitosServicio.Listar())
    Console.WriteLine($"  [{h.Id}] {h.Nombre} | Usuario: {h.Usuario} | Categoría: {h.Categoria} | XP: {h.XpOtorgada}");

Console.WriteLine("\n=== GRUPOS ===");
foreach (var g in gruposServicio.Listar())
    Console.WriteLine($"  [{g.Id}] {g.Nombre} | Administrador: {g.Administrador}");

Console.WriteLine("\n=== USUARIOS LOGROS ===");
foreach (var ul in usuariosLogrosServicio.Listar())
    Console.WriteLine($"  [{ul.Id}] Usuario: {ul.Usuario} | Logro: {ul.Logro} | Fecha: {ul.FechaObtencion.ToShortDateString()}");

Console.WriteLine("\n=== REGISTRO PROGRESOS ===");
foreach (var rp in registroProgresosServicio.Listar())
    Console.WriteLine($"  [{rp.Id}] Hábito: {rp.Habito} | Fecha: {rp.FechaLogro.ToShortDateString()} | Completado: {rp.Completado} | XP: {rp.XpGanada}");

Console.WriteLine("\n=== RECORDATORIOS ===");
foreach (var r in recordatoriosServicio.Listar())
    Console.WriteLine($"  [{r.Id}] Hábito: {r.Habito} | Hora: {r.HoraEjecucion} | Estado: {r.Estado}");

Console.WriteLine("\n=== RACHAS ===");
foreach (var r in rachasServicio.Listar())
    Console.WriteLine($"  [{r.Id}] Hábito: {r.Habito} | Actual: {r.ConteoActual} | Máxima: {r.MaximaHistorica} | Multiplicador: {r.MultiplicadorXp}");

Console.WriteLine("\n=== HISTORIALES DESBLOQUEO ===");
foreach (var h in historialesDesbloqueoServicio.Listar())
    Console.WriteLine($"  [{h.Id}] Usuario: {h.Usuario} | Recompensa: {h.Recompensa} | Fecha: {h.FechaObtencion.ToShortDateString()}");

Console.WriteLine("\n=== ESTADISTICAS USUARIOS ===");
foreach (var e in estadisticasUsuariosServicio.Listar())
    Console.WriteLine($"  [{e.Id}] Usuario: {e.Usuario} | Mes: {e.Mes}/{e.Anio} | XP: {e.XpGanadaMes} | Hábitos: {e.HabitosCompletados}");

Console.WriteLine("\n=== METRICAS GLOBALES ===");
foreach (var m in metricasGlobalesServicio.Listar())
    Console.WriteLine($"  [{m.Id}] Usuarios activos: {m.TotalUsuariosActivos} | Promedio XP: {m.PromedioXpPlataforma} | Fecha: {m.FechaCalculo.ToShortDateString()}");

Console.WriteLine("\n=== USUARIOS GRUPOS ===");
foreach (var ug in usuariosGruposServicio.Listar())
    Console.WriteLine($"  [{ug.Id}] Grupo: {ug.Grupo} | Usuario: {ug.Usuario} | Rol: {ug.Rol}");

Console.WriteLine("\n=== DESAFIOS ===");
foreach (var d in desafiosServicio.Listar())
    Console.WriteLine($"  [{d.Id}] {d.Nombre} | Grupo: {d.GrupoAdministrador} | {d.FechaInicio.ToShortDateString()} - {d.FechaFin.ToShortDateString()} | XP Bono: {d.XpBono}");

Console.WriteLine("\n=== NOTAS ===");
foreach (var n in notasServicio.Listar())
    Console.WriteLine($"  [{n.Id}] {n.Texto} | {n.EstadoDeAnimoEmoji} | Registro: {n.RegistroProgreso}");

Console.WriteLine("\n=== PARTICIPACION DESAFIOS ===");
foreach (var pd in participacionDesafiosServicio.Listar())
    Console.WriteLine($"  [{pd.Id}] Desafío: {pd.Desafio} | Grupo: {pd.UsuariosGrupo} | Progreso: {pd.ProgresoActual}% | Ranking: {pd.RankingPosicion}");
