using Microsoft.EntityFrameworkCore.Migrations;

namespace ILab.Migrations
{
    public partial class migration124 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "ListaPrecios",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "ListaPrecios");
        }
    }
}
