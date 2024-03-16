using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class InventarioConfiguracion : IEntityTypeConfiguration<Inventario>
    {
        public void Configure(EntityTypeBuilder<Inventario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Espacio_Disponible).IsRequired();
            builder.Property(x => x.Objetos).IsRequired();
            builder.Property(x => x.Peso_Total).IsRequired();
            builder.ToTable("InventariosAna");

            builder.HasMany(x => x.Objetos).
                WithMany(x => x.Inventarios).
                UsingEntity("Inventarios_ObjetosAna");
        }
    }
}