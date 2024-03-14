using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class SesionConfiguracion : IEntityTypeConfiguration<Sesion>
    {
        public void Configure(EntityTypeBuilder<Sesion> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Cedula_usuario).IsRequired();
            builder.Property(x => x.Token).HasMaxLength(225).IsRequired();
            builder.ToTable("SesionAna");

            builder.HasOne(x => x.Usuario_Actual)
                .WithMany()
                .HasForeignKey(x => x.Cedula_usuario);
        }
    }
}