using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Dal.Migrations
{
    public partial class addnewBuildings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "BuildingGroups",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "NewBuildings",
                columns: table => new
                {
                    newBuildingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Round = table.Column<int>(nullable: false, defaultValue: 1),
                    BuildingGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewBuildings", x => x.newBuildingId);
                    table.ForeignKey(
                        name: "FK_NewBuildings_BuildingGroups_BuildingGroupId",
                        column: x => x.BuildingGroupId,
                        principalTable: "BuildingGroups",
                        principalColumn: "BuildingGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewBuildings_BuildingGroupId",
                table: "NewBuildings",
                column: "BuildingGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewBuildings");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "BuildingGroups",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 1);
        }
    }
}
