using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiApi.Migrations
{
    /// <inheritdoc />
    public partial class CambioBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "pais",
                schema: "biblioteca",
                newName: "pais",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "empresa",
                schema: "biblioteca",
                newName: "empresa",
                newSchema: "public");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "biblioteca");

            migrationBuilder.RenameTable(
                name: "pais",
                schema: "public",
                newName: "pais",
                newSchema: "biblioteca");

            migrationBuilder.RenameTable(
                name: "empresa",
                schema: "public",
                newName: "empresa",
                newSchema: "biblioteca");
        }
    }
}
