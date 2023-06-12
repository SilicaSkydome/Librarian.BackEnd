using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Librarian.BackEnd.Entity.Migrations
{
    /// <inheritdoc />
    public partial class FixedTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TagsAsString",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TagsAsString",
                table: "Books");
        }
    }
}
