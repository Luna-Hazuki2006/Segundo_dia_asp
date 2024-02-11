using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class RecompensaRepositorio : IEntityTypeConfiguration<Recompensa>
    {
        public void Configure(EntityTypeBuilder<Recompensa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Objetos).IsRequired();
            builder.Property(x => x.Experiencia).IsRequired();
            builder.Property(x => x.Enemigos).IsRequired();
            builder.Property(x => x.Monedas).IsRequired();
            builder.ToTable("RecompensasAna");
        }
    }
}