using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Catto.DataLib.Migrations
{
    public partial class Task : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExecutorId = table.Column<int>(type: "int", nullable: true),
                    VerifierId = table.Column<int>(type: "int", nullable: true),
                    DeadLine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobTask_Employees_ExecutorId",
                        column: x => x.ExecutorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobTask_Employees_VerifierId",
                        column: x => x.VerifierId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobTask_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobTask_ExecutorId",
                table: "JobTask",
                column: "ExecutorId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTask_ProjectId",
                table: "JobTask",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTask_VerifierId",
                table: "JobTask",
                column: "VerifierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobTask");
        }
    }
}
