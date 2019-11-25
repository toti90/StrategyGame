using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Dal.Migrations
{
    public partial class adddevelopments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developments",
                columns: table => new
                {
                    DevelopmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DevelopmentName = table.Column<string>(nullable: false),
                    AddCorall = table.Column<double>(nullable: true),
                    AddDefense = table.Column<double>(nullable: true),
                    AddAttack = table.Column<double>(nullable: true),
                    AddTax = table.Column<double>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developments", x => x.DevelopmentId);
                });

            migrationBuilder.CreateTable(
                name: "DevelopmentGroups",
                columns: table => new
                {
                    DevelopmentGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(nullable: false, defaultValue: 1),
                    UserId = table.Column<string>(nullable: true),
                    DevelopmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopmentGroups", x => x.DevelopmentGroupId);
                    table.ForeignKey(
                        name: "FK_DevelopmentGroups_Developments_DevelopmentId",
                        column: x => x.DevelopmentId,
                        principalTable: "Developments",
                        principalColumn: "DevelopmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DevelopmentGroups_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NewDevelopments",
                columns: table => new
                {
                    NewDevelopmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Round = table.Column<int>(nullable: false, defaultValue: 1),
                    DevelopmentGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewDevelopments", x => x.NewDevelopmentId);
                    table.ForeignKey(
                        name: "FK_NewDevelopments_DevelopmentGroups_DevelopmentGroupId",
                        column: x => x.DevelopmentGroupId,
                        principalTable: "DevelopmentGroups",
                        principalColumn: "DevelopmentGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentGroups_DevelopmentId",
                table: "DevelopmentGroups",
                column: "DevelopmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentGroups_UserId",
                table: "DevelopmentGroups",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NewDevelopments_DevelopmentGroupId",
                table: "NewDevelopments",
                column: "DevelopmentGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewDevelopments");

            migrationBuilder.DropTable(
                name: "DevelopmentGroups");

            migrationBuilder.DropTable(
                name: "Developments");
        }
    }
}
