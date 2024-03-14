using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CambioRelacionesPersonaje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioAna",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    Nombres = table.Column<string>(type: "character varying(225)", maxLength: 225, nullable: false),
                    Apellidos = table.Column<string>(type: "character varying(225)", maxLength: 225, nullable: false),
                    Apodo = table.Column<string>(type: "character varying(225)", maxLength: 225, nullable: true),
                    Correo = table.Column<string>(type: "character varying(225)", maxLength: 225, nullable: false),
                    Contraseña = table.Column<string>(type: "character varying(225)", maxLength: 225, nullable: false),
                    Nacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Género = table.Column<string>(type: "character varying(225)", maxLength: 225, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioAna", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "SesionAna",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Token = table.Column<string>(type: "character varying(225)", maxLength: 225, nullable: false),
                    Cedula_usuario = table.Column<string>(type: "character varying(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SesionAna", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SesionAna_UsuarioAna_Cedula_usuario",
                        column: x => x.Cedula_usuario,
                        principalTable: "UsuarioAna",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SesionAna_Cedula_usuario",
                table: "SesionAna",
                column: "Cedula_usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SesionAna");

            migrationBuilder.DropTable(
                name: "UsuarioAna");
        }
    }
}
