using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Samuri.Data.Migrations
{
    public partial class relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samuris_Battles_BattleId",
                table: "Samuris");

            migrationBuilder.DropIndex(
                name: "IX_Samuris_BattleId",
                table: "Samuris");

            migrationBuilder.DropColumn(
                name: "BattleId",
                table: "Samuris");

            migrationBuilder.DropColumn(
                name: "BattleId",
                table: "Battles");

            migrationBuilder.CreateTable(
                name: "SecretIdentity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BattleName = table.Column<string>(nullable: true),
                    SamuraiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecretIdentity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecretIdentity_Samuris_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Samuris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SumariBattle",
                columns: table => new
                {
                    SamuraiId = table.Column<int>(nullable: false),
                    BattleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SumariBattle", x => new { x.SamuraiId, x.BattleId });
                    table.ForeignKey(
                        name: "FK_SumariBattle_Battles_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SumariBattle_Samuris_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Samuris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SecretIdentity_SamuraiId",
                table: "SecretIdentity",
                column: "SamuraiId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SumariBattle_BattleId",
                table: "SumariBattle",
                column: "BattleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecretIdentity");

            migrationBuilder.DropTable(
                name: "SumariBattle");

            migrationBuilder.AddColumn<int>(
                name: "BattleId",
                table: "Samuris",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BattleId",
                table: "Battles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Samuris_BattleId",
                table: "Samuris",
                column: "BattleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Samuris_Battles_BattleId",
                table: "Samuris",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
