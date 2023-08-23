using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JGV.StockControl.Library.Migrations
{
    /// <inheritdoc />
    public partial class soldProductsKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SoldProducts",
                table: "SoldProducts");

            migrationBuilder.DropIndex(
                name: "IX_SoldProducts_ProductId",
                table: "SoldProducts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SoldProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoldProducts",
                table: "SoldProducts",
                columns: new[] { "ProductId", "SellId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SoldProducts",
                table: "SoldProducts");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SoldProducts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoldProducts",
                table: "SoldProducts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SoldProducts_ProductId",
                table: "SoldProducts",
                column: "ProductId");
        }
    }
}
