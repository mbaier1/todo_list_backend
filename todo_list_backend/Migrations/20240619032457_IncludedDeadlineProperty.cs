using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todo_list_backend.Migrations;

/// <inheritdoc />
public partial class IncludedDeadlineProperty : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "Deadline",
            table: "TodoItems",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Deadline",
            table: "TodoItems");
    }
}
