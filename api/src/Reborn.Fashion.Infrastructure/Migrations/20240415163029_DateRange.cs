using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reborn.Fashion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DateRange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateRange_End",
                table: "Listings",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRange_Start",
                table: "Listings",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateRange_End",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "DateRange_Start",
                table: "Listings");
        }
    }
}
