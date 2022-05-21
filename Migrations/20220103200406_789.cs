using Microsoft.EntityFrameworkCore.Migrations;

namespace ILab.Migrations
{
    public partial class _789 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitudes_Companias_CompaniaId",
                table: "Solicitudes");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitudes_Medicos_MedicoId",
                table: "Solicitudes");

            migrationBuilder.RenameColumn(
                name: "MedicoId",
                table: "Solicitudes",
                newName: "medicoId");

            migrationBuilder.RenameColumn(
                name: "CompaniaId",
                table: "Solicitudes",
                newName: "companiaId");

            migrationBuilder.RenameIndex(
                name: "IX_Solicitudes_MedicoId",
                table: "Solicitudes",
                newName: "IX_Solicitudes_medicoId");

            migrationBuilder.RenameIndex(
                name: "IX_Solicitudes_CompaniaId",
                table: "Solicitudes",
                newName: "IX_Solicitudes_companiaId");

            migrationBuilder.AlterColumn<int>(
                name: "medicoId",
                table: "Solicitudes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "companiaId",
                table: "Solicitudes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitudes_Companias_companiaId",
                table: "Solicitudes",
                column: "companiaId",
                principalTable: "Companias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitudes_Medicos_medicoId",
                table: "Solicitudes",
                column: "medicoId",
                principalTable: "Medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitudes_Companias_companiaId",
                table: "Solicitudes");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitudes_Medicos_medicoId",
                table: "Solicitudes");

            migrationBuilder.RenameColumn(
                name: "medicoId",
                table: "Solicitudes",
                newName: "MedicoId");

            migrationBuilder.RenameColumn(
                name: "companiaId",
                table: "Solicitudes",
                newName: "CompaniaId");

            migrationBuilder.RenameIndex(
                name: "IX_Solicitudes_medicoId",
                table: "Solicitudes",
                newName: "IX_Solicitudes_MedicoId");

            migrationBuilder.RenameIndex(
                name: "IX_Solicitudes_companiaId",
                table: "Solicitudes",
                newName: "IX_Solicitudes_CompaniaId");

            migrationBuilder.AlterColumn<int>(
                name: "MedicoId",
                table: "Solicitudes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CompaniaId",
                table: "Solicitudes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitudes_Companias_CompaniaId",
                table: "Solicitudes",
                column: "CompaniaId",
                principalTable: "Companias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitudes_Medicos_MedicoId",
                table: "Solicitudes",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
