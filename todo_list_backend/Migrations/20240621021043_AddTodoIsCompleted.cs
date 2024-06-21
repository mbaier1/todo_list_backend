using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todo_list_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddTodoIsCompleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "TodoIsCompleted",
                table: "TodoItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TodoIsCompleted",
                table: "TodoItems");
        }
    }
}
