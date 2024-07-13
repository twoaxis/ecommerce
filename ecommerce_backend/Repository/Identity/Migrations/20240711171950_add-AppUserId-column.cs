using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Identity.Migrations
{
    /// <inheritdoc />
    public partial class addAppUserIdcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "IdentityCodes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityCodes_AppUserId",
                table: "IdentityCodes",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityCodes_AspNetUsers_AppUserId",
                table: "IdentityCodes",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityCodes_AspNetUsers_AppUserId",
                table: "IdentityCodes");

            migrationBuilder.DropIndex(
                name: "IX_IdentityCodes_AppUserId",
                table: "IdentityCodes");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "IdentityCodes");
        }
    }
}
