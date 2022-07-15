using Microsoft.EntityFrameworkCore.Migrations;

namespace NewApp.Migrations
{
    public partial class SexoPersona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_SexoPersona_SexoId",
                table: "Pacientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SexoPersona",
                table: "SexoPersona");

            migrationBuilder.RenameTable(
                name: "SexoPersona",
                newName: "SexoPersonas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SexoPersonas",
                table: "SexoPersonas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_SexoPersonas_SexoId",
                table: "Pacientes",
                column: "SexoId",
                principalTable: "SexoPersonas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_SexoPersonas_SexoId",
                table: "Pacientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SexoPersonas",
                table: "SexoPersonas");

            migrationBuilder.RenameTable(
                name: "SexoPersonas",
                newName: "SexoPersona");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SexoPersona",
                table: "SexoPersona",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_SexoPersona_SexoId",
                table: "Pacientes",
                column: "SexoId",
                principalTable: "SexoPersona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
