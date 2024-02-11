using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class PersonajeConfiguracion : IEntityTypeConfiguration<Personaje>
    {
        public void Configure(EntityTypeBuilder<Personaje> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Nivel).IsRequired();
            builder.Property(x => x.Salud).IsRequired();
            builder.Property(x => x.Fuerza).IsRequired();
            builder.Property(x => x.Agilidad).IsRequired();
            builder.Property(x => x.Energia).IsRequired();
            builder.Property(x => x.Inteligencia).IsRequired();
            builder.Property(x => x.Inventario).IsRequired();
            builder.Property(x => x.Defensa).IsRequired();
            builder.Property(x => x.Resistencia).IsRequired();
            builder.Property(x => x.Experiencia).IsRequired();
            builder.HasOne(x => x.Inventario).
                WithOne(x => x.Personaje).
                HasForeignKey<Personaje>(x => x.Inventario_Id);
            builder.ToTable("PersonajesAna");
        }
    }
}