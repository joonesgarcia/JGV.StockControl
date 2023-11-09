using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JGV.StockControl.Library.Migrations
{
    /// <inheritdoc />
    public partial class IsFromInitialInvestmentColumn_Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFromInitialInvestment",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFromInitialInvestment",
                table: "Products");
        }
    }
}
