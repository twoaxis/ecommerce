using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AlterIsRegisteredcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRegistered",
                table: "IdentityCodes",
                newName: "IsConfirmed");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsConfirmed",
                table: "IdentityCodes",
                newName: "IsRegistered");
        }
    }
}
