using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MiApi.Migrations
{
    /// <inheritdoc />
    public partial class AgregadosPaises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Empresa_Pais_Origen",
                schema: "biblioteca",
                table: "empresa",
                newName: "empresa_pais_origen");

            migrationBuilder.RenameColumn(
                name: "Empresa_Nombre",
                schema: "biblioteca",
                table: "empresa",
                newName: "empresa_nombre");

            migrationBuilder.RenameColumn(
                name: "Empresa_Logo",
                schema: "biblioteca",
                table: "empresa",
                newName: "empresa_logo");

            migrationBuilder.RenameColumn(
                name: "Empresa_Fecha_Creacion",
                schema: "biblioteca",
                table: "empresa",
                newName: "empresa_fecha_creacion");

            migrationBuilder.RenameColumn(
                name: "Empresa_Id",
                schema: "biblioteca",
                table: "empresa",
                newName: "empresa_id");

            migrationBuilder.AddColumn<int>(
                name: "Empresa_PaisPais_Id",
                schema: "biblioteca",
                table: "empresa",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pais",
                schema: "biblioteca",
                columns: table => new
                {
                    pais_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pais_nombre = table.Column<string>(type: "text", nullable: true),
                    pais_habitantes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.pais_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_empresa_Empresa_PaisPais_Id",
                schema: "biblioteca",
                table: "empresa",
                column: "Empresa_PaisPais_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_empresa_Pais_Empresa_PaisPais_Id",
                schema: "biblioteca",
                table: "empresa",
                column: "Empresa_PaisPais_Id",
                principalSchema: "biblioteca",
                principalTable: "Pais",
                principalColumn: "pais_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_empresa_Pais_Empresa_PaisPais_Id",
                schema: "biblioteca",
                table: "empresa");

            migrationBuilder.DropTable(
                name: "Pais",
                schema: "biblioteca");

            migrationBuilder.DropIndex(
                name: "IX_empresa_Empresa_PaisPais_Id",
                schema: "biblioteca",
                table: "empresa");

            migrationBuilder.DropColumn(
                name: "Empresa_PaisPais_Id",
                schema: "biblioteca",
                table: "empresa");

            migrationBuilder.RenameColumn(
                name: "empresa_pais_origen",
                schema: "biblioteca",
                table: "empresa",
                newName: "Empresa_Pais_Origen");

            migrationBuilder.RenameColumn(
                name: "empresa_nombre",
                schema: "biblioteca",
                table: "empresa",
                newName: "Empresa_Nombre");

            migrationBuilder.RenameColumn(
                name: "empresa_logo",
                schema: "biblioteca",
                table: "empresa",
                newName: "Empresa_Logo");

            migrationBuilder.RenameColumn(
                name: "empresa_fecha_creacion",
                schema: "biblioteca",
                table: "empresa",
                newName: "Empresa_Fecha_Creacion");

            migrationBuilder.RenameColumn(
                name: "empresa_id",
                schema: "biblioteca",
                table: "empresa",
                newName: "Empresa_Id");
        }
    }
}
