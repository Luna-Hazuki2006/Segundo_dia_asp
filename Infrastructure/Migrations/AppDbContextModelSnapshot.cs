﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Entidades.Sesion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cedula_usuario")
                        .IsRequired()
                        .HasColumnType("character varying(8)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("character varying(225)");

                    b.HasKey("Id");

                    b.HasIndex("Cedula_usuario");

                    b.ToTable("SesionAna", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.Usuario", b =>
                {
                    b.Property<string>("Cedula")
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("character varying(225)");

                    b.Property<string>("Apodo")
                        .HasMaxLength(225)
                        .HasColumnType("character varying(225)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("character varying(225)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("character varying(225)");

                    b.Property<string>("Género")
                        .HasMaxLength(225)
                        .HasColumnType("character varying(225)");

                    b.Property<DateTime>("Nacimiento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("character varying(225)");

                    b.HasKey("Cedula");

                    b.ToTable("UsuarioAna", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.Sesion", b =>
                {
                    b.HasOne("Core.Entidades.Usuario", "Usuario_Actual")
                        .WithMany()
                        .HasForeignKey("Cedula_usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario_Actual");
                });
#pragma warning restore 612, 618
        }
    }
}
