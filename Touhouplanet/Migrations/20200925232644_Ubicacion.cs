using Microsoft.EntityFrameworkCore.Migrations;

namespace Touhouplanet.Migrations
{
    public partial class Ubicacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ubicacion",
                table: "Touhou",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ubicacion",
                table: "Touhou");
        }
    }
}
