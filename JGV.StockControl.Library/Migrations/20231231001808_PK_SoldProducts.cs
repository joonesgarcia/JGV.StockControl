using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JGV.StockControl.Library.Migrations
{
    /// <inheritdoc />
    public partial class PK_SoldProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SoldProducts",
                table: "SoldProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoldProducts",
                table: "SoldProducts",
                columns: new[] { "ProductId", "SellId", "SoldPrice" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SoldProducts",
                table: "SoldProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoldProducts",
                table: "SoldProducts",
                columns: new[] { "ProductId", "SellId" });
        }
    }
}
