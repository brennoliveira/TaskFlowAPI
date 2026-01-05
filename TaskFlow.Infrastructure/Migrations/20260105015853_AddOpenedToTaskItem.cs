using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskFlow.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddOpenedToTaskItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Opened",
                table: "TaskItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Opened",
                table: "TaskItems");
        }
    }
}
