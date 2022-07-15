using Microsoft.EntityFrameworkCore.Migrations;

namespace NewApp.Migrations
{
    public partial class Nuevo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_EstadoPersona_EstadoId",
                table: "Pacientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstadoPersona",
                table: "EstadoPersona");

            migrationBuilder.RenameTable(
                name: "EstadoPersona",
                newName: "EstadoPersonas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstadoPersonas",
                table: "EstadoPersonas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_EstadoPersonas_EstadoId",
                table: "Pacientes",
                column: "EstadoId",
                principalTable: "EstadoPersonas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_EstadoPersonas_EstadoId",
                table: "Pacientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstadoPersonas",
                table: "EstadoPersonas");

            migrationBuilder.RenameTable(
                name: "EstadoPersonas",
                newName: "EstadoPersona");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstadoPersona",
                table: "EstadoPersona",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_EstadoPersona_EstadoId",
                table: "Pacientes",
                column: "EstadoId",
                principalTable: "EstadoPersona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
