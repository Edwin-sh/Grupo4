using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BovinoRemoto.App.Persistencia.Migrations
{
    public partial class V11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Num_Identificacion",
                table: "Veterinarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Vacas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Num_Identificacion",
                table: "Dueños",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Num_Identificacion",
                table: "Veterinarios");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Vacas");

            migrationBuilder.DropColumn(
                name: "Num_Identificacion",
                table: "Dueños");
        }
    }
}
