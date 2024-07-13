using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Identity.Migrations
{
    /// <inheritdoc />
    public partial class IdentityCodeTablechanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "IdentityCodes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "IdentityCodes");
        }
    }
}
