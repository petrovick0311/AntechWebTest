using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AntechLicense.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaisId = table.Column<int>(type: "int", nullable: false),
                    AgrupacionId = table.Column<int>(type: "int", nullable: false),
                    CadenaId = table.Column<int>(type: "int", nullable: false),
                    PropietarioId = table.Column<int>(type: "int", nullable: false),
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
                name: "Licencias",
                columns: table => new
                {
                    LicenciaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroLicencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombrePropietario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreSucursal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MacAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoLicencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licencias", x => x.LicenciaID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiftWrap = table.Column<bool>(type: "bit", nullable: false),
                    Shipped = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "T_Drinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDrink = table.Column<int>(type: "int", nullable: false),
                    strDrink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strDrinkAlternate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strTags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strIBA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strAlcoholic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strGlass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strInstructionsES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strInstructionsDE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strInstructionsFR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strInstructionsIT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strInstructionsZH_HANS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strInstructionsZH_HANT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strDrinkThumb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strIngredient1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strIngredient2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strIngredient3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strIngredient4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strIngredient5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strIngredient6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strIngredient7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strIngredient8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strIngredient9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strIngredient10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strIngredient11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strIngredient12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strIngredient13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strIngredient14 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strIngredient15 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strMeasure1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strMeasure2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strMeasure3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strMeasure4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strMeasure5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strMeasure6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strMeasure7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strMeasure8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strMeasure9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strMeasure10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strMeasure11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strMeasure12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strMeasure13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strMeasure14 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strMeasure15 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strImageSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strImageAttribution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strCreativeCommonsConfirmed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Drinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_FavouritesDrinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F_IdDrink = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_FavouritesDrinks", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "CartLine",
                columns: table => new
                {
                    CartLineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenciaID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartLine", x => x.CartLineID);
                    table.ForeignKey(
                        name: "FK_CartLine_Licencias_LicenciaID",
                        column: x => x.LicenciaID,
                        principalTable: "Licencias",
                        principalColumn: "LicenciaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartLine_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartLine_LicenciaID",
                table: "CartLine",
                column: "LicenciaID");

            migrationBuilder.CreateIndex(
                name: "IX_CartLine_OrderID",
                table: "CartLine",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasD_CompraId",
                table: "ComprasD",
                column: "CompraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartLine");

            migrationBuilder.DropTable(
                name: "ComprasD");

            migrationBuilder.DropTable(
                name: "T_Drinks");

            migrationBuilder.DropTable(
                name: "T_FavouritesDrinks");

            migrationBuilder.DropTable(
                name: "Licencias");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Compras");
        }
    }
}
