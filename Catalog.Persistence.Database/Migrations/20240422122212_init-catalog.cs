using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Catalog.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class initcatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "product description 1", "Product 1", 710m },
                    { 2, "product description 2", "Product 2", 390m },
                    { 3, "product description 3", "Product 3", 1517m },
                    { 4, "product description 4", "Product 4", 1566m },
                    { 5, "product description 5", "Product 5", 661m },
                    { 6, "product description 6", "Product 6", 977m },
                    { 7, "product description 7", "Product 7", 494m },
                    { 8, "product description 8", "Product 8", 792m },
                    { 9, "product description 9", "Product 9", 441m },
                    { 10, "product description 10", "Product 10", 220m },
                    { 11, "product description 11", "Product 11", 296m },
                    { 12, "product description 12", "Product 12", 806m },
                    { 13, "product description 13", "Product 13", 1516m },
                    { 14, "product description 14", "Product 14", 425m },
                    { 15, "product description 15", "Product 15", 1703m },
                    { 16, "product description 16", "Product 16", 758m },
                    { 17, "product description 17", "Product 17", 1161m },
                    { 18, "product description 18", "Product 18", 1453m },
                    { 19, "product description 19", "Product 19", 1096m },
                    { 20, "product description 20", "Product 20", 1567m },
                    { 21, "product description 21", "Product 21", 170m },
                    { 22, "product description 22", "Product 22", 737m },
                    { 23, "product description 23", "Product 23", 860m },
                    { 24, "product description 24", "Product 24", 441m },
                    { 25, "product description 25", "Product 25", 710m },
                    { 26, "product description 26", "Product 26", 1175m },
                    { 27, "product description 27", "Product 27", 1696m },
                    { 28, "product description 28", "Product 28", 938m },
                    { 29, "product description 29", "Product 29", 1752m },
                    { 30, "product description 30", "Product 30", 1638m },
                    { 31, "product description 31", "Product 31", 1668m },
                    { 32, "product description 32", "Product 32", 1834m },
                    { 33, "product description 33", "Product 33", 1239m },
                    { 34, "product description 34", "Product 34", 432m },
                    { 35, "product description 35", "Product 35", 1476m },
                    { 36, "product description 36", "Product 36", 966m },
                    { 37, "product description 37", "Product 37", 118m },
                    { 38, "product description 38", "Product 38", 609m },
                    { 39, "product description 39", "Product 39", 594m },
                    { 40, "product description 40", "Product 40", 350m },
                    { 41, "product description 41", "Product 41", 1961m },
                    { 42, "product description 42", "Product 42", 906m },
                    { 43, "product description 43", "Product 43", 1500m },
                    { 44, "product description 44", "Product 44", 310m },
                    { 45, "product description 45", "Product 45", 1477m },
                    { 46, "product description 46", "Product 46", 746m },
                    { 47, "product description 47", "Product 47", 906m },
                    { 48, "product description 48", "Product 48", 292m },
                    { 49, "product description 49", "Product 49", 626m },
                    { 50, "product description 50", "Product 50", 1156m },
                    { 51, "product description 51", "Product 51", 515m },
                    { 52, "product description 52", "Product 52", 1192m },
                    { 53, "product description 53", "Product 53", 1231m },
                    { 54, "product description 54", "Product 54", 462m },
                    { 55, "product description 55", "Product 55", 1223m },
                    { 56, "product description 56", "Product 56", 396m },
                    { 57, "product description 57", "Product 57", 854m },
                    { 58, "product description 58", "Product 58", 996m },
                    { 59, "product description 59", "Product 59", 1381m },
                    { 60, "product description 60", "Product 60", 131m },
                    { 61, "product description 61", "Product 61", 1969m },
                    { 62, "product description 62", "Product 62", 179m },
                    { 63, "product description 63", "Product 63", 897m },
                    { 64, "product description 64", "Product 64", 1515m },
                    { 65, "product description 65", "Product 65", 617m },
                    { 66, "product description 66", "Product 66", 1646m },
                    { 67, "product description 67", "Product 67", 370m },
                    { 68, "product description 68", "Product 68", 1432m },
                    { 69, "product description 69", "Product 69", 974m },
                    { 70, "product description 70", "Product 70", 608m },
                    { 71, "product description 71", "Product 71", 285m },
                    { 72, "product description 72", "Product 72", 992m },
                    { 73, "product description 73", "Product 73", 1069m },
                    { 74, "product description 74", "Product 74", 971m },
                    { 75, "product description 75", "Product 75", 1465m },
                    { 76, "product description 76", "Product 76", 1735m },
                    { 77, "product description 77", "Product 77", 1835m },
                    { 78, "product description 78", "Product 78", 1315m },
                    { 79, "product description 79", "Product 79", 496m },
                    { 80, "product description 80", "Product 80", 615m },
                    { 81, "product description 81", "Product 81", 813m },
                    { 82, "product description 82", "Product 82", 422m },
                    { 83, "product description 83", "Product 83", 1666m },
                    { 84, "product description 84", "Product 84", 854m },
                    { 85, "product description 85", "Product 85", 533m },
                    { 86, "product description 86", "Product 86", 1595m },
                    { 87, "product description 87", "Product 87", 1756m },
                    { 88, "product description 88", "Product 88", 120m },
                    { 89, "product description 89", "Product 89", 630m },
                    { 90, "product description 90", "Product 90", 1334m },
                    { 91, "product description 91", "Product 91", 1178m },
                    { 92, "product description 92", "Product 92", 953m },
                    { 93, "product description 93", "Product 93", 1926m },
                    { 94, "product description 94", "Product 94", 771m },
                    { 95, "product description 95", "Product 95", 1198m },
                    { 96, "product description 96", "Product 96", 1883m },
                    { 97, "product description 97", "Product 97", 940m },
                    { 98, "product description 98", "Product 98", 898m },
                    { 99, "product description 99", "Product 99", 568m },
                    { 100, "product description 100", "Product 100", 1991m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "Id", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 362 },
                    { 2, 2, 181 },
                    { 3, 3, 376 },
                    { 4, 4, 61 },
                    { 5, 5, 94 },
                    { 6, 6, 208 },
                    { 7, 7, 205 },
                    { 8, 8, 115 },
                    { 9, 9, 41 },
                    { 10, 10, 121 },
                    { 11, 11, 350 },
                    { 12, 12, 396 },
                    { 13, 13, 329 },
                    { 14, 14, 361 },
                    { 15, 15, 140 },
                    { 16, 16, 85 },
                    { 17, 17, 77 },
                    { 18, 18, 322 },
                    { 19, 19, 255 },
                    { 20, 20, 337 },
                    { 21, 21, 392 },
                    { 22, 22, 492 },
                    { 23, 23, 340 },
                    { 24, 24, 208 },
                    { 25, 25, 442 },
                    { 26, 26, 125 },
                    { 27, 27, 13 },
                    { 28, 28, 497 },
                    { 29, 29, 195 },
                    { 30, 30, 35 },
                    { 31, 31, 98 },
                    { 32, 32, 14 },
                    { 33, 33, 66 },
                    { 34, 34, 338 },
                    { 35, 35, 336 },
                    { 36, 36, 490 },
                    { 37, 37, 294 },
                    { 38, 38, 46 },
                    { 39, 39, 498 },
                    { 40, 40, 338 },
                    { 41, 41, 348 },
                    { 42, 42, 212 },
                    { 43, 43, 177 },
                    { 44, 44, 416 },
                    { 45, 45, 307 },
                    { 46, 46, 124 },
                    { 47, 47, 444 },
                    { 48, 48, 131 },
                    { 49, 49, 321 },
                    { 50, 50, 148 },
                    { 51, 51, 49 },
                    { 52, 52, 210 },
                    { 53, 53, 364 },
                    { 54, 54, 57 },
                    { 55, 55, 7 },
                    { 56, 56, 247 },
                    { 57, 57, 284 },
                    { 58, 58, 35 },
                    { 59, 59, 318 },
                    { 60, 60, 223 },
                    { 61, 61, 93 },
                    { 62, 62, 443 },
                    { 63, 63, 60 },
                    { 64, 64, 317 },
                    { 65, 65, 253 },
                    { 66, 66, 22 },
                    { 67, 67, 374 },
                    { 68, 68, 2 },
                    { 69, 69, 96 },
                    { 70, 70, 227 },
                    { 71, 71, 355 },
                    { 72, 72, 281 },
                    { 73, 73, 320 },
                    { 74, 74, 229 },
                    { 75, 75, 303 },
                    { 76, 76, 300 },
                    { 77, 77, 287 },
                    { 78, 78, 157 },
                    { 79, 79, 11 },
                    { 80, 80, 480 },
                    { 81, 81, 73 },
                    { 82, 82, 261 },
                    { 83, 83, 489 },
                    { 84, 84, 178 },
                    { 85, 85, 240 },
                    { 86, 86, 263 },
                    { 87, 87, 361 },
                    { 88, 88, 327 },
                    { 89, 89, 298 },
                    { 90, 90, 343 },
                    { 91, 91, 385 },
                    { 92, 92, 273 },
                    { 93, 93, 7 },
                    { 94, 94, 267 },
                    { 95, 95, 68 },
                    { 96, 96, 359 },
                    { 97, 97, 42 },
                    { 98, 98, 145 },
                    { 99, 99, 429 },
                    { 100, 100, 66 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Id",
                schema: "Catalog",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Id",
                schema: "Catalog",
                table: "Stocks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                schema: "Catalog",
                table: "Stocks",
                column: "ProductId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Catalog");
        }
    }
}
