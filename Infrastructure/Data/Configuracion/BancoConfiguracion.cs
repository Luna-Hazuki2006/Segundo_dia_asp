using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class BancoConfiguracion : IEntityTypeConfiguration<Banco>
    {
        public void Configure(EntityTypeBuilder<Banco> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Cuenta_Bacaria).IsRequired();
            builder.Property(x => x.Intereses).IsRequired();
            builder.Property(x => x.Prestamos).IsRequired();
            builder.Property(x => x.Seguridad).IsRequired();
        }
    }
}