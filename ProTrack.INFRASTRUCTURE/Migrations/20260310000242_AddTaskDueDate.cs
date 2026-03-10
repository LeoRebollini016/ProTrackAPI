using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProTrack.INFRAESTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskDueDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "due_date",
                table: "tasks",
                type: "timestamp with time zone",
                nullable: true,
                comment: "Fecha límite de la tarea (UTC)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "due_date",
                table: "tasks");
        }
    }
}
