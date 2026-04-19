using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HotelId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_HotelId",
                table: "Users",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Hotels_HotelId",
                table: "Users",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Hotels_HotelId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_HotelId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Users");
        }
    }
}
