using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Customer.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class customers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Customer");

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Customer",
                table: "Clients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Client 1" },
                    { 2, "Client 2" },
                    { 3, "Client 3" },
                    { 4, "Client 4" },
                    { 5, "Client 5" },
                    { 6, "Client 6" },
                    { 7, "Client 7" },
                    { 8, "Client 8" },
                    { 9, "Client 9" },
                    { 10, "Client 10" },
                    { 11, "Client 11" },
                    { 12, "Client 12" },
                    { 13, "Client 13" },
                    { 14, "Client 14" },
                    { 15, "Client 15" },
                    { 16, "Client 16" },
                    { 17, "Client 17" },
                    { 18, "Client 18" },
                    { 19, "Client 19" },
                    { 20, "Client 20" },
                    { 21, "Client 21" },
                    { 22, "Client 22" },
                    { 23, "Client 23" },
                    { 24, "Client 24" },
                    { 25, "Client 25" },
                    { 26, "Client 26" },
                    { 27, "Client 27" },
                    { 28, "Client 28" },
                    { 29, "Client 29" },
                    { 30, "Client 30" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Id",
                schema: "Customer",
                table: "Clients",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients",
                schema: "Customer");
        }
    }
}
