using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Name" },
                values: new object[,]
                {
                    {  "Admin" },
                    {  "User" },
                    {  "Manager" },
                    { "Staff" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
