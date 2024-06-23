using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todo_list_backend.Migrations
{
    /// <inheritdoc />
    public partial class CreatedSubTodoTableWithForeignKeyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubTodoItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTodoIsOverdue = table.Column<bool>(type: "bit", nullable: false),
                    SubTodoIsComplete = table.Column<bool>(type: "bit", nullable: false),
                    TodoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTodoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubTodoItems_TodoItems_TodoId",
                        column: x => x.TodoId,
                        principalTable: "TodoItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubTodoItems_TodoId",
                table: "SubTodoItems",
                column: "TodoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubTodoItems");
        }
    }
}
