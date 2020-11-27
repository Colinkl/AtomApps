using Microsoft.EntityFrameworkCore.Migrations;

namespace Catto.DataLib.Migrations
{
    public partial class MalfunctionsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Malfuntions_Machines_MachineModel",
                table: "Malfuntions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Malfuntions",
                table: "Malfuntions");

            migrationBuilder.RenameTable(
                name: "Malfuntions",
                newName: "MalfuntionsList");

            migrationBuilder.RenameIndex(
                name: "IX_Malfuntions_MachineModel",
                table: "MalfuntionsList",
                newName: "IX_MalfuntionsList_MachineModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MalfuntionsList",
                table: "MalfuntionsList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MalfuntionsList_Machines_MachineModel",
                table: "MalfuntionsList",
                column: "MachineModel",
                principalTable: "Machines",
                principalColumn: "Model",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MalfuntionsList_Machines_MachineModel",
                table: "MalfuntionsList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MalfuntionsList",
                table: "MalfuntionsList");

            migrationBuilder.RenameTable(
                name: "MalfuntionsList",
                newName: "Malfuntions");

            migrationBuilder.RenameIndex(
                name: "IX_MalfuntionsList_MachineModel",
                table: "Malfuntions",
                newName: "IX_Malfuntions_MachineModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Malfuntions",
                table: "Malfuntions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Malfuntions_Machines_MachineModel",
                table: "Malfuntions",
                column: "MachineModel",
                principalTable: "Machines",
                principalColumn: "Model",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
