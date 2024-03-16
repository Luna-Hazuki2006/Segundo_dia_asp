using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class EnemigoConfiguracion : IEntityTypeConfiguration<Enemigo>
    {
        public void Configure(EntityTypeBuilder<Enemigo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Nivel_Amenaza).IsRequired();
            builder.Property(x => x.Habilidades).IsRequired();
            builder.Property(x => x.Vida).IsRequired();
            builder.ToTable("EnemigosAna");

            builder.HasMany(x => x.Recompensas).
                WithMany(x => x.Enemigos).
                UsingEntity("Recompensas_EnemigosAna");
        }
    }
}