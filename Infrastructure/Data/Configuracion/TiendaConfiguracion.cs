using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class TiendaConfiguracion : IEntityTypeConfiguration<Tienda>
    {
        public void Configure(EntityTypeBuilder<Tienda> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Inventario_Tienda).IsRequired();
            builder.Property(x => x.Precios).IsRequired();
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.Dinero_Tienda).IsRequired();
            builder.ToTable("TiendasAna");

            builder.HasMany(x => x.Inventario_Tienda).
                WithMany(x => x.Tiendas_Encontradas).
                UsingEntity("Tiendas_ObjetosAna");
        }
    }
}