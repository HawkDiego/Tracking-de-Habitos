CREATE DATABASE tracking_habitos;
GO
USE tracking_habitos;
GO

CREATE TABLE [Niveles] (
                           [Id] INT NOT NULL IDENTITY(1, 1),
                           [Nombre] NVARCHAR(100) NOT NULL,
                           [LimiteInferiorXp] INT NOT NULL,
                           [LimiteSuperiorXp] INT NOT NULL,
                           [Descripcion] NVARCHAR(300) NOT NULL,

                           CONSTRAINT PK_Niveles PRIMARY KEY (id)
);


INSERT INTO Niveles (Nombre, LimiteInferiorXp, LimiteSuperiorXp, Descripcion)
VALUES
    ('Inicial',       0,   99,  'Primer nivel'),
    ('Constante',     100, 199, 'Mantiene hábitos'),
    ('Comprometido',  200, 299, 'Ya tiene disciplina'),
    ('Avanzado',      300, 399, 'Rendimiento alto'),
    ('Elite',         400, 499, 'Referencia para otros');

SELECT * FROM Niveles;

CREATE TABLE [Categorias] (
                              [Id] INT NOT NULL IDENTITY(1, 1),
                              [Nombre] NVARCHAR(100) NOT NULL,
                              [Color] NVARCHAR(7),
                              [Icono] NVARCHAR(10),
                              [Descripcion] NVARCHAR(300),

                              CONSTRAINT PK_Categorias PRIMARY KEY (id)

);

INSERT INTO Categorias (Nombre, Color, Icono, Descripcion)
VALUES
    ('Salud',         '#22C55E', N'💪', 'Hábitos para bienestar físico'),
    ('Estudio',       '#3B82F6', N'📚', 'Aprendizaje y lectura'),
    ('Productividad', '#8B5CF6', N'🧠', 'Organización y enfoque'),
    ('Finanzas',      '#F59E0B', N'💰', 'Control de gastos y ahorro'),
    ('Bienestar',     '#EC4899', N'🧘', 'Descanso y salud mental');

SELECT * FROM Categorias;

CREATE TABLE [Frecuencias] (
                               [Id]             INT          NOT NULL IDENTITY(1,1),
                               [TipoIntervalo]  NVARCHAR(50) NOT NULL,
                               [DiasSemana]     NVARCHAR(100)    NULL,
                               [VecesPorDia]    INT          NOT NULL,
                               [esPersonalizada] BIT         NOT NULL,
                               CONSTRAINT PK_Frecuencias PRIMARY KEY ([Id])
);

INSERT INTO [Frecuencias] ([TipoIntervalo], [DiasSemana], [VecesPorDia], [esPersonalizada]) VALUES
                                                                                                ('diario',       NULL,                        1, 0),
                                                                                                ('semanal',      'lunes,miercoles,viernes',   1, 0),
                                                                                                ('semanal',      'lunes,martes,miercoles,jueves,viernes', 1, 0),
                                                                                                ('mensual',      NULL,                        1, 0),
                                                                                                ('personalizado','sabado,domingo',            1, 1),
                                                                                                ('diario',       NULL,                        2, 0);

SELECT * FROM Frecuencias;

CREATE TABLE [Logros] (
                          [Id] INT NOT NULL IDENTITY(1, 1),
                          [Titulo] NVARCHAR(100) NOT NULL,
                          [DescripcionRequisito] NVARCHAR(500) NULL,
                          [XpOtorgada] INT NOT NULL,
                          [ImagenUrl] NVARCHAR(300) NULL,
                          CONSTRAINT PK_Logros PRIMARY KEY (id)
);

SELECT * FROM Logros;

INSERT INTO [Logros] ([Titulo], [DescripcionRequisito], [XpOtorgada], [ImagenUrl]) VALUES
                                                                                       ('Primer Paso',        'Completa tu primer hábito',                  50,  NULL),
                                                                                       ('Racha de 7 días',    'Mantén un hábito por 7 días consecutivos',   100, NULL),
                                                                                       ('Racha de 30 días',   'Mantén un hábito por 30 días consecutivos',  300, NULL),
                                                                                       ('Constante',          'Completa 10 hábitos en total',               75,  NULL),
                                                                                       ('Dedicado',           'Completa 50 hábitos en total',               200, NULL),
                                                                                       ('Explorador',         'Crea hábitos en 3 categorías distintas',     150, NULL),
                                                                                       ('Nivel 5',            'Alcanza el nivel 5',                         250, NULL),
                                                                                       ('Madrugador',         'Registra un hábito antes de las 7am',        80,  NULL);   

CREATE TABLE [Configuraciones] (
                                   [Id]             INT           NOT NULL IDENTITY(1,1),
                                   [Tema]           NVARCHAR(20)  NULL,
                                   [Idioma]         NVARCHAR(10)  NULL,
                                   [ZonaHoraria]    NVARCHAR(100) NULL,
                                   [Notificaciones] BIT           NOT NULL,
                                   [SonidoAlerta]   BIT           NOT NULL,

                                   CONSTRAINT PK_Configuraciones PRIMARY KEY ([Id])
);


INSERT INTO [Configuraciones] ([Tema], [Idioma], [ZonaHoraria], [Notificaciones], [SonidoAlerta])
VALUES
    ('claro',  'es', 'America/Bogota',      1, 1),
    ('oscuro', 'es', 'America/Bogota',      1, 0),
    ('oscuro', 'en', 'America/Mexico_City', 1, 1),
    ('claro',  'es', 'America/Lima',        0, 0),
    ('oscuro', 'es', 'America/Santiago',    1, 1);

SELECT * FROM Configuraciones;

CREATE TABLE [Recompensas] (
                               [Id]             INT           NOT NULL IDENTITY(1,1),
                               [Nombre]         NVARCHAR(100) NOT NULL,
                               [Descripcion]    NVARCHAR(300) NULL,
                               [NivelRequerido] INT           NULL,
                               [EsEstetica]     BIT           NOT NULL,

                               CONSTRAINT PK_Recompensas          PRIMARY KEY ([Id]),
                               CONSTRAINT FK_Recompensas_Niveles   FOREIGN KEY ([NivelRequerido]) REFERENCES [Niveles]([Id])
);

INSERT INTO [Recompensas] ([Nombre], [Descripcion], [NivelRequerido], [EsEstetica])
VALUES
    ('Tema Verde',         'Tema visual de naturaleza',         1, 1),
    ('Insignia Constancia','Insignia visible en perfil',        2, 1),
    ('Reporte Semanal',    'Resumen automático de progreso',    3, 0),
    ('Plantillas Pro',     'Acceso a plantillas avanzadas',     4, 0),
    ('Marco Elite',        'Marco especial de perfil',          5, 1);

SELECT * FROM Recompensas;


CREATE TABLE [Usuarios] (
                            [Id]             INT           NOT NULL IDENTITY(1,1),
                            [Nombre]         NVARCHAR(100) NOT NULL,
                            [Email]          NVARCHAR(200) NOT NULL,
                            [Clave]          NVARCHAR(200) NOT NULL,
                            [FechaRegistro]  DATETIME      NOT NULL,
                            [xpTotal]        INT               NULL,
                            [Nivel]          INT               NULL,
                            [Configuracion]  INT               NULL,

                            CONSTRAINT PK_Usuarios              PRIMARY KEY ([Id]),
                            CONSTRAINT FK_Usuarios_Niveles       FOREIGN KEY ([Nivel])         REFERENCES [Niveles]([Id]),
                            CONSTRAINT FK_Usuarios_Configuraciones FOREIGN KEY ([Configuracion]) REFERENCES [Configuraciones]([Id])
);

INSERT INTO [Usuarios] ([Nombre], [Email], [Clave], [FechaRegistro], [xpTotal], [Nivel], [Configuracion])
VALUES
    ('Ana Torres',     'ana.torres@habitapp.com',     'ClaveAna#2026',    '2025-09-22', 95,  1, 1),
    ('Carlos Ruiz',    'carlos.ruiz@habitapp.com',    'ClaveCarlos#2026', '2025-07-22', 178, 2, 2),
    ('Laura Gómez',    'laura.gomez@habitapp.com',    'ClaveLaura#2026',  '2025-11-22', 242, 3, 3),
    ('Diego Pardo',    'diego.pardo@habitapp.com',    'ClaveDiego#2026',  '2025-05-22', 336, 4, 4),
    ('Sofía Herrera',  'sofia.herrera@habitapp.com',  'ClaveSofia#2026',  '2025-03-22', 415, 5, 5);

SELECT * FROM Usuarios;

CREATE TABLE [HabitosPlantilla] (
                                    [Id]            INT           NOT NULL IDENTITY(1,1),
                                    [Nombre]        NVARCHAR(100) NOT NULL,
                                    [Descripcion]   NVARCHAR(300)     NULL,
                                    [FechaCreacion] DATETIME      NOT NULL,
                                    [Activo]        BIT           NOT NULL,
                                    [XpOtorgada]    INT               NULL,
                                    [Categoria]     INT               NULL,
                                    [Frecuencia]    INT               NULL,
                                    [EsOficial]     BIT           NOT NULL,

                                    CONSTRAINT PK_HabitosPlantilla              PRIMARY KEY ([Id]),
                                    CONSTRAINT FK_HabitosPlantilla_Categorias   FOREIGN KEY ([Categoria])  REFERENCES [Categorias]([Id]),
                                    CONSTRAINT FK_HabitosPlantilla_Frecuencias  FOREIGN KEY ([Frecuencia]) REFERENCES [Frecuencias]([Id])
);

INSERT INTO [HabitosPlantilla] ([Nombre], [Descripcion], [FechaCreacion], [Activo], [XpOtorgada], [Categoria], [Frecuencia], [EsOficial])
VALUES
    ('Caminar 30 minutos',  'Actividad física ligera diaria',       '2024-09-22', 1, 20, 1, NULL, 1),
    ('Leer 20 páginas',     'Lectura constante para aprendizaje',   '2024-12-22', 1, 25, 2, NULL, 1),
    ('Plan diario',         'Planificar tareas clave del día',      '2025-03-22', 1, 18, 3, NULL, 1),
    ('Registrar gastos',    'Anotar gastos del día',                '2025-06-22', 1, 15, 4, NULL, 0),
    ('Meditar 10 minutos',  'Pausa de respiración consciente',      '2025-09-22', 1, 22, 5, NULL, 1);

SELECT * FROM HabitosPlantilla;

CREATE TABLE [Habitos] (
                           [Id]            INT           NOT NULL IDENTITY(1,1),
                           [Usuario]       INT           NOT NULL,
                           [Nombre]        NVARCHAR(100) NOT NULL,
                           [Descripcion]   NVARCHAR(300)     NULL,
                           [FechaCreacion] DATETIME      NOT NULL,
                           [Activo]        BIT           NOT NULL,
                           [XpOtorgada]    INT               NULL,
                           [Categoria]     INT               NULL,
                           [Frecuencia]    INT               NULL,

                           CONSTRAINT PK_Habitos              PRIMARY KEY ([Id]),
                           CONSTRAINT FK_Habitos_Usuarios     FOREIGN KEY ([Usuario])   REFERENCES [Usuarios]([Id]),
                           CONSTRAINT FK_Habitos_Categorias   FOREIGN KEY ([Categoria]) REFERENCES [Categorias]([Id]),
                           CONSTRAINT FK_Habitos_Frecuencias  FOREIGN KEY ([Frecuencia]) REFERENCES [Frecuencias]([Id])
);

INSERT INTO [Habitos] ([Usuario], [Nombre], [Descripcion], [FechaCreacion], [Activo], [XpOtorgada], [Categoria], [Frecuencia])
VALUES
    (1, 'Caminar temprano',    'Caminar antes de iniciar labores',       '2025-10-22', 1, 20, 1, 1),
    (1, 'Lectura técnica',     'Leer documentación 25 minutos',         '2025-11-22', 1, 25, 2, 2),
    (2, 'Bloques de foco',     'Dos sesiones de enfoque profundo',      '2025-12-22', 1, 30, 3, 3),
    (3, 'Control de gastos',   'Registrar gastos del día',              '2026-01-22', 1, 15, 4, 4),
    (4, 'Meditación nocturna', 'Meditar antes de dormir',               '2026-02-22', 1, 22, 5, 5);

SELECT * FROM Habitos;

CREATE TABLE [Grupos] (
                          [Id]             INT           NOT NULL IDENTITY(1,1),
                          [Nombre]         NVARCHAR(100) NOT NULL,
                          [Descripcion]    NVARCHAR(300)     NULL,
                          [Administrador]  INT           NOT NULL,

                          CONSTRAINT PK_Grupos              PRIMARY KEY ([Id]),
                          CONSTRAINT FK_Grupos_Usuarios     FOREIGN KEY ([Administrador]) REFERENCES [Usuarios]([Id])
);

INSERT INTO [Grupos] ([Nombre], [Descripcion], [Administrador])
VALUES
    ('Mañanas Activas',       'Grupo para rutinas matutinas',       1),
    ('Lectura Técnica',       'Compartir avances de estudio',       2),
    ('Foco y Productividad',  'Bloques de enfoque diario',          3),
    ('Finanzas Personales',   'Hábitos de control financiero',      4),
    ('Bienestar Nocturno',    'Rutinas de descanso y calma',        5);

SELECT * FROM Grupos;

CREATE TABLE [UsuariosLogros] (
                                  [Id]              INT      NOT NULL IDENTITY(1,1),
                                  [Usuario]         INT      NOT NULL,
                                  [Logro]           INT      NOT NULL,
                                  [FechaObtencion]  DATETIME NOT NULL,

                                  CONSTRAINT PK_UsuariosLogros           PRIMARY KEY ([Id]),
                                  CONSTRAINT FK_UsuariosLogros_Usuarios  FOREIGN KEY ([Usuario]) REFERENCES [Usuarios]([Id]),
                                  CONSTRAINT FK_UsuariosLogros_Logros    FOREIGN KEY ([Logro])   REFERENCES [Logros]([Id])
);

INSERT INTO [UsuariosLogros] ([Usuario], [Logro], [FechaObtencion])
VALUES
    (1, 1, '2026-02-10'),
    (2, 2, '2026-02-25'),
    (3, 3, '2026-03-02'),
    (4, 4, '2026-03-12'),
    (5, 5, '2026-03-17');

SELECT * FROM UsuariosLogros;


CREATE TABLE [RegistroProgresos] (
                                     [Id]         INT      NOT NULL IDENTITY(1,1),
                                     [Habito]     INT      NOT NULL,
                                     [FechaLogro] DATETIME NOT NULL,
                                     [Completado] BIT      NOT NULL,
                                     [XpGanada]   INT      NOT NULL,

                                     CONSTRAINT PK_RegistroProgresos            PRIMARY KEY ([Id]),
                                     CONSTRAINT FK_RegistroProgresos_Habitos    FOREIGN KEY ([Habito]) REFERENCES [Habitos]([Id])
);

INSERT INTO [RegistroProgresos] ([Habito], [FechaLogro], [Completado], [XpGanada])
VALUES
    (1, '2026-03-21', 1, 22),
    (2, '2026-03-20', 1, 25),
    (3, '2026-03-21', 1, 39),
    (4, '2026-03-19', 0, 0),
    (5, '2026-03-21', 1, 26);

SELECT * FROM RegistroProgresos;

CREATE TABLE [Recordatorios] (
                                 [Id]            INT           NOT NULL IDENTITY(1,1),
                                 [Habito]        INT           NOT NULL,
                                 [HoraEjecucion] NVARCHAR(10)  NOT NULL,
                                 [Mensaje]       NVARCHAR(300)     NULL,
                                 [Activo]        BIT           NOT NULL,

                                 CONSTRAINT PK_Recordatorios           PRIMARY KEY ([Id]),
                                 CONSTRAINT FK_Recordatorios_Habitos   FOREIGN KEY ([Habito]) REFERENCES [Habitos]([Id])
);

INSERT INTO [Recordatorios] ([Habito], [HoraEjecucion], [Mensaje], [Activo])
VALUES
    (1, '06:30', 'Hora de caminar 30 minutos',    1),
    (2, '20:00', 'Momento de lectura técnica',     1),
    (3, '09:00', 'Inicia primer bloque de foco',   1),
    (4, '21:00', 'Registra los gastos del día',    1),
    (5, '22:30', 'Respira y medita 10 minutos',    1);

SELECT * FROM Recordatorios;

CREATE TABLE [Rachas] (
                          [Id]                    INT           NOT NULL IDENTITY(1,1),
                          [Habito]                INT           NOT NULL,
                          [ConteoActual]          INT               NULL,
                          [MaximaHistorica]       INT               NULL,
                          [FechaUltimoIncremento] DATETIME          NULL,
                          [MultiplicadorXp]       DECIMAL(5,2)      NULL,

                          CONSTRAINT PK_Rachas           PRIMARY KEY ([Id]),
                          CONSTRAINT FK_Rachas_Habitos   FOREIGN KEY ([Habito]) REFERENCES [Habitos]([Id])
);

INSERT INTO [Rachas] ([Habito], [ConteoActual], [MaximaHistorica], [FechaUltimoIncremento], [MultiplicadorXp])
VALUES
    (1, 6,  9,  '2026-03-21', 1.10),
    (2, 3,  7,  '2026-03-20', 1.00),
    (3, 12, 15, '2026-03-21', 1.30),
    (4, 2,  5,  '2026-03-19', 1.00),
    (5, 8,  11, '2026-03-21', 1.20);

SELECT * FROM Rachas;

CREATE TABLE [HistorialesDesbloqueo] (
                                         [Id]              INT      NOT NULL IDENTITY(1,1),
                                         [Usuario]         INT      NOT NULL,
                                         [Recompensa]      INT      NOT NULL,
                                         [FechaObtencion]  DATETIME NOT NULL,

                                         CONSTRAINT PK_HistorialesDesbloqueo              PRIMARY KEY ([Id]),
                                         CONSTRAINT FK_HistorialesDesbloqueo_Usuarios     FOREIGN KEY ([Usuario])    REFERENCES [Usuarios]([Id]),
                                         CONSTRAINT FK_HistorialesDesbloqueo_Recompensas  FOREIGN KEY ([Recompensa]) REFERENCES [Recompensas]([Id])
);

INSERT INTO [HistorialesDesbloqueo] ([Usuario], [Recompensa], [FechaObtencion])
VALUES
    (1, 1, '2026-01-31'),
    (2, 2, '2026-02-15'),
    (3, 3, '2026-03-02'),
    (4, 4, '2026-03-10'),
    (5, 5, '2026-03-17');

SELECT * FROM HistorialesDesbloqueo;

CREATE TABLE [EstadisticasUsuarios] (
                                        [Id]                  INT      NOT NULL IDENTITY(1,1),
                                        [Usuario]             INT      NOT NULL,
                                        [Mes]                 INT      NOT NULL,
                                        [Anio]                INT      NOT NULL,
                                        [HabitosCompletados]  INT      NOT NULL,
                                        [XpGanadaMes]         INT      NOT NULL,
                                        [MejorRacha]          INT      NOT NULL,
                                        [TotalNotas]          INT      NOT NULL,
                                        [FechaCalculo]        DATETIME NOT NULL,

                                        CONSTRAINT PK_EstadisticasUsuarios            PRIMARY KEY ([Id]),
                                        CONSTRAINT FK_EstadisticasUsuarios_Usuarios   FOREIGN KEY ([Usuario]) REFERENCES [Usuarios]([Id])
);

INSERT INTO [EstadisticasUsuarios] ([Usuario], [Mes], [Anio], [HabitosCompletados], [XpGanadaMes], [MejorRacha], [TotalNotas], [FechaCalculo])
VALUES
    (1, 3, 2026, 18, 95,  6,  4,  '2026-03-22'),
    (2, 3, 2026, 26, 178, 12, 6,  '2026-03-22'),
    (3, 3, 2026, 31, 242, 9,  7,  '2026-03-22'),
    (4, 3, 2026, 40, 336, 14, 9,  '2026-03-22'),
    (5, 3, 2026, 52, 415, 21, 11, '2026-03-22');

SELECT * FROM EstadisticasUsuarios;

CREATE TABLE [MetricasGlobales] (
                                    [Id]                    INT      NOT NULL IDENTITY(1,1),
                                    [TotalUsuariosActivos]  INT      NOT NULL,
                                    [PromedioXpPlataforma]  INT      NOT NULL,
                                    [HabitoMasPopular]      INT      NOT NULL,
                                    [CategoriaMasUsada]     INT      NOT NULL,
                                    [FechaCalculo]          DATETIME NOT NULL,

                                    CONSTRAINT PK_MetricasGlobales                     PRIMARY KEY ([Id]),
                                    CONSTRAINT FK_MetricasGlobales_HabitosPlantilla    FOREIGN KEY ([HabitoMasPopular])  REFERENCES [HabitosPlantilla]([Id]),
                                    CONSTRAINT FK_MetricasGlobales_Categorias          FOREIGN KEY ([CategoriaMasUsada]) REFERENCES [Categorias]([Id])
);

INSERT INTO [MetricasGlobales] ([TotalUsuariosActivos], [PromedioXpPlataforma], [HabitoMasPopular], [CategoriaMasUsada], [FechaCalculo])
VALUES
    (108, 140, 1, 1, '2025-11-22'),
    (117, 155, 2, 2, '2025-12-22'),
    (126, 171, 3, 3, '2026-01-22'),
    (138, 186, 5, 5, '2026-02-22'),
    (145, 198, 1, 1, '2026-03-22');

SELECT * FROM MetricasGlobales;

CREATE TABLE [UsuariosGrupos] (
                                  [Id]         INT          NOT NULL IDENTITY(1,1),
                                  [Grupo]      INT          NOT NULL,
                                  [Usuario]    INT          NOT NULL,
                                  [Rol]        NVARCHAR(50)     NULL,
                                  [FechaUnion] DATETIME     NOT NULL,

                                  CONSTRAINT PK_UsuariosGrupos            PRIMARY KEY ([Id]),
                                  CONSTRAINT FK_UsuariosGrupos_Grupos     FOREIGN KEY ([Grupo])   REFERENCES [Grupos]([Id]),
                                  CONSTRAINT FK_UsuariosGrupos_Usuarios   FOREIGN KEY ([Usuario]) REFERENCES [Usuarios]([Id])
);

INSERT INTO [UsuariosGrupos] ([Grupo], [Usuario], [Rol], [FechaUnion])
VALUES
    (1, 1, 'admin', '2025-10-22'),
    (2, 2, 'admin', '2025-11-22'),
    (3, 3, 'admin', '2025-12-22'),
    (4, 4, 'admin', '2026-01-22'),
    (5, 5, 'admin', '2026-02-22');

SELECT * FROM UsuariosGrupos;

CREATE TABLE [Desafios] (
                            [Id]                  INT           NOT NULL IDENTITY(1,1),
                            [GrupoAdministrador]  INT           NOT NULL,
                            [Nombre]              NVARCHAR(100) NOT NULL,
                            [Descripcion]         NVARCHAR(300)     NULL,
                            [FechaInicio]         DATETIME      NOT NULL,
                            [FechaFin]            DATETIME      NOT NULL,
                            [XpBono]              INT           NOT NULL,

                            CONSTRAINT PK_Desafios           PRIMARY KEY ([Id]),
                            CONSTRAINT FK_Desafios_Grupos    FOREIGN KEY ([GrupoAdministrador]) REFERENCES [Grupos]([Id])
);

INSERT INTO [Desafios] ([GrupoAdministrador], [Nombre], [Descripcion], [FechaInicio], [FechaFin], [XpBono])
VALUES
    (1, '7 días caminando',       'Completar caminata diaria por una semana',  '2026-03-15', '2026-03-23', 60),
    (2, 'Lectura de 100 páginas', 'Acumular 100 páginas en 10 días',          '2026-03-17', '2026-03-27', 80),
    (3, '10 bloques de foco',     'Cumplir 10 sesiones esta semana',           '2026-03-19', '2026-03-26', 90),
    (4, 'Cero gastos hormiga',    'Evitar gastos no planificados',             '2026-03-20', '2026-03-30', 70),
    (5, 'Meditación continua',    'Meditar 10 minutos durante 5 días',         '2026-03-21', '2026-03-28', 75);

SELECT * FROM Desafios;

CREATE TABLE [Notas] (
                         [Id]                 INT           NOT NULL IDENTITY(1,1),
                         [Texto]              NVARCHAR(500)     NULL,
                         [FechaCreacion]      DATETIME      NOT NULL,
                         [EstadoDeAnimoEmoji] NVARCHAR(10)      NULL,
                         [EsPrivada]          BIT           NOT NULL,
                         [RegistroProgreso]   INT               NULL,

                         CONSTRAINT PK_Notas                        PRIMARY KEY ([Id]),
                         CONSTRAINT FK_Notas_RegistroProgresos      FOREIGN KEY ([RegistroProgreso]) REFERENCES [RegistroProgresos]([Id])
);

INSERT INTO [Notas] ([Texto], [FechaCreacion], [EstadoDeAnimoEmoji], [EsPrivada], [RegistroProgreso])
VALUES
    ('Caminata con buen ritmo y sin pausas.',              '2026-03-21', N'😀', 1, 1),
    ('Leí un capítulo completo de arquitectura.',          '2026-03-20', N'📖', 1, 2),
    ('Completé los dos bloques de foco planeados.',        '2026-03-21', N'🚀', 1, 3),
    ('No registré todos los gastos; mejorar mañana.',      '2026-03-19', N'😓', 1, 4),
    ('Meditación corta pero constante.',                   '2026-03-21', N'🧘', 1, 5);

SELECT * FROM Notas;

CREATE TABLE [ParticipacionDesafios] (
                                         [Id]              INT          NOT NULL IDENTITY(1,1),
                                         [Desafio]         INT          NOT NULL,
                                         [UsuariosGrupo]   INT          NOT NULL,
                                         [ProgresoActual]  DECIMAL(5,2) NOT NULL,
                                         [RankingPosicion] INT          NOT NULL,

                                         CONSTRAINT PK_ParticipacionDesafios                    PRIMARY KEY ([Id]),
                                         CONSTRAINT FK_ParticipacionDesafios_Desafios           FOREIGN KEY ([Desafio])       REFERENCES [Desafios]([Id]),
                                         CONSTRAINT FK_ParticipacionDesafios_UsuariosGrupos     FOREIGN KEY ([UsuariosGrupo]) REFERENCES [UsuariosGrupos]([Id])
);

INSERT INTO [ParticipacionDesafios] ([Desafio], [UsuariosGrupo], [ProgresoActual], [RankingPosicion])
VALUES
    (1, 1, 85.00, 1),
    (2, 2, 60.00, 2),
    (3, 3, 90.00, 1),
    (4, 4, 45.00, 3),
    (5, 5, 70.00, 2);

SELECT * FROM ParticipacionDesafios;
