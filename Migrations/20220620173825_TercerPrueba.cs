using Microsoft.EntityFrameworkCore.Migrations;

namespace NewApp.Migrations
{
    public partial class TercerPrueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Pacientes");

            migrationBuilder.AddColumn<int>(
                name: "SexoId",
                table: "Pacientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SexoPersona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SexoPersona", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_SexoId",
                table: "Pacientes",
                column: "SexoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_SexoPersona_SexoId",
                table: "Pacientes",
                column: "SexoId",
                principalTable: "SexoPersona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_SexoPersona_SexoId",
                table: "Pacientes");

            migrationBuilder.DropTable(
                name: "SexoPersona");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_SexoId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "SexoId",
                table: "Pacientes");

            migrationBuilder.AddColumn<int>(
                name: "Sexo",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
