using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MiApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "biblioteca");

            migrationBuilder.CreateTable(
                name: "empresa",
                schema: "biblioteca",
                columns: table => new
                {
                    Empresa_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Empresa_Fecha_Creacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Empresa_Logo = table.Column<string>(type: "text", nullable: true),
                    Empresa_Nombre = table.Column<string>(type: "text", nullable: true),
                    Empresa_Pais_Origen = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresa", x => x.Empresa_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "empresa",
                schema: "biblioteca");
        }
    }
}
