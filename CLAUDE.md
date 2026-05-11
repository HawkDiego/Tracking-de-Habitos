# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Descripción del proyecto

Aplicación de seguimiento de hábitos ("tracking_habitos") construida con C# / .NET 10. Usa Entity Framework Core con SQL Server como base de datos. Todo el proyecto está en español: nombres de entidades, propiedades, servicios y pruebas.

## Comandos de desarrollo

```bash
# Restaurar dependencias
dotnet restore tracking_habitos.sln

# Compilar toda la solución
dotnet build tracking_habitos.sln

# Ejecutar la aplicación de consola
dotnet run --project cns_presentacion

# Ejecutar todas las pruebas
dotnet test test_aplicaciones

# Ejecutar una prueba específica
dotnet test test_aplicaciones --filter "FullyQualifiedName~NivelesServicioUT.Listar"
```

## Base de datos

SQL Server en `localhost:1433` (sa / TuPassword123!). Esquema definido en `tracking_habitos.sql`. 21 tablas. Las pruebas se conectan a esta misma BD (pruebas de integración, sin mocks). Cadena de conexión centralizada en `lib_aplicaciones/implementaciones/ConfiguracionBD.cs`.

## Arquitectura

Solución de cuatro proyectos con patrón por capas:

- **lib_aplicaciones** — Biblioteca de clases. Núcleo:
  - `entidades/` — Clases EF Core mapeadas a tablas SQL. Todas implementan `IEntidad` (`Id`, `Estado`).
  - `interfaces/` — `IEntidad`, `IConexion`, `IServicio<T>` genérico, y 21 `I{Entidad}Servicio` (vacíos, extienden `IServicio<{Entidad}>`).
  - `implementaciones/` — `Conexion` (DbContext + IConexion), `ConfiguracionBD` (string conexión central), `ServicioBase<T>` (CRUD genérico + soft delete), 21 `{Entidad}Servicio` slim (heredan `ServicioBase`).

- **servicios_aplicaciones** — Web API ASP.NET. 21 controllers REST (`/{Entidad}/{Accion}`). DI scoped de `IConexion` + 21 servicios. Connection string en `appsettings.json` (key `Sql`).

- **cns_presentacion** — Consola legacy. Será reemplazado por frontend React.

- **test_aplicaciones** — Pruebas de integración MSTest. Una clase por servicio. Ejecutan en paralelo (`ExecutionScope.MethodLevel`). Init: `new Conexion()` toma string desde `ConfiguracionBD`.

- **referencia/** — `monolito.cs` con modelo de datos completo. No compila; guía para entidades y SQL.

## Convenciones

- Cada entidad: interfaz `I{Entidad}Servicio` (vacía, extiende `IServicio<{Entidad}>`), implementación `{Entidad}Servicio : ServicioBase<{Entidad}>`, pruebas `{Entidad}ServicioUT`, controller `{Entidad}Controller`.
- CRUD genérico vive en `ServicioBase<T>` — `Listar`, `ObtenerPorId`, `Insertar`, `Actualizar`, `Eliminar` con soft delete (`Estado = 99`). Métodos `virtual` para override.
- Implementaciones slim quedan vacías hasta que aparezca lógica específica. Punto de extensión: agregar método nuevo o `override` para validación/auditoría/reglas.
- `Conexion` implementa `DbContext` + `IConexion`. `NoTracking` por defecto. Ctor parameterless usa `ConfiguracionBD.StringConexion`; ctor `(string cadena)` para overrides puntuales.
- FK navegación con `[ForeignKey]`; colecciones inversas marcadas `[NotMapped]`.
- API Insomnia: export en `insomnia_tracking_habitos.json` (raíz). 21 carpetas, 105 requests. Variable `base_url`.

## Lógica futura prevista por entidad

Casos donde llenar cuerpo de servicios:

| Entidad | Lógica probable |
|---|---|
| Usuarios | hash clave (BCrypt), validar email único, login, recuperar password |
| Habitos | validar pertenencia usuario, recalcular XP, filtrar por usuario activo |
| RegistroProgresos | cascada: actualizar Racha + xpTotal usuario + EstadisticasUsuarios al insertar |
| Desafios | validar fechas (Fin > Inicio), recalcular ranking, cerrar al vencer |
| Rachas | reset `ConteoActual = 0` si pasó > 1 día sin registro; actualizar `MaximaHistorica` |
| EstadisticasUsuarios | agregaciones mensuales automáticas, no permitir duplicado (Usuario, Mes, Año) |
| Notas | validar dueño del `RegistroProgreso`, respetar `EsPrivada` en queries |
| Grupos | validar admin existe y está activo; cascada al desactivar |
| UsuariosGrupos | validar no duplicar (Usuario, Grupo); roles permitidos |
| ParticipacionDesafios | recalcular `RankingPosicion` al cambiar `ProgresoActual` |
| HistorialesDesbloqueo | validar nivel suficiente antes de desbloquear |
| UsuariosLogros | otorgar XP automático al insertar; validar requisito cumplido |
| Recordatorios | validar formato hora; cron/scheduler externo |
| MetricasGlobales | job programado nocturno; cálculos agregados |

Catálogos puros (probablemente sin lógica adicional): **Niveles, Categorias, Frecuencias, Logros, Configuraciones, Recompensas, HabitosPlantilla**.

## Auditoría (planeado)

Todas las tablas tendrán auditoría para trazabilidad de acciones de usuario, inserts/updates/deletes y logs de sistema.

**Diseño previsto**:
- Tabla `Auditorias` global con columnas: `Id`, `Tabla` (string), `RegistroId` (int), `Accion` (Insert/Update/Delete/Login/...), `Usuario` (FK Usuarios), `FechaAccion`, `ValoresAnteriores` (JSON/nvarchar(max)), `ValoresNuevos` (JSON), `IP`, `Estado`.
- Implementación centralizada en `ServicioBase<T>`: override `Insertar`/`Actualizar`/`Eliminar` para registrar entrada de auditoría antes de `SaveChanges`. Captura `Usuario` actual desde contexto de request (claim JWT o header).
- Alternativa EF Core: interceptor (`SaveChangesInterceptor`) que detecta cambios en `ChangeTracker` y los persiste automático sin tocar cada servicio. Preferible — desacopla auditoría de lógica de negocio.
- Tabla aparte `LogsSistema` para errores/eventos no ligados a entidad (login fallido, excepciones, jobs).
- Agregar a todas las entidades: `FechaCreacion`, `FechaModificacion`, `UsuarioCreador`, `UsuarioModificador` (o mantenerlas solo en `Auditorias` para no inflar tablas — decidir cuando se implemente).

**Cuando se implemente**: requiere primero auth (JWT) para identificar usuario; sin auth la columna `Usuario` queda nula y la auditoría pierde valor.
