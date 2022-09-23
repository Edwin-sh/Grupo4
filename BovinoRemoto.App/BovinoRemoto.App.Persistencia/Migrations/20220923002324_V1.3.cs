using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BovinoRemoto.App.Persistencia.Migrations
{
    public partial class V13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "veterinarioAsignado",
                table: "Vacas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "veterinarioAsignado",
                table: "Vacas");
        }
    }
}
