using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddIsRegisteredColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRegistered",
                table: "IdentityCodes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRegistered",
                table: "IdentityCodes");
        }
    }
}
