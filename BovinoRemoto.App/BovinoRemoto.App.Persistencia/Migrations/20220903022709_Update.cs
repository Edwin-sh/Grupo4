using Microsoft.EntityFrameworkCore.Migrations;

namespace BovinoRemoto.App.Persistencia.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visitas_HistoriasClinicas_HistoriaClinicaId",
                table: "Visitas");

            migrationBuilder.RenameColumn(
                name: "HistoriaClinicaId",
                table: "Visitas",
                newName: "Historia_ClinicaId");

            migrationBuilder.RenameIndex(
                name: "IX_Visitas_HistoriaClinicaId",
                table: "Visitas",
                newName: "IX_Visitas_Historia_ClinicaId");

            migrationBuilder.AddColumn<int>(
                name: "DueñoId",
                table: "Vacas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HistoriaClinicaId",
                table: "Vacas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VeterinarioId",
                table: "Vacas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vacas_DueñoId",
                table: "Vacas",
                column: "DueñoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacas_HistoriaClinicaId",
                table: "Vacas",
                column: "HistoriaClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacas_VeterinarioId",
                table: "Vacas",
                column: "VeterinarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacas_Dueños_DueñoId",
                table: "Vacas",
                column: "DueñoId",
                principalTable: "Dueños",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacas_HistoriasClinicas_HistoriaClinicaId",
                table: "Vacas",
                column: "HistoriaClinicaId",
                principalTable: "HistoriasClinicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacas_Veterinarios_VeterinarioId",
                table: "Vacas",
                column: "VeterinarioId",
                principalTable: "Veterinarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitas_HistoriasClinicas_Historia_ClinicaId",
                table: "Visitas",
                column: "Historia_ClinicaId",
                principalTable: "HistoriasClinicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacas_Dueños_DueñoId",
                table: "Vacas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacas_HistoriasClinicas_HistoriaClinicaId",
                table: "Vacas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacas_Veterinarios_VeterinarioId",
                table: "Vacas");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitas_HistoriasClinicas_Historia_ClinicaId",
                table: "Visitas");

            migrationBuilder.DropIndex(
                name: "IX_Vacas_DueñoId",
                table: "Vacas");

            migrationBuilder.DropIndex(
                name: "IX_Vacas_HistoriaClinicaId",
                table: "Vacas");

            migrationBuilder.DropIndex(
                name: "IX_Vacas_VeterinarioId",
                table: "Vacas");

            migrationBuilder.DropColumn(
                name: "DueñoId",
                table: "Vacas");

            migrationBuilder.DropColumn(
                name: "HistoriaClinicaId",
                table: "Vacas");

            migrationBuilder.DropColumn(
                name: "VeterinarioId",
                table: "Vacas");

            migrationBuilder.RenameColumn(
                name: "Historia_ClinicaId",
                table: "Visitas",
                newName: "HistoriaClinicaId");

            migrationBuilder.RenameIndex(
                name: "IX_Visitas_Historia_ClinicaId",
                table: "Visitas",
                newName: "IX_Visitas_HistoriaClinicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitas_HistoriasClinicas_HistoriaClinicaId",
                table: "Visitas",
                column: "HistoriaClinicaId",
                principalTable: "HistoriasClinicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
