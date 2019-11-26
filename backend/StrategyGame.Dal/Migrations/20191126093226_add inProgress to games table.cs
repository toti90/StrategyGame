using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Dal.Migrations
{
    public partial class addinProgresstogamestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Buildings");

            migrationBuilder.AddColumn<bool>(
                name: "inProgress",
                table: "Games",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "BigImageUrl",
                table: "Buildings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmallImageUrl",
                table: "Buildings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "inProgress",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "BigImageUrl",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "SmallImageUrl",
                table: "Buildings");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
