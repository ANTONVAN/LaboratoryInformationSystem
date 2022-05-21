using Microsoft.EntityFrameworkCore.Migrations;

namespace ILab.Migrations
{
    public partial class _432 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstudioSols_Estudios_EstudioId",
                table: "EstudioSols");

            migrationBuilder.DropForeignKey(
                name: "FK_EstudioSols_Solicitudes_SolicitudId",
                table: "EstudioSols");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitudes_Pacientes_PacienteId",
                table: "Solicitudes");

            migrationBuilder.RenameColumn(
                name: "PacienteId",
                table: "Solicitudes",
                newName: "pacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Solicitudes_PacienteId",
                table: "Solicitudes",
                newName: "IX_Solicitudes_pacienteId");

            migrationBuilder.RenameColumn(
                name: "SolicitudId",
                table: "EstudioSols",
                newName: "solicitudId");

            migrationBuilder.RenameColumn(
                name: "EstudioId",
                table: "EstudioSols",
                newName: "estudioId");

            migrationBuilder.RenameIndex(
                name: "IX_EstudioSols_SolicitudId",
                table: "EstudioSols",
                newName: "IX_EstudioSols_solicitudId");

            migrationBuilder.RenameIndex(
                name: "IX_EstudioSols_EstudioId",
                table: "EstudioSols",
                newName: "IX_EstudioSols_estudioId");

            migrationBuilder.AlterColumn<int>(
                name: "pacienteId",
                table: "Solicitudes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "solicitudId",
                table: "EstudioSols",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "estudioId",
                table: "EstudioSols",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EstudioSols_Estudios_estudioId",
                table: "EstudioSols",
                column: "estudioId",
                principalTable: "Estudios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstudioSols_Solicitudes_solicitudId",
                table: "EstudioSols",
                column: "solicitudId",
                principalTable: "Solicitudes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitudes_Pacientes_pacienteId",
                table: "Solicitudes",
                column: "pacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstudioSols_Estudios_estudioId",
                table: "EstudioSols");

            migrationBuilder.DropForeignKey(
                name: "FK_EstudioSols_Solicitudes_solicitudId",
                table: "EstudioSols");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitudes_Pacientes_pacienteId",
                table: "Solicitudes");

            migrationBuilder.RenameColumn(
                name: "pacienteId",
                table: "Solicitudes",
                newName: "PacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Solicitudes_pacienteId",
                table: "Solicitudes",
                newName: "IX_Solicitudes_PacienteId");

            migrationBuilder.RenameColumn(
                name: "solicitudId",
                table: "EstudioSols",
                newName: "SolicitudId");

            migrationBuilder.RenameColumn(
                name: "estudioId",
                table: "EstudioSols",
                newName: "EstudioId");

            migrationBuilder.RenameIndex(
                name: "IX_EstudioSols_solicitudId",
                table: "EstudioSols",
                newName: "IX_EstudioSols_SolicitudId");

            migrationBuilder.RenameIndex(
                name: "IX_EstudioSols_estudioId",
                table: "EstudioSols",
                newName: "IX_EstudioSols_EstudioId");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "Solicitudes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SolicitudId",
                table: "EstudioSols",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EstudioId",
                table: "EstudioSols",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EstudioSols_Estudios_EstudioId",
                table: "EstudioSols",
                column: "EstudioId",
                principalTable: "Estudios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EstudioSols_Solicitudes_SolicitudId",
                table: "EstudioSols",
                column: "SolicitudId",
                principalTable: "Solicitudes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitudes_Pacientes_PacienteId",
                table: "Solicitudes",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
