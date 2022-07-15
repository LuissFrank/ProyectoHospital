using Microsoft.EntityFrameworkCore.Migrations;

namespace NewApp.Migrations
{
    public partial class cuartoM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Pacientes");

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Pacientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EstadoPersona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoPersona", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_EstadoId",
                table: "Pacientes",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_EstadoPersona_EstadoId",
                table: "Pacientes",
                column: "EstadoId",
                principalTable: "EstadoPersona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_EstadoPersona_EstadoId",
                table: "Pacientes");

            migrationBuilder.DropTable(
                name: "EstadoPersona");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_EstadoId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Pacientes");

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
