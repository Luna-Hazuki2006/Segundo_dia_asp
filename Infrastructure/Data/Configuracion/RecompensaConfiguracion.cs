using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class RecompensaConfiguracion : IEntityTypeConfiguration<Recompensa>
    {
        public void Configure(EntityTypeBuilder<Recompensa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Experiencia).IsRequired();
            builder.Property(x => x.Monedas).IsRequired();
            builder.ToTable("RecompensasAna");

            builder.HasMany(x => x.Objetos).
                WithMany(x => x.Recompensas).
                UsingEntity("Recompensas_ObjetosAna");
        }
    }
}