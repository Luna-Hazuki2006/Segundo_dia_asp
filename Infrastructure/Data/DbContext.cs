using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Infrastructure.Data.Configuracion;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        // public DbSet<Personaje> Personajes {get; set;}
        // public DbSet<Mision> Misiones {get; set;}
        // public DbSet<Tienda> Tiendas {get; set;}
        // public DbSet<Objeto> Objetos {get; set;}
        // public DbSet<Inventario> Inventarios {get; set;}
        // public DbSet<Enemigo> Enemigos {get; set;}
        // public DbSet<Banco> Bancos {get; set;}
        // public DbSet<Objetivo> Objetivos {get; set;}
        // public DbSet<Recompensa> Recompensas {get; set;}
        // public DbSet<Tipo_Personaje> Tipos_Personajes {get; set;}
        public DbSet<Usuario> Usuarios {get; set;}
        public DbSet<Sesion> Sesiones {get; set;}

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder) {
            // builder.ApplyConfiguration(new PersonajeConfiguracion());
            // builder.ApplyConfiguration(new MisionConfiguracion());
            // builder.ApplyConfiguration(new TiendaConfiguracion());
            // builder.ApplyConfiguration(new ObjetoConfiguracion());
            // builder.ApplyConfiguration(new InventarioConfiguracion());
            // builder.ApplyConfiguration(new EnemigoConfiguracion());
            // builder.ApplyConfiguration(new BancoConfiguracion());
            // builder.ApplyConfiguration(new ObjetivoRepositorio());
            // builder.ApplyConfiguration(new RecompensaRepositorio());
            // builder.ApplyConfiguration(new Tipo_PersonajeRepositorio());
            builder.ApplyConfiguration(new UsuarioConfiguracion());
            builder.ApplyConfiguration(new SesionConfiguracion());
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // => optionsBuilder.UseNpgsql("Host=my_host;Database=my_db;Username=my_user;Password=my_pw");

    }
}