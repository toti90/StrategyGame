using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Dal.Migrations
{
    public partial class addunitsPart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(nullable: false),
                    Attack = table.Column<int>(nullable: false),
                    Defense = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Salary = table.Column<int>(nullable: false),
                    Food = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "Legions",
                columns: table => new
                {
                    LegionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    UnitId = table.Column<string>(nullable: false),
                    UnitId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legions", x => x.LegionId);
                    table.ForeignKey(
                        name: "FK_Legions_Units_UnitId1",
                        column: x => x.UnitId1,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Legions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FightGroups",
                columns: table => new
                {
                    FightGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartOfLegion = table.Column<double>(nullable: false),
                    AttackedId = table.Column<string>(nullable: false),
                    AttackedUserId = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: false),
                    OwnerUserId = table.Column<string>(nullable: true),
                    LegionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FightGroups", x => x.FightGroupId);
                    table.ForeignKey(
                        name: "FK_FightGroups_AspNetUsers_AttackedUserId",
                        column: x => x.AttackedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FightGroups_Legions_LegionId",
                        column: x => x.LegionId,
                        principalTable: "Legions",
                        principalColumn: "LegionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FightGroups_AspNetUsers_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FightGroups_AttackedUserId",
                table: "FightGroups",
                column: "AttackedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FightGroups_LegionId",
                table: "FightGroups",
                column: "LegionId");

            migrationBuilder.CreateIndex(
                name: "IX_FightGroups_OwnerUserId",
                table: "FightGroups",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Legions_UnitId1",
                table: "Legions",
                column: "UnitId1");

            migrationBuilder.CreateIndex(
                name: "IX_Legions_UserId",
                table: "Legions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FightGroups");

            migrationBuilder.DropTable(
                name: "Legions");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
