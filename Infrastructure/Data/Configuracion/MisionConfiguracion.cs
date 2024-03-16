using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class MisionConfiguracion : IEntityTypeConfiguration<Mision>
    {
        public void Configure(EntityTypeBuilder<Mision> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Estado).IsRequired();
            builder.ToTable("MisionesAna");

            
        }
    }
}