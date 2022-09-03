using Microsoft.EntityFrameworkCore.Migrations;

namespace BovinoRemoto.App.Persistencia.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Personas",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Id_Dueño",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Id_Veterinario",
                table: "Personas");

            migrationBuilder.RenameTable(
                name: "Personas",
                newName: "Veterinarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veterinarios",
                table: "Veterinarios",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Dueños",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dueños", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dueños");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veterinarios",
                table: "Veterinarios");

            migrationBuilder.RenameTable(
                name: "Veterinarios",
                newName: "Personas");

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Id_Dueño",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_Veterinario",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personas",
                table: "Personas",
                column: "Id");
        }
    }
}
