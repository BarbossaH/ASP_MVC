using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMVC.Migrations
{
    /// <inheritdoc />
    public partial class Category2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplayOrder",
                table: "Categories",
                newName: "Order");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Categories",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Categories",
                newName: "DisplayOrder");
        }
    }
}
