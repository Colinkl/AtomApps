using Microsoft.EntityFrameworkCore.Migrations;

namespace Catto.DataLib.Migrations
{
    public partial class TasksAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTask_Employees_ExecutorId",
                table: "JobTask");

            migrationBuilder.DropForeignKey(
                name: "FK_JobTask_Employees_VerifierId",
                table: "JobTask");

            migrationBuilder.DropForeignKey(
                name: "FK_JobTask_Project_ProjectId",
                table: "JobTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobTask",
                table: "JobTask");

            migrationBuilder.RenameTable(
                name: "JobTask",
                newName: "JobTasks");

            migrationBuilder.RenameIndex(
                name: "IX_JobTask_VerifierId",
                table: "JobTasks",
                newName: "IX_JobTasks_VerifierId");

            migrationBuilder.RenameIndex(
                name: "IX_JobTask_ProjectId",
                table: "JobTasks",
                newName: "IX_JobTasks_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_JobTask_ExecutorId",
                table: "JobTasks",
                newName: "IX_JobTasks_ExecutorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobTasks",
                table: "JobTasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobTasks_Employees_ExecutorId",
                table: "JobTasks",
                column: "ExecutorId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobTasks_Employees_VerifierId",
                table: "JobTasks",
                column: "VerifierId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobTasks_Project_ProjectId",
                table: "JobTasks",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTasks_Employees_ExecutorId",
                table: "JobTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_JobTasks_Employees_VerifierId",
                table: "JobTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_JobTasks_Project_ProjectId",
                table: "JobTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobTasks",
                table: "JobTasks");

            migrationBuilder.RenameTable(
                name: "JobTasks",
                newName: "JobTask");

            migrationBuilder.RenameIndex(
                name: "IX_JobTasks_VerifierId",
                table: "JobTask",
                newName: "IX_JobTask_VerifierId");

            migrationBuilder.RenameIndex(
                name: "IX_JobTasks_ProjectId",
                table: "JobTask",
                newName: "IX_JobTask_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_JobTasks_ExecutorId",
                table: "JobTask",
                newName: "IX_JobTask_ExecutorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobTask",
                table: "JobTask",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobTask_Employees_ExecutorId",
                table: "JobTask",
                column: "ExecutorId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobTask_Employees_VerifierId",
                table: "JobTask",
                column: "VerifierId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobTask_Project_ProjectId",
                table: "JobTask",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
