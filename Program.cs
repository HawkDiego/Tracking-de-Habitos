// See https://aka.ms/new-console-template for more information
using System.Data.Common;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");

DatosDemo datosDemo = GeneradorDatosDemo.Crear();

Console.WriteLine("Se generaron datos de prueba:");
Console.WriteLine($"Usuarios: {datosDemo.Usuarios.Count}");
Console.WriteLine($"Niveles: {datosDemo.Niveles.Count}");
Console.WriteLine($"Configuraciones: {datosDemo.Configuraciones.Count}");
Console.WriteLine($"Habitos: {datosDemo.Habitos.Count}");
Console.WriteLine($"HabitosPlantilla: {datosDemo.HabitosPlantilla.Count}");
Console.WriteLine($"Categorias: {datosDemo.Categorias.Count}");
Console.WriteLine($"Frecuencias: {datosDemo.Frecuencias.Count}");
Console.WriteLine($"RegistroProgresos: {datosDemo.RegistroProgresos.Count}");
Console.WriteLine($"Notas: {datosDemo.Notas.Count}");
Console.WriteLine($"Recordatorios: {datosDemo.Recordatorios.Count}");
Console.WriteLine($"Rachas: {datosDemo.Rachas.Count}");
Console.WriteLine($"Logros: {datosDemo.Logros.Count}");
Console.WriteLine($"UsuariosLogros: {datosDemo.UsuariosLogros.Count}");
Console.WriteLine($"Recompensas: {datosDemo.Recompensas.Count}");
Console.WriteLine($"HistorialesDesbloqueo: {datosDemo.HistorialesDesbloqueo.Count}");
Console.WriteLine($"EstadisticasUsuarios: {datosDemo.EstadisticasUsuarios.Count}");
Console.WriteLine($"MetricasGlobales: {datosDemo.MetricasGlobales.Count}");
Console.WriteLine($"Grupos: {datosDemo.Grupos.Count}");
Console.WriteLine($"UsuariosGrupos: {datosDemo.UsuariosGrupos.Count}");
Console.WriteLine($"Desafios: {datosDemo.Desafios.Count}");
Console.WriteLine($"ParticipacionDesafios: {datosDemo.ParticipacionDesafios.Count}");

public class DatosDemo
{
    public List<Usuarios> Usuarios { get; set; } = new();
    public List<Niveles> Niveles { get; set; } = new();
    public List<Configuraciones> Configuraciones { get; set; } = new();
    public List<Habitos> Habitos { get; set; } = new();
    public List<HabitosPlantilla> HabitosPlantilla { get; set; } = new();
    public List<Categorias> Categorias { get; set; } = new();
    public List<Frecuencias> Frecuencias { get; set; } = new();
    public List<RegistroProgresos> RegistroProgresos { get; set; } = new();
    public List<Notas> Notas { get; set; } = new();
    public List<Recordatorios> Recordatorios { get; set; } = new();
    public List<Rachas> Rachas { get; set; } = new();
    public List<Logros> Logros { get; set; } = new();
    public List<UsuariosLogros> UsuariosLogros { get; set; } = new();
    public List<Recompensas> Recompensas { get; set; } = new();
    public List<HistorialesDesbloqueo> HistorialesDesbloqueo { get; set; } = new();
    public List<EstadisticasUsuarios> EstadisticasUsuarios { get; set; } = new();
    public List<MetricasGlobales> MetricasGlobales { get; set; } = new();
    public List<Grupos> Grupos { get; set; } = new();
    public List<UsuariosGrupos> UsuariosGrupos { get; set; } = new();
    public List<Desafios> Desafios { get; set; } = new();
    public List<ParticipacionDesafios> ParticipacionDesafios { get; set; } = new();
}

public static class GeneradorDatosDemo
{
    public static DatosDemo Crear()
    {
        DatosDemo datos = new();
        DateTime hoy = DateTime.Today;

        datos.Niveles = new List<Niveles>
        {
            new() { Id = 1, Nombre = "Inicial", LimiteInferiorXp = 0, LimiteSuperiorXp = 99, Descripcion = "Primer nivel" },
            new() { Id = 2, Nombre = "Constante", LimiteInferiorXp = 100, LimiteSuperiorXp = 199, Descripcion = "Mantiene hábitos" },
            new() { Id = 3, Nombre = "Comprometido", LimiteInferiorXp = 200, LimiteSuperiorXp = 299, Descripcion = "Ya tiene disciplina" },
            new() { Id = 4, Nombre = "Avanzado", LimiteInferiorXp = 300, LimiteSuperiorXp = 399, Descripcion = "Rendimiento alto" },
            new() { Id = 5, Nombre = "Elite", LimiteInferiorXp = 400, LimiteSuperiorXp = 499, Descripcion = "Referencia para otros" }
        };

        datos.Configuraciones = new List<Configuraciones>
        {
            new() { Id = 1, Tema = "claro", Idioma = "es", ZonaHoraria = "America/Bogota", Notificaciones = true, SonidoAlerta = true },
            new() { Id = 2, Tema = "oscuro", Idioma = "es", ZonaHoraria = "America/Bogota", Notificaciones = true, SonidoAlerta = false },
            new() { Id = 3, Tema = "oscuro", Idioma = "en", ZonaHoraria = "America/Mexico_City", Notificaciones = true, SonidoAlerta = true },
            new() { Id = 4, Tema = "claro", Idioma = "es", ZonaHoraria = "America/Lima", Notificaciones = false, SonidoAlerta = false },
            new() { Id = 5, Tema = "oscuro", Idioma = "es", ZonaHoraria = "America/Santiago", Notificaciones = true, SonidoAlerta = true }
        };

        datos.Usuarios = new List<Usuarios>
        {
            new() { Id = 1, Nombre = "Ana Torres", Email = "ana.torres@habitapp.com", Clave = "ClaveAna#2026", FechaRegistro = hoy.AddMonths(-6), xpTotal = 95, Configuracion = 1 },
            new() { Id = 2, Nombre = "Carlos Ruiz", Email = "carlos.ruiz@habitapp.com", Clave = "ClaveCarlos#2026", FechaRegistro = hoy.AddMonths(-8), xpTotal = 178, Configuracion = 2 },
            new() { Id = 3, Nombre = "Laura Gómez", Email = "laura.gomez@habitapp.com", Clave = "ClaveLaura#2026", FechaRegistro = hoy.AddMonths(-4), xpTotal = 242, Configuracion = 3 },
            new() { Id = 4, Nombre = "Diego Pardo", Email = "diego.pardo@habitapp.com", Clave = "ClaveDiego#2026", FechaRegistro = hoy.AddMonths(-10), xpTotal = 336, Configuracion = 4 },
            new() { Id = 5, Nombre = "Sofía Herrera", Email = "sofia.herrera@habitapp.com", Clave = "ClaveSofia#2026", FechaRegistro = hoy.AddMonths(-12), xpTotal = 415, Configuracion = 5 }
        };

        foreach (Usuarios usuario in datos.Usuarios)
        {
            int xp = usuario.xpTotal ?? 0;
            usuario.Nivel = (xp / 100) + 1;
            usuario._Nivel = datos.Niveles.FirstOrDefault(n => n.Id == usuario.Nivel);
            usuario._Configuracion = datos.Configuraciones.FirstOrDefault(c => c.Id == usuario.Configuracion);
        }

        datos.Categorias = new List<Categorias>
        {
            new() { Id = 1, Nombre = "Salud", Descripcion = "Hábitos para bienestar físico", Color = "#22C55E", Icono = "💪" },
            new() { Id = 2, Nombre = "Estudio", Descripcion = "Aprendizaje y lectura", Color = "#3B82F6", Icono = "📚" },
            new() { Id = 3, Nombre = "Productividad", Descripcion = "Organización y enfoque", Color = "#8B5CF6", Icono = "🧠" },
            new() { Id = 4, Nombre = "Finanzas", Descripcion = "Control de gastos y ahorro", Color = "#F59E0B", Icono = "💰" },
            new() { Id = 5, Nombre = "Bienestar", Descripcion = "Descanso y salud mental", Color = "#EC4899", Icono = "🧘" }
        };

        datos.Frecuencias = new List<Frecuencias>
        {
            new() { Id = 1, TipoIntervalo = "diario", DiasSemana = "1,2,3,4,5,6,7", VecesPorDia = 1, esPersonalizada = false },
            new() { Id = 2, TipoIntervalo = "semanal", DiasSemana = "1,3,5", VecesPorDia = 1, esPersonalizada = true },
            new() { Id = 3, TipoIntervalo = "diario", DiasSemana = "1,2,3,4,5", VecesPorDia = 2, esPersonalizada = true },
            new() { Id = 4, TipoIntervalo = "mensual", DiasSemana = "1", VecesPorDia = 1, esPersonalizada = false },
            new() { Id = 5, TipoIntervalo = "semanal", DiasSemana = "2,4,6", VecesPorDia = 1, esPersonalizada = true }
        };

        datos.HabitosPlantilla = new List<HabitosPlantilla>
        {
            new() { Id = 1, Nombre = "Caminar 30 minutos", Descripcion = "Actividad física ligera diaria", FechaCreacion = hoy.AddMonths(-18), Activo = true, XpOtorgada = 20, Categoria = 1, Frecuencia = null, EsOficial = true },
            new() { Id = 2, Nombre = "Leer 20 páginas", Descripcion = "Lectura constante para aprendizaje", FechaCreacion = hoy.AddMonths(-15), Activo = true, XpOtorgada = 25, Categoria = 2, Frecuencia = null, EsOficial = true },
            new() { Id = 3, Nombre = "Plan diario", Descripcion = "Planificar tareas clave del día", FechaCreacion = hoy.AddMonths(-12), Activo = true, XpOtorgada = 18, Categoria = 3, Frecuencia = null, EsOficial = true },
            new() { Id = 4, Nombre = "Registrar gastos", Descripcion = "Anotar gastos del día", FechaCreacion = hoy.AddMonths(-9), Activo = true, XpOtorgada = 15, Categoria = 4, Frecuencia = null, EsOficial = false },
            new() { Id = 5, Nombre = "Meditar 10 minutos", Descripcion = "Pausa de respiración consciente", FechaCreacion = hoy.AddMonths(-6), Activo = true, XpOtorgada = 22, Categoria = 5, Frecuencia = null, EsOficial = true }
        };

        datos.Habitos = new List<Habitos>
        {
            new() { Id = 1, Usuario = 1, Nombre = "Caminar temprano", Descripcion = "Caminar antes de iniciar labores", FechaCreacion = hoy.AddMonths(-5), Activo = true, XpOtorgada = 20, Categoria = 1, Frecuencia = 1 },
            new() { Id = 2, Usuario = 1, Nombre = "Lectura técnica", Descripcion = "Leer documentación 25 minutos", FechaCreacion = hoy.AddMonths(-4), Activo = true, XpOtorgada = 25, Categoria = 2, Frecuencia = 2 },
            new() { Id = 3, Usuario = 2, Nombre = "Bloques de foco", Descripcion = "Dos sesiones de enfoque profundo", FechaCreacion = hoy.AddMonths(-3), Activo = true, XpOtorgada = 30, Categoria = 3, Frecuencia = 3 },
            new() { Id = 4, Usuario = 3, Nombre = "Control de gastos", Descripcion = "Registrar gastos del día", FechaCreacion = hoy.AddMonths(-2), Activo = true, XpOtorgada = 15, Categoria = 4, Frecuencia = 4 },
            new() { Id = 5, Usuario = 4, Nombre = "Meditación nocturna", Descripcion = "Meditar antes de dormir", FechaCreacion = hoy.AddMonths(-1), Activo = true, XpOtorgada = 22, Categoria = 5, Frecuencia = 5 }
        };

        datos.Rachas = new List<Rachas>
        {
            new() { Id = 1, Habito = 1, ConteoActual = 6, MaximaHistorica = 9, FechaUltimoIncremento = hoy.AddDays(-1), MultiplicadorXp = 1.1m },
            new() { Id = 2, Habito = 2, ConteoActual = 3, MaximaHistorica = 7, FechaUltimoIncremento = hoy.AddDays(-2), MultiplicadorXp = 1.0m },
            new() { Id = 3, Habito = 3, ConteoActual = 12, MaximaHistorica = 15, FechaUltimoIncremento = hoy.AddDays(-1), MultiplicadorXp = 1.3m },
            new() { Id = 4, Habito = 4, ConteoActual = 2, MaximaHistorica = 5, FechaUltimoIncremento = hoy.AddDays(-3), MultiplicadorXp = 1.0m },
            new() { Id = 5, Habito = 5, ConteoActual = 8, MaximaHistorica = 11, FechaUltimoIncremento = hoy.AddDays(-1), MultiplicadorXp = 1.2m }
        };

        datos.RegistroProgresos = new List<RegistroProgresos>
        {
            new() { Id = 1, Habito = 1, FechaLogro = hoy.AddDays(-1), Completado = true },
            new() { Id = 2, Habito = 2, FechaLogro = hoy.AddDays(-2), Completado = true },
            new() { Id = 3, Habito = 3, FechaLogro = hoy.AddDays(-1), Completado = true },
            new() { Id = 4, Habito = 4, FechaLogro = hoy.AddDays(-3), Completado = false },
            new() { Id = 5, Habito = 5, FechaLogro = hoy.AddDays(-1), Completado = true }
        };

        foreach (RegistroProgresos registro in datos.RegistroProgresos)
        {
            Habitos? habito = datos.Habitos.FirstOrDefault(h => h.Id == registro.Habito);
            Rachas? racha = datos.Rachas.FirstOrDefault(r => r.Habito == registro.Habito);

            if (habito == null || !registro.Completado || !habito.Activo)
            {
                registro.XpGanada = 0;
            }
            else
            {
                decimal baseXp = habito.XpOtorgada ?? 0;
                decimal multiplicador = racha?.MultiplicadorXp ?? 1.0m;
                decimal bonusCantidad = habito.Frecuencia == 3 ? 1.1m : 1.0m;
                registro.XpGanada = (int)Math.Round(baseXp * multiplicador * bonusCantidad);
            }
        }

        datos.Notas = new List<Notas>
        {
            new() { Id = 1, Texto = "Caminata con buen ritmo y sin pausas.", FechaCreacion = hoy.AddDays(-1), EstadoDeAnimoEmoji = "😀", EsPrivada = true, RegistroProgreso = 1 },
            new() { Id = 2, Texto = "Leí un capítulo completo de arquitectura.", FechaCreacion = hoy.AddDays(-2), EstadoDeAnimoEmoji = "📖", EsPrivada = true, RegistroProgreso = 2 },
            new() { Id = 3, Texto = "Completé los dos bloques de foco planeados.", FechaCreacion = hoy.AddDays(-1), EstadoDeAnimoEmoji = "🚀", EsPrivada = true, RegistroProgreso = 3 },
            new() { Id = 4, Texto = "No registré todos los gastos; mejorar mañana.", FechaCreacion = hoy.AddDays(-3), EstadoDeAnimoEmoji = "😓", EsPrivada = true, RegistroProgreso = 4 },
            new() { Id = 5, Texto = "Meditación corta pero constante.", FechaCreacion = hoy.AddDays(-1), EstadoDeAnimoEmoji = "🧘", EsPrivada = true, RegistroProgreso = 5 }
        };

        datos.Recordatorios = new List<Recordatorios>
        {
            new() { Id = 1, Habito = 1, HoraEjecucion = "06:30", Mensaje = "Hora de caminar 30 minutos", Activo = true },
            new() { Id = 2, Habito = 2, HoraEjecucion = "20:00", Mensaje = "Momento de lectura técnica", Activo = true },
            new() { Id = 3, Habito = 3, HoraEjecucion = "09:00", Mensaje = "Inicia primer bloque de foco", Activo = true },
            new() { Id = 4, Habito = 4, HoraEjecucion = "21:00", Mensaje = "Registra los gastos del día", Activo = true },
            new() { Id = 5, Habito = 5, HoraEjecucion = "22:30", Mensaje = "Respira y medita 10 minutos", Activo = true }
        };

        datos.Logros = new List<Logros>
        {
            new() { Id = 1, Titulo = "Primer Paso", DescripcionRequisito = "Completar el primer hábito", XpOtorgada = 30, ImagenUrl = "https://example.com/logros/primer-paso.png" },
            new() { Id = 2, Titulo = "Semana Constante", DescripcionRequisito = "7 días seguidos con actividad", XpOtorgada = 80, ImagenUrl = "https://example.com/logros/semana-constante.png" },
            new() { Id = 3, Titulo = "Enfoque Total", DescripcionRequisito = "Cumplir 10 bloques de foco", XpOtorgada = 120, ImagenUrl = "https://example.com/logros/enfoque-total.png" },
            new() { Id = 4, Titulo = "Control Financiero", DescripcionRequisito = "Registrar gastos por 30 días", XpOtorgada = 150, ImagenUrl = "https://example.com/logros/control-financiero.png" },
            new() { Id = 5, Titulo = "Maestría", DescripcionRequisito = "Superar 400 XP", XpOtorgada = 200, ImagenUrl = "https://example.com/logros/maestria.png" }
        };

        datos.UsuariosLogros = new List<UsuariosLogros>
        {
            new() { Id = 1, Usuario = 1, Logro = 1, FechaObtencion = hoy.AddDays(-40) },
            new() { Id = 2, Usuario = 2, Logro = 2, FechaObtencion = hoy.AddDays(-25) },
            new() { Id = 3, Usuario = 3, Logro = 3, FechaObtencion = hoy.AddDays(-20) },
            new() { Id = 4, Usuario = 4, Logro = 4, FechaObtencion = hoy.AddDays(-10) },
            new() { Id = 5, Usuario = 5, Logro = 5, FechaObtencion = hoy.AddDays(-5) }
        };

        datos.Recompensas = new List<Recompensas>
        {
            new() { Id = 1, Nombre = "Tema Verde", Descripcion = "Tema visual de naturaleza", NivelRequerido = 1, EsEstetica = true },
            new() { Id = 2, Nombre = "Insignia Constancia", Descripcion = "Insignia visible en perfil", NivelRequerido = 2, EsEstetica = true },
            new() { Id = 3, Nombre = "Reporte Semanal", Descripcion = "Resumen automático de progreso", NivelRequerido = 3, EsEstetica = false },
            new() { Id = 4, Nombre = "Plantillas Pro", Descripcion = "Acceso a plantillas avanzadas", NivelRequerido = 4, EsEstetica = false },
            new() { Id = 5, Nombre = "Marco Elite", Descripcion = "Marco especial de perfil", NivelRequerido = 5, EsEstetica = true }
        };

        datos.HistorialesDesbloqueo = new List<HistorialesDesbloqueo>
        {
            new() { Id = 1, Usuario = 1, Recompensa = 1, FechaObtencion = hoy.AddDays(-50) },
            new() { Id = 2, Usuario = 2, Recompensa = 2, FechaObtencion = hoy.AddDays(-35) },
            new() { Id = 3, Usuario = 3, Recompensa = 3, FechaObtencion = hoy.AddDays(-20) },
            new() { Id = 4, Usuario = 4, Recompensa = 4, FechaObtencion = hoy.AddDays(-12) },
            new() { Id = 5, Usuario = 5, Recompensa = 5, FechaObtencion = hoy.AddDays(-5) }
        };

        datos.EstadisticasUsuarios = new List<EstadisticasUsuarios>
        {
            new() { Id = 1, Usuario = 1, Mes = hoy.Month, Anio = hoy.Year, HabitosCompletados = 18, XpGanadaMes = 95, MejorRacha = 6, TotalNotas = 4, FechaCalculo = hoy },
            new() { Id = 2, Usuario = 2, Mes = hoy.Month, Anio = hoy.Year, HabitosCompletados = 26, XpGanadaMes = 178, MejorRacha = 12, TotalNotas = 6, FechaCalculo = hoy },
            new() { Id = 3, Usuario = 3, Mes = hoy.Month, Anio = hoy.Year, HabitosCompletados = 31, XpGanadaMes = 242, MejorRacha = 9, TotalNotas = 7, FechaCalculo = hoy },
            new() { Id = 4, Usuario = 4, Mes = hoy.Month, Anio = hoy.Year, HabitosCompletados = 40, XpGanadaMes = 336, MejorRacha = 14, TotalNotas = 9, FechaCalculo = hoy },
            new() { Id = 5, Usuario = 5, Mes = hoy.Month, Anio = hoy.Year, HabitosCompletados = 52, XpGanadaMes = 415, MejorRacha = 21, TotalNotas = 11, FechaCalculo = hoy }
        };

        datos.MetricasGlobales = new List<MetricasGlobales>
        {
            new() { Id = 1, TotalUsuariosActivos = 108, PromedioXpPlataforma = 140, HabitoMasPopular = 1, CategoriaMasUsada = 1, FechaCalculo = hoy.AddMonths(-4) },
            new() { Id = 2, TotalUsuariosActivos = 117, PromedioXpPlataforma = 155, HabitoMasPopular = 2, CategoriaMasUsada = 2, FechaCalculo = hoy.AddMonths(-3) },
            new() { Id = 3, TotalUsuariosActivos = 126, PromedioXpPlataforma = 171, HabitoMasPopular = 3, CategoriaMasUsada = 3, FechaCalculo = hoy.AddMonths(-2) },
            new() { Id = 4, TotalUsuariosActivos = 138, PromedioXpPlataforma = 186, HabitoMasPopular = 5, CategoriaMasUsada = 5, FechaCalculo = hoy.AddMonths(-1) },
            new() { Id = 5, TotalUsuariosActivos = 145, PromedioXpPlataforma = 198, HabitoMasPopular = 1, CategoriaMasUsada = 1, FechaCalculo = hoy }
        };

        datos.Grupos = new List<Grupos>
        {
            new() { Id = 1, Nombre = "Mañanas Activas", Descripcion = "Grupo para rutinas matutinas", Administrador = 1 },
            new() { Id = 2, Nombre = "Lectura Técnica", Descripcion = "Compartir avances de estudio", Administrador = 2 },
            new() { Id = 3, Nombre = "Foco y Productividad", Descripcion = "Bloques de enfoque diario", Administrador = 3 },
            new() { Id = 4, Nombre = "Finanzas Personales", Descripcion = "Hábitos de control financiero", Administrador = 4 },
            new() { Id = 5, Nombre = "Bienestar Nocturno", Descripcion = "Rutinas de descanso y calma", Administrador = 5 }
        };

        datos.UsuariosGrupos = new List<UsuariosGrupos>
        {
            new() { Id = 1, Grupo = 1, Usuario = 1, Rol = "admin", FechaUnion = hoy.AddMonths(-5) },
            new() { Id = 2, Grupo = 2, Usuario = 2, Rol = "admin", FechaUnion = hoy.AddMonths(-4) },
            new() { Id = 3, Grupo = 3, Usuario = 3, Rol = "admin", FechaUnion = hoy.AddMonths(-3) },
            new() { Id = 4, Grupo = 4, Usuario = 4, Rol = "admin", FechaUnion = hoy.AddMonths(-2) },
            new() { Id = 5, Grupo = 5, Usuario = 5, Rol = "admin", FechaUnion = hoy.AddMonths(-1) }
        };

        datos.Desafios = new List<Desafios>
        {
            new() { Id = 1, GrupoAdministrador = 1, Nombre = "7 días caminando", Descripcion = "Completar caminata diaria por una semana", FechaInicio = hoy.AddDays(-7), FechaFin = hoy.AddDays(1), XpBono = 60 },
            new() { Id = 2, GrupoAdministrador = 2, Nombre = "Lectura de 100 páginas", Descripcion = "Acumular 100 páginas en 10 días", FechaInicio = hoy.AddDays(-5), FechaFin = hoy.AddDays(5), XpBono = 80 },
            new() { Id = 3, GrupoAdministrador = 3, Nombre = "10 bloques de foco", Descripcion = "Cumplir 10 sesiones esta semana", FechaInicio = hoy.AddDays(-3), FechaFin = hoy.AddDays(4), XpBono = 90 },
            new() { Id = 4, GrupoAdministrador = 4, Nombre = "Cero gastos hormiga", Descripcion = "Evitar gastos no planificados", FechaInicio = hoy.AddDays(-2), FechaFin = hoy.AddDays(8), XpBono = 70 },
            new() { Id = 5, GrupoAdministrador = 5, Nombre = "Meditación continua", Descripcion = "Meditar 10 minutos durante 5 días", FechaInicio = hoy.AddDays(-1), FechaFin = hoy.AddDays(6), XpBono = 75 }
        };

        datos.ParticipacionDesafios = new List<ParticipacionDesafios>
        {
            new() { Id = 1, Desafio = 1, UsuariosGrupo = 1, ProgresoActual = 85m, RankingPosicion = 1 },
            new() { Id = 2, Desafio = 2, UsuariosGrupo = 2, ProgresoActual = 60m, RankingPosicion = 2 },
            new() { Id = 3, Desafio = 3, UsuariosGrupo = 3, ProgresoActual = 90m, RankingPosicion = 1 },
            new() { Id = 4, Desafio = 4, UsuariosGrupo = 4, ProgresoActual = 45m, RankingPosicion = 3 },
            new() { Id = 5, Desafio = 5, UsuariosGrupo = 5, ProgresoActual = 70m, RankingPosicion = 2 }
        };

        foreach (Habitos habito in datos.Habitos)
        {
            habito._Usuario = datos.Usuarios.FirstOrDefault(u => u.Id == habito.Usuario);
            habito._Categoria = datos.Categorias.FirstOrDefault(c => c.Id == habito.Categoria);
            habito._Frecuencia = datos.Frecuencias.FirstOrDefault(f => f.Id == habito.Frecuencia);
            habito._HabitoPlantilla = datos.HabitosPlantilla.FirstOrDefault(p => p.Categoria == habito.Categoria);
        }

        foreach (HabitosPlantilla plantilla in datos.HabitosPlantilla)
        {
            plantilla._Categoria = datos.Categorias.FirstOrDefault(c => c.Id == plantilla.Categoria);
            plantilla.Habitos = datos.Habitos.Where(h => h.Categoria == plantilla.Categoria).ToList();
        }

        foreach (RegistroProgresos registro in datos.RegistroProgresos)
        {
            registro._Habito = datos.Habitos.FirstOrDefault(h => h.Id == registro.Habito);
            registro.Notas = datos.Notas.Where(n => n.RegistroProgreso == registro.Id).ToList();
        }

        foreach (Notas nota in datos.Notas)
        {
            nota._RegistroProgreso = datos.RegistroProgresos.FirstOrDefault(r => r.Id == nota.RegistroProgreso);
        }

        foreach (Recordatorios recordatorio in datos.Recordatorios)
        {
            recordatorio._Habito = datos.Habitos.FirstOrDefault(h => h.Id == recordatorio.Habito);
        }

        foreach (Rachas racha in datos.Rachas)
        {
            racha._Habito = datos.Habitos.FirstOrDefault(h => h.Id == racha.Habito);
        }

        foreach (UsuariosLogros usuarioLogro in datos.UsuariosLogros)
        {
            usuarioLogro._Usuario = datos.Usuarios.FirstOrDefault(u => u.Id == usuarioLogro.Usuario);
            usuarioLogro._Logro = datos.Logros.FirstOrDefault(l => l.Id == usuarioLogro.Logro);
        }

        foreach (HistorialesDesbloqueo desbloqueo in datos.HistorialesDesbloqueo)
        {
            desbloqueo._Usuario = datos.Usuarios.FirstOrDefault(u => u.Id == desbloqueo.Usuario);
            desbloqueo._Recompensa = datos.Recompensas.FirstOrDefault(r => r.Id == desbloqueo.Recompensa);
        }

        foreach (Recompensas recompensa in datos.Recompensas)
        {
            recompensa._NivelRequerido = datos.Niveles.FirstOrDefault(n => n.Id == recompensa.NivelRequerido);
            recompensa.HistorialesDesbloqueo = datos.HistorialesDesbloqueo.Where(h => h.Recompensa == recompensa.Id).ToList();
        }

        foreach (EstadisticasUsuarios estadistica in datos.EstadisticasUsuarios)
        {
            estadistica._Usuario = datos.Usuarios.FirstOrDefault(u => u.Id == estadistica.Usuario);
        }

        foreach (MetricasGlobales metrica in datos.MetricasGlobales)
        {
            metrica._HabitoMasPopular = datos.HabitosPlantilla.FirstOrDefault(p => p.Id == metrica.HabitoMasPopular);
            metrica._CategoriaMasUsada = datos.Categorias.FirstOrDefault(c => c.Id == metrica.CategoriaMasUsada);
        }

        foreach (Grupos grupo in datos.Grupos)
        {
            grupo._Administrador = datos.Usuarios.FirstOrDefault(u => u.Id == grupo.Administrador);
            grupo.UsuariosGrupos = datos.UsuariosGrupos.Where(ug => ug.Grupo == grupo.Id).ToList();
        }

        foreach (UsuariosGrupos usuarioGrupo in datos.UsuariosGrupos)
        {
            usuarioGrupo._Grupo = datos.Grupos.FirstOrDefault(g => g.Id == usuarioGrupo.Grupo);
            usuarioGrupo._Usuario = datos.Usuarios.FirstOrDefault(u => u.Id == usuarioGrupo.Usuario);
            usuarioGrupo._UsuariosGrupo = usuarioGrupo;
        }

        foreach (Desafios desafio in datos.Desafios)
        {
            desafio._Grupo = datos.Grupos.FirstOrDefault(g => g.Id == desafio.GrupoAdministrador);
            desafio.ParticipacionDesafios = datos.ParticipacionDesafios.Where(p => p.Desafio == desafio.Id).ToList();
        }

        foreach (ParticipacionDesafios participacion in datos.ParticipacionDesafios)
        {
            participacion._Desafio = datos.Desafios.FirstOrDefault(d => d.Id == participacion.Desafio);
            participacion._UsuariosGrupo = datos.UsuariosGrupos.FirstOrDefault(ug => ug.Id == participacion.UsuariosGrupo);
        }

        foreach (Usuarios usuario in datos.Usuarios)
        {
            usuario.Habitos = datos.Habitos.Where(h => h.Usuario == usuario.Id).ToList();
            usuario.UsuariosLogros = datos.UsuariosLogros.Where(ul => ul.Usuario == usuario.Id).ToList();
            usuario.HistorialesDesbloqueo = datos.HistorialesDesbloqueo.Where(hd => hd.Usuario == usuario.Id).ToList();
            usuario.EstadisticasUsuario = datos.EstadisticasUsuarios.Where(eu => eu.Usuario == usuario.Id).ToList();
            usuario.UsuariosGrupos = datos.UsuariosGrupos.Where(ug => ug.Usuario == usuario.Id).ToList();
        }

        foreach (Niveles nivel in datos.Niveles)
        {
            nivel.Usuarios = datos.Usuarios.Where(u => u.Nivel == nivel.Id).ToList();
            nivel.Recompensas = datos.Recompensas.Where(r => r.NivelRequerido == nivel.Id).ToList();
        }

        foreach (Configuraciones configuracion in datos.Configuraciones)
        {
            configuracion.Usuarios = datos.Usuarios.Where(u => u.Configuracion == configuracion.Id).ToList();
        }

        foreach (Categorias categoria in datos.Categorias)
        {
            categoria.Habitos = datos.Habitos.Where(h => h.Categoria == categoria.Id).ToList();
            categoria.HabitosPlantilla = datos.HabitosPlantilla.Where(hp => hp.Categoria == categoria.Id).ToList();
            categoria.MetricasGlobales = datos.MetricasGlobales.Where(m => m.CategoriaMasUsada == categoria.Id).ToList();
        }

        foreach (Frecuencias frecuencia in datos.Frecuencias)
        {
            frecuencia.Habitos = datos.Habitos.Where(h => h.Frecuencia == frecuencia.Id).ToList();
        }

        foreach (Logros logro in datos.Logros)
        {
            logro.UsuariosLogros = datos.UsuariosLogros.Where(ul => ul.Logro == logro.Id).ToList();
        }

        return datos;
    }
}

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