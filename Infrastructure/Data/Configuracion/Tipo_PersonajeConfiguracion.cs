using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class Tipo_PersonajeConfiguracion : IEntityTypeConfiguration<Tipo_Personaje>
    {
        public void Configure(EntityTypeBuilder<Tipo_Personaje> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(225);
            builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(225);
            builder.ToTable("Tipos_PersonajesAna");
        }
    }
}