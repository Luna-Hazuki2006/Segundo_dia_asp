using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class UsuarioConfiguracion : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Cedula);
            builder.Property(x => x.Cedula).HasMaxLength(8);
            builder.Property(x => x.Nombres).HasMaxLength(225).IsRequired();
            builder.Property(x => x.Apellidos).HasMaxLength(225).IsRequired();
            builder.Property(x => x.Apodo).HasMaxLength(225);
            builder.Property(x => x.Correo).HasMaxLength(225).IsRequired();
            builder.Property(x => x.Contraseña).HasMaxLength(225).IsRequired();
            builder.Property(x => x.Nacimiento).IsRequired();
            builder.Property(x => x.Género).HasMaxLength(225);
            builder.ToTable("UsuarioAna");
        }
    }
}