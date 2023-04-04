using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Fixnameing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_ChellangedPlayerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_ChellengingPlayerId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "ChellengingPlayerId",
                table: "Games",
                newName: "ChallengingPlayerId");

            migrationBuilder.RenameColumn(
                name: "ChellangingPlayerWonGemsCount",
                table: "Games",
                newName: "ChallengingPlayerWonGemsCount");

            migrationBuilder.RenameColumn(
                name: "ChellangedPlayerWonGemsCount",
                table: "Games",
                newName: "ChallengedPlayerWonGemsCount");

            migrationBuilder.RenameColumn(
                name: "ChellangedPlayerId",
                table: "Games",
                newName: "ChallengedPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_ChellengingPlayerId",
                table: "Games",
                newName: "IX_Games_ChallengingPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_ChellangedPlayerId",
                table: "Games",
                newName: "IX_Games_ChallengedPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_ChallengedPlayerId",
                table: "Games",
                column: "ChallengedPlayerId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_ChallengingPlayerId",
                table: "Games",
                column: "ChallengingPlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_ChallengedPlayerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_ChallengingPlayerId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "ChallengingPlayerWonGemsCount",
                table: "Games",
                newName: "ChellangingPlayerWonGemsCount");

            migrationBuilder.RenameColumn(
                name: "ChallengingPlayerId",
                table: "Games",
                newName: "ChellengingPlayerId");

            migrationBuilder.RenameColumn(
                name: "ChallengedPlayerWonGemsCount",
                table: "Games",
                newName: "ChellangedPlayerWonGemsCount");

            migrationBuilder.RenameColumn(
                name: "ChallengedPlayerId",
                table: "Games",
                newName: "ChellangedPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_ChallengingPlayerId",
                table: "Games",
                newName: "IX_Games_ChellengingPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_ChallengedPlayerId",
                table: "Games",
                newName: "IX_Games_ChellangedPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_ChellangedPlayerId",
                table: "Games",
                column: "ChellangedPlayerId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_ChellengingPlayerId",
                table: "Games",
                column: "ChellengingPlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}
