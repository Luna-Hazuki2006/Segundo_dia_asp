using Core.Interfaces;
using Core.Interfaces.Repositorios;
using Core.Interfaces.Servicios;
using Core.Servicios;
using Infrastructure.Data;
using Infrastructure.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Services.Services;
using System.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API de juego RPG",
        Description = "Es una ASP.NET Core Web API que tratará sobre un juego RPG " + 
        "en el cual se puede dar jugar como un personaje atacar enemigos, hacer misiones y mucho más :D",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Ana Paula Mendoza Díaz",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddControllers();

builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(IBaseRepositorio<>), typeof(BaseRepositorio<>));
builder.Services.AddScoped(typeof(IPersonajeRepositorio), typeof(PersonajeRepositorio));
builder.Services.AddScoped(typeof(IPersonajeService), typeof(PersonajeServicios));
builder.Services.AddScoped(typeof(ITiendaRepositorio), typeof(TiendaRepositorio));
builder.Services.AddScoped(typeof(ITiendaService), typeof(TiendaServicios));
builder.Services.AddScoped(typeof(IObjetoRepositorio), typeof(ObjetoRepositorio));
builder.Services.AddScoped(typeof(IObjetoService), typeof(ObjetoServicios));
builder.Services.AddScoped(typeof(IMisionRepositorio), typeof(MisionRepositorio));
builder.Services.AddScoped(typeof(IMisionService), typeof(MisionServicios));
builder.Services.AddScoped(typeof(IInventarioRepositorio), typeof(InventarioRepositorio));
builder.Services.AddScoped(typeof(IInventarioService), typeof(InventarioServicios));
builder.Services.AddScoped(typeof(IEnemigoRepositorio), typeof(EnemigoRepositorio));
builder.Services.AddScoped(typeof(IEnemigoService), typeof(EnemigoServicios));
builder.Services.AddScoped(typeof(IBancoRepositorio), typeof(BancoRepositorio));
builder.Services.AddScoped(typeof(IBancoService), typeof(BancoServicios));
builder.Services.AddScoped(typeof(IObjetivoRepositorio), typeof(ObjetivoRepositorio));
builder.Services.AddScoped(typeof(IObjetivoService), typeof(ObjetivoServicios));
builder.Services.AddScoped(typeof(IRecompensaRepositorio), typeof(RecompensaRepositorio));
builder.Services.AddScoped(typeof(IRecompensaService), typeof(RecompensaServicios));
builder.Services.AddScoped(typeof(ITipo_PersonajeRepositorio), typeof(Tipo_PersonajeRepositorio));
builder.Services.AddScoped(typeof(ITipo_PersonajeService), typeof(Tipo_PersonajeServicios));
builder.Services.AddScoped(typeof(IUsuarioRepositorio), typeof(UsuarioRepositorio));
builder.Services.AddScoped(typeof(IUsuarioService), typeof(UsuarioServicios));
builder.Services.AddScoped(typeof(ISesionRepositorio), typeof(SesionRepositorio));
builder.Services.AddScoped(typeof(ISesionService), typeof(SesionServicios));


builder.Services.AddDbContext<AppDbContext>(options => 
                    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.Services.a



app.Run();

// https://github.com/GGimenezG/GracoNETCore.git