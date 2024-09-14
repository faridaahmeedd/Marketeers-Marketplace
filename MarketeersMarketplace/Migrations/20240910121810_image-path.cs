using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketeersMarketplace.Migrations
{
    /// <inheritdoc />
    public partial class imagepath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Images",
                newName: "Path");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Images",
                newName: "Title");
        }
    }
}
