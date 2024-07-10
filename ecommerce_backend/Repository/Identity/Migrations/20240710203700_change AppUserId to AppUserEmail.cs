using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Identity.Migrations
{
    /// <inheritdoc />
    public partial class changeAppUserIdtoAppUserEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "AppUserEmail",
                table: "IdentityCodes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "IdentityCodes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityCodes_UserId",
                table: "IdentityCodes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityCodes_AspNetUsers_UserId",
                table: "IdentityCodes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityCodes_AspNetUsers_UserId",
                table: "IdentityCodes");

            migrationBuilder.DropIndex(
                name: "IX_IdentityCodes_UserId",
                table: "IdentityCodes");

            migrationBuilder.DropColumn(
                name: "AppUserEmail",
                table: "IdentityCodes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "IdentityCodes");

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
    }
}
