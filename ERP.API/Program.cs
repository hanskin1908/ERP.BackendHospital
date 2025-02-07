using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ERP.Application.Suscripcions.Interfaces;
using ERP.Application.Autenticacion.Interfaces;
using ERP.Infrastructure.Autenticacion.Repositorios;
using ERP.Application.Menus.Interfaces;
using ERP.Infrastructure.Menus.Repositorios;
using ERP.Application.Menus.Servicios;
using ERP.Infrastructure.Suscripcions.Repositorios;
using ERP.Application.Suscripcions.Servicios;
using ERP.Application.Autenticacion.Servicios;
using System;
using ERP.Application.Citas.Interfaces;
using ERP.Application.Citas.Servicios;
using ERP.Infrastructure.Citas.Repositorios;
using ERP.Application.Facturacion.Interfaces;
using ERP.Application.Facturacion.Servicios;
using ERP.Application.HCE.Interfaces;
using ERP.Application.HCE.Servicios;

using ERP.Infrastructure.HCE.Repositorios;
using ERP.Infrastructure.Facturacion.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor

// Configuraci�n de la conexi�n a la base de datos
builder.Services.AddDbContext<ContextoDatos>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuraci�n de la autenticaci�n JWT
var claveSecreta = builder.Configuration["Jwt:ClaveSecreta"];
var key = Encoding.UTF8.GetBytes(claveSecreta);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

// Agregar servicios para controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar dependencias de aplicaci�n y repositorios
builder.Services.AddScoped<IAutenticacionServicio, AutenticacionServicio>();
builder.Services.AddScoped<IAutenticacionRepositorio, AutenticacionRepositorio>();

builder.Services.AddScoped<IMenuServicio, MenuServicio>();
builder.Services.AddScoped<IMenuRepositorio, MenuRepositorio>();

builder.Services.AddScoped<ISuscripcionServicio, SuscripcionServicio>();
builder.Services.AddScoped<ISuscripcionRepositorio, SuscripcionRepositorio>();
builder.Services.AddScoped<ERP.Application.Autenticacion.Interfaces.IUsuarioServicio, ERP.Application.Autenticacion.Servicios.UsuarioServicio>();
builder.Services.AddScoped<ERP.Application.Autenticacion.Interfaces.IUsuarioRepositorio, ERP.Infrastructure.Autenticacion.Repositorios.UsuarioRepositorio>();

builder.Services.AddScoped<ERP.Application.Autenticacion.Interfaces.IRolServicio, ERP.Application.Autenticacion.Servicios.RolServicio>();
builder.Services.AddScoped<ERP.Application.Autenticacion.Interfaces.IRolRepositorio, ERP.Infrastructure.Autenticacion.Repositorios.RolRepositorio>();

builder.Services.AddScoped<ERP.Application.Pacientes.Interfaces.IPacienteServicio, ERP.Application.Pacientes.Servicios.PacienteServicio>();
builder.Services.AddScoped<ERP.Application.Pacientes.Interfaces.IPacienteRepositorio, ERP.Infrastructure.Pacientes.Repositorios.PacienteRepositorio>();
// Registrar otras dependencias seg�n se vayan agregando (Pacientes, Citas, Facturaci�n, etc.)
builder.Services.AddScoped<ISuscripcionRepositorio, SuscripcionRepositorio>();
builder.Services.AddScoped<ISuscripcionServicio, SuscripcionServicio>();

builder.Services.AddScoped<ICitaRepositorio, CitaRepositorio>();
builder.Services.AddScoped<ICitaServicio, CitaServicio>();

builder.Services.AddScoped<IHistoriaClinicaRepositorio, HistoriaClinicaRepositorio>();
builder.Services.AddScoped<IHistoriaClinicaServicio, HistoriaClinicaServicio>();

// Para Facturaci�n
builder.Services.AddScoped<IFacturaRepositorio, FacturaRepositorio>();
builder.Services.AddScoped<IFacturacionServicio, FacturacionServicio>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocal",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});
var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Ejecutar SeedData al iniciar la aplicaci�n
using (var scope = app.Services.CreateScope())
{
    var servicios = scope.ServiceProvider;
    try
    {
        var contexto = servicios.GetRequiredService<ContextoDatos>();
        await SeedData.Inicializar(contexto);
    }
    catch (Exception ex)
    {
        var logger = servicios.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Error al sembrar datos iniciales.");
    }
}
// Configurar el pipeline de HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowLocal");

app.MapControllers();

app.Run();
