using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AntechLicense.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRecepcion = table.Column<int>(type: "int", nullable: false),
                    FolioDocumento = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    OrdenCompra = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    PorcentajeIEPS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PorcentajeIVA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImporteIEPS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImporteIVA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTipoPago = table.Column<int>(type: "int", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComprasD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRecepcion = table.Column<int>(type: "int", nullable: false),
                    IdRecepcionD = table.Column<int>(type: "int", nullable: false),
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImporteIEPS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImporteIVA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caducidad = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprasD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComprasD_Compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComprasD_CompraId",
                table: "ComprasD",
                column: "CompraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComprasD");

            migrationBuilder.DropTable(
                name: "Compras");
        }
    }
}
