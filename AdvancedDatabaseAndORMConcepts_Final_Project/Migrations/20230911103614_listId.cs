using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvancedDatabaseAndORMConcepts_Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class listId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "List",
                newName: "ListId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Item",
                newName: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ListId",
                table: "List",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Item",
                newName: "Id");
        }
    }
}
