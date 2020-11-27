using Microsoft.EntityFrameworkCore.Migrations;

namespace Catto.DataLib.Migrations
{
    public partial class MachineListFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MalfunctionType",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "ManualLink",
                table: "Machines");

            migrationBuilder.CreateTable(
                name: "Malfuntions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineModel = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MalfunctionType = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    ManualLink = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Malfuntions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Malfuntions_Machines_MachineModel",
                        column: x => x.MachineModel,
                        principalTable: "Machines",
                        principalColumn: "Model",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Malfuntions_MachineModel",
                table: "Malfuntions",
                column: "MachineModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Malfuntions");

            migrationBuilder.AddColumn<string>(
                name: "MalfunctionType",
                table: "Machines",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManualLink",
                table: "Machines",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: true);
        }
    }
}
