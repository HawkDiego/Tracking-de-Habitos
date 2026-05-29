using System.Text;
using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using servicios_aplicaciones.Auth;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
    {
        policy.WithOrigins("https://localhost:7125", "http://localhost:7125")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddScoped<AuditoriaFilter>();
builder.Services.AddControllers(opt => opt.Filters.AddService<AuditoriaFilter>());
builder.Services.AddOpenApi();
builder.Services.AddSingleton<JwtHelper>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddScoped<IConexion>(_ => new Conexion
{
    StringConexion = builder.Configuration.GetConnectionString("Sql")
});

builder.Services.AddScoped<INivelesServicio, NivelesServicio>();
builder.Services.AddScoped<ICategoriasServicio, CategoriasServicio>();
builder.Services.AddScoped<IFrecuenciasServicio, FrecuenciasServicio>();
builder.Services.AddScoped<ILogrosServicio, LogrosServicio>();
builder.Services.AddScoped<IConfiguracionesServicio, ConfiguracionesServicio>();
builder.Services.AddScoped<IRecompensasServicio, RecompensasServicio>();
builder.Services.AddScoped<IUsuariosServicio, UsuariosServicio>();
builder.Services.AddScoped<IHabitosPlantillaServicio, HabitosPlantillaServicio>();
builder.Services.AddScoped<IHabitosServicio, HabitosServicio>();
builder.Services.AddScoped<IGruposServicio, GruposServicio>();
builder.Services.AddScoped<IUsuariosLogrosServicio, UsuariosLogrosServicio>();
builder.Services.AddScoped<IRegistroProgresosServicio, RegistroProgresosServicio>();
builder.Services.AddScoped<IRecordatoriosServicio, RecordatoriosServicio>();
builder.Services.AddScoped<IRachasServicio, RachasServicio>();
builder.Services.AddScoped<IHistorialesDesbloqueoServicio, HistorialesDesbloqueoServicio>();
builder.Services.AddScoped<IEstadisticasUsuariosServicio, EstadisticasUsuariosServicio>();
builder.Services.AddScoped<IMetricasGlobalesServicio, MetricasGlobalesServicio>();
builder.Services.AddScoped<IUsuariosGruposServicio, UsuariosGruposServicio>();
builder.Services.AddScoped<IDesafiosServicio, DesafiosServicio>();
builder.Services.AddScoped<INotasServicio, NotasServicio>();
builder.Services.AddScoped<IParticipacionDesafiosServicio, ParticipacionDesafiosServicio>();
builder.Services.AddScoped<IAuditoriasServicio, AuditoriasServicio>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("FrontendPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers().RequireAuthorization();
app.Run();