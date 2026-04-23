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

SQL Server en `localhost:1433` (sa / TuPassword123!). El esquema está definido en `tracking_habitos.sql`. Tablas: Niveles, Categorias, Frecuencias, Logros, Configuraciones, Recompensas. Las pruebas se conectan a esta misma base de datos (pruebas de integración, sin mocks).

## Arquitectura

Solución de tres proyectos con patrón por capas:

- **lib_aplicaciones** — Biblioteca de clases. Capa central que contiene:
  - `entidades/` — Clases de entidad EF Core mapeadas a las tablas SQL (ej. `Niveles`, `Categorias`, `Recompensas`)
  - `interfaces/` — Contratos de servicios (`I{Entidad}Servicio`) y contrato del contexto de BD (`IConexion`)
  - `implementaciones/` — Implementaciones de servicios con operaciones CRUD (`Listar`, `ObtenerPorId`, `Insertar`, `Actualizar`, `Eliminar`) y `Conexion` (DbContext)

- **cns_presentacion** — Aplicación de consola. Punto de entrada (`Program.cs`) que instancia `Conexion`, conecta todos los servicios e imprime datos. Depende de lib_aplicaciones.

- **test_aplicaciones** — Pruebas de integración con MSTest. Una clase de pruebas por servicio (`{Entidad}ServicioUT`). Se ejecutan en paralelo (`ExecutionScope.MethodLevel`). Cada clase crea su propia instancia de `Conexion` en `[TestInitialize]`.

- **referencia/** — Archivo de referencia (`monolito.cs`) con el modelo de datos completo y datos de demo. No se compila; se usa como guía para construir entidades y scripts SQL.

## Convenciones

- Cada entidad de dominio tiene su interfaz (`I{Entidad}Servicio`), implementación (`{Entidad}Servicio`) y clase de pruebas (`{Entidad}ServicioUT`)
- Todas las interfaces de servicio exponen los mismos 5 métodos CRUD: `Listar`, `ObtenerPorId`, `Insertar`, `Actualizar`, `Eliminar`
- `Conexion` implementa tanto `DbContext` como `IConexion`; usa `NoTracking` por defecto
- La cadena de conexión está hardcodeada en `Program.cs` y en el `TestInitialize` de cada prueba
- Las propiedades de navegación FK usan el atributo `[ForeignKey]`; algunas están marcadas como `[NotMapped]` (ej. `Niveles.Recompensas`)
