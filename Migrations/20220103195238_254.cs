using Microsoft.EntityFrameworkCore.Migrations;

namespace ILab.Migrations
{
    public partial class _254 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resultados_EstudioSols_EstudioSolId",
                table: "Resultados");

            migrationBuilder.DropColumn(
                name: "Compania",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "Medico",
                table: "Solicitudes");

            migrationBuilder.RenameColumn(
                name: "EstudioSolId",
                table: "Resultados",
                newName: "estudioSolId");

            migrationBuilder.RenameIndex(
                name: "IX_Resultados_EstudioSolId",
                table: "Resultados",
                newName: "IX_Resultados_estudioSolId");

            migrationBuilder.AddColumn<int>(
                name: "CompaniaId",
                table: "Solicitudes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicoId",
                table: "Solicitudes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "estudioSolId",
                table: "Resultados",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_CompaniaId",
                table: "Solicitudes",
                column: "CompaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_MedicoId",
                table: "Solicitudes",
                column: "MedicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resultados_EstudioSols_estudioSolId",
                table: "Resultados",
                column: "estudioSolId",
                principalTable: "EstudioSols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resultados_EstudioSols_estudioSolId",
                table: "Resultados");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitudes_Companias_CompaniaId",
                table: "Solicitudes");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitudes_Medicos_MedicoId",
                table: "Solicitudes");

            migrationBuilder.DropIndex(
                name: "IX_Solicitudes_CompaniaId",
                table: "Solicitudes");

            migrationBuilder.DropIndex(
                name: "IX_Solicitudes_MedicoId",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "CompaniaId",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "MedicoId",
                table: "Solicitudes");

            migrationBuilder.RenameColumn(
                name: "estudioSolId",
                table: "Resultados",
                newName: "EstudioSolId");

            migrationBuilder.RenameIndex(
                name: "IX_Resultados_estudioSolId",
                table: "Resultados",
                newName: "IX_Resultados_EstudioSolId");

            migrationBuilder.AddColumn<string>(
                name: "Compania",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Medico",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "EstudioSolId",
                table: "Resultados",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Resultados_EstudioSols_EstudioSolId",
                table: "Resultados",
                column: "EstudioSolId",
                principalTable: "EstudioSols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
