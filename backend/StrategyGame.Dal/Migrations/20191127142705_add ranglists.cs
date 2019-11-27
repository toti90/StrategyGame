using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Dal.Migrations
{
    public partial class addranglists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "DevelopmentGroups",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.CreateTable(
                name: "RanglistCollections",
                columns: table => new
                {
                    RanglistCollectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(nullable: false),
                    Round = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RanglistCollections", x => x.RanglistCollectionId);
                    table.ForeignKey(
                        name: "FK_RanglistCollections_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ranglists",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true),
                    Point = table.Column<int>(nullable: false),
                    Place = table.Column<int>(nullable: false),
                    RanglistCollectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Ranglists_RanglistCollections_RanglistCollectionId",
                        column: x => x.RanglistCollectionId,
                        principalTable: "RanglistCollections",
                        principalColumn: "RanglistCollectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ranglists_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RanglistCollections_GameId",
                table: "RanglistCollections",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranglists_RanglistCollectionId",
                table: "Ranglists",
                column: "RanglistCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranglists_UserId1",
                table: "Ranglists",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ranglists");

            migrationBuilder.DropTable(
                name: "RanglistCollections");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "DevelopmentGroups",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldDefaultValue: 0);
        }
    }
}
