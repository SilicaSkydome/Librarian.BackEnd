using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Librarian.BackEnd.Entity.Migrations
{
    /// <inheritdoc />
    public partial class modifiedBookUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookUserReadings_Books_BookId",
                table: "BookUserReadings");

            migrationBuilder.DropForeignKey(
                name: "FK_BookUserReadings_Users_UserId",
                table: "BookUserReadings");

            migrationBuilder.DropIndex(
                name: "IX_BookUserReadings_BookId",
                table: "BookUserReadings");

            migrationBuilder.DropIndex(
                name: "IX_BookUserReadings_UserId",
                table: "BookUserReadings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BookUserReadings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "BookUserReadings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookUserReadings_BookId",
                table: "BookUserReadings",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookUserReadings_UserId",
                table: "BookUserReadings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookUserReadings_Books_BookId",
                table: "BookUserReadings",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookUserReadings_Users_UserId",
                table: "BookUserReadings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
