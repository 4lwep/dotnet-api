using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiApi.Migrations
{
    /// <inheritdoc />
    public partial class AgregadosPaisesAhoraDeVerdadEspero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_empresa_Pais_Empresa_PaisPais_Id",
                schema: "biblioteca",
                table: "empresa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pais",
                schema: "biblioteca",
                table: "Pais");

            migrationBuilder.RenameTable(
                name: "Pais",
                schema: "biblioteca",
                newName: "pais",
                newSchema: "biblioteca");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pais",
                schema: "biblioteca",
                table: "pais",
                column: "pais_id");

            migrationBuilder.AddForeignKey(
                name: "FK_empresa_pais_Empresa_PaisPais_Id",
                schema: "biblioteca",
                table: "empresa",
                column: "Empresa_PaisPais_Id",
                principalSchema: "biblioteca",
                principalTable: "pais",
                principalColumn: "pais_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_empresa_pais_Empresa_PaisPais_Id",
                schema: "biblioteca",
                table: "empresa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pais",
                schema: "biblioteca",
                table: "pais");

            migrationBuilder.RenameTable(
                name: "pais",
                schema: "biblioteca",
                newName: "Pais",
                newSchema: "biblioteca");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pais",
                schema: "biblioteca",
                table: "Pais",
                column: "pais_id");

            migrationBuilder.AddForeignKey(
                name: "FK_empresa_Pais_Empresa_PaisPais_Id",
                schema: "biblioteca",
                table: "empresa",
                column: "Empresa_PaisPais_Id",
                principalSchema: "biblioteca",
                principalTable: "Pais",
                principalColumn: "pais_id");
        }
    }
}
