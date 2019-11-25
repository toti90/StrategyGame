using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Dal.Migrations
{
    public partial class chageUnitIdtypeinLegion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Legions_Units_UnitId1",
                table: "Legions");

            migrationBuilder.DropIndex(
                name: "IX_Legions_UnitId1",
                table: "Legions");

            migrationBuilder.DropColumn(
                name: "UnitId1",
                table: "Legions");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Legions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Legions_UnitId",
                table: "Legions",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Legions_Units_UnitId",
                table: "Legions",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Legions_Units_UnitId",
                table: "Legions");

            migrationBuilder.DropIndex(
                name: "IX_Legions_UnitId",
                table: "Legions");

            migrationBuilder.AlterColumn<string>(
                name: "UnitId",
                table: "Legions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UnitId1",
                table: "Legions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Legions_UnitId1",
                table: "Legions",
                column: "UnitId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Legions_Units_UnitId1",
                table: "Legions",
                column: "UnitId1",
                principalTable: "Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
