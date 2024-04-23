using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reborn.Fashion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImageSrc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageSrc",
                table: "Listings",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSrc",
                table: "Listings");
        }
    }
}
