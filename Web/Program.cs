using Core.Interfaces;
using Core.Interfaces.Repositorios;
using Core.Servicios;
using Infrastructure.Data;
using Infrastructure.Repositorios;
using Microsoft.EntityFrameworkCore;
using Services.Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

/*builder.Services.AddDbContext<AppDbContext>(options => 
                    options.UseNpgsql("Host=dpg-clupqhmg1b2c73cacl4g-a;Server=dpg-clupqhmg1b2c73cacl4g-a.oregon-postgres.render.com;Port=5432;Database=gracoapidb;Username=graco;Password=d16mVIlilx3OFVzXgb0AW5VYnTOv0pMT"
                     ,b => b.MigrationsAssembly("Infrastructure")
                )
                    
            );*/
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