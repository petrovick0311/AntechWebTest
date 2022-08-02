using Microsoft.EntityFrameworkCore.Migrations;

namespace AntechLicense.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgrupacionId",
                table: "Compras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CadenaId",
                table: "Compras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaisId",
                table: "Compras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PropietarioId",
                table: "Compras",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgrupacionId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "CadenaId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "PropietarioId",
                table: "Compras");
        }
    }
}
