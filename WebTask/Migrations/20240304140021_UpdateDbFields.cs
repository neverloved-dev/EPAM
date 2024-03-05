using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTask.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "UnitPrice");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "Supplier",
                table: "Categories",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Categories",
                newName: "Supplier");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Categories",
                newName: "Id");
        }
    }
}
