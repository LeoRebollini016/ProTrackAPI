using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProTrack.INFRAESTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProjectStatusAndTarget : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "projects",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "target_date",
                table: "projects",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "target_date",
                table: "projects");
        }
    }
}
