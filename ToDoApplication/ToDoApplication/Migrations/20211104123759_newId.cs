using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoApplication.Migrations
{
    public partial class newId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignees_Todos_TodoTaskId",
                table: "Assignees");

            migrationBuilder.DropIndex(
                name: "IX_Assignees_TodoTaskId",
                table: "Assignees");

            migrationBuilder.DropColumn(
                name: "TodoTaskId",
                table: "Assignees");

            migrationBuilder.AddColumn<long>(
                name: "AssigneeId",
                table: "Todos",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Todos_AssigneeId",
                table: "Todos",
                column: "AssigneeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Assignees_AssigneeId",
                table: "Todos",
                column: "AssigneeId",
                principalTable: "Assignees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Assignees_AssigneeId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_AssigneeId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "AssigneeId",
                table: "Todos");

            migrationBuilder.AddColumn<long>(
                name: "TodoTaskId",
                table: "Assignees",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignees_TodoTaskId",
                table: "Assignees",
                column: "TodoTaskId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignees_Todos_TodoTaskId",
                table: "Assignees",
                column: "TodoTaskId",
                principalTable: "Todos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
