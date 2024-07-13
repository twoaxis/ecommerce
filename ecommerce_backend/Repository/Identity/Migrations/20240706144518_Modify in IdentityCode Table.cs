using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Identity.Migrations
{
    /// <inheritdoc />
    public partial class ModifyinIdentityCodeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "IdentityCodes");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActivationTime",
                table: "IdentityCodes",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivationTime",
                table: "IdentityCodes");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "IdentityCodes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
