using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestingTimeToMssql.Migrations
{
    /// <inheritdoc />
    public partial class AddUnq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_users_pesel",
                table: "users");

            migrationBuilder.CreateIndex(
                name: "IX_users_pesel",
                table: "users",
                column: "pesel",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_users_pesel",
                table: "users");

            migrationBuilder.CreateIndex(
                name: "IX_users_pesel",
                table: "users",
                column: "pesel");
        }
    }
}
