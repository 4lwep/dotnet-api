using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MiApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "pais",
                schema: "public",
                columns: table => new
                {
                    Pais_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pais_Nombre = table.Column<string>(type: "text", nullable: true),
                    Pais_Habitantes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais", x => x.Pais_Id);
                });

            migrationBuilder.CreateTable(
                name: "empresa",
                schema: "public",
                columns: table => new
                {
                    Empresa_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Empresa_Fecha_Creacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Empresa_Logo = table.Column<string>(type: "text", nullable: true),
                    Empresa_Nombre = table.Column<string>(type: "text", nullable: true),
                    Empresa_Pais_Origen = table.Column<string>(type: "text", nullable: true),
                    Pais_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresa", x => x.Empresa_Id);
                    table.ForeignKey(
                        name: "FK_empresa_pais_Pais_Id",
                        column: x => x.Pais_Id,
                        principalSchema: "public",
                        principalTable: "pais",
                        principalColumn: "Pais_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_empresa_Pais_Id",
                schema: "public",
                table: "empresa",
                column: "Pais_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "empresa",
                schema: "public");

            migrationBuilder.DropTable(
                name: "pais",
                schema: "public");
        }
    }
}
