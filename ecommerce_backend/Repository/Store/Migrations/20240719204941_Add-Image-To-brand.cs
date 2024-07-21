using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Store.Migrations
{
    /// <inheritdoc />
    public partial class AddImageTobrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageCover",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageCover",
                table: "Brands");
        }
    }
}
