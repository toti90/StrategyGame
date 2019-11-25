using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Dal.Migrations
{
    public partial class addinitialvaluesforstorage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Pearl",
                table: "Storages",
                nullable: false,
                defaultValue: 100,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Coral",
                table: "Storages",
                nullable: false,
                defaultValue: 100,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Pearl",
                table: "Storages",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Coral",
                table: "Storages",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 100);
        }
    }
}
