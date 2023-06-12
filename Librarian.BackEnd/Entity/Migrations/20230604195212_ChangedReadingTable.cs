using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Librarian.BackEnd.Entity.Migrations
{
    /// <inheritdoc />
    public partial class ChangedReadingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookUserReadings_Users_ReaderId",
                table: "BookUserReadings");

            migrationBuilder.DropIndex(
                name: "IX_BookUserReadings_ReaderId",
                table: "BookUserReadings");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "BookUserReadings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookUserReadings_UserId",
                table: "BookUserReadings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookUserReadings_Users_UserId",
                table: "BookUserReadings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookUserReadings_Users_UserId",
                table: "BookUserReadings");

            migrationBuilder.DropIndex(
                name: "IX_BookUserReadings_UserId",
                table: "BookUserReadings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BookUserReadings");

            migrationBuilder.CreateIndex(
                name: "IX_BookUserReadings_ReaderId",
                table: "BookUserReadings",
                column: "ReaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookUserReadings_Users_ReaderId",
                table: "BookUserReadings",
                column: "ReaderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
