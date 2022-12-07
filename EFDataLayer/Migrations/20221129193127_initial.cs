using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => new { x.Id, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_Player_PlayerId_PlayerName",
                        columns: x => new { x.PlayerId, x.PlayerName },
                        principalTable: "Player",
                        principalColumns: new[] { "Id", "Name" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sentence = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GameEFId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => new { x.Id, x.Sentence });
                    table.ForeignKey(
                        name: "FK_Question_Game_GameEFId",
                        column: x => x.GameEFId,
                        principalTable: "Game",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sentence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    QuestionEFId = table.Column<int>(type: "int", nullable: true),
                    QuestionEFSentence = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answer_Question_QuestionEFId_QuestionEFSentence",
                        columns: x => new { x.QuestionEFId, x.QuestionEFSentence },
                        principalTable: "Question",
                        principalColumns: new[] { "Id", "Sentence" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionEFId_QuestionEFSentence",
                table: "Answer",
                columns: new[] { "QuestionEFId", "QuestionEFSentence" });

            migrationBuilder.CreateIndex(
                name: "IX_Game_PlayerId_PlayerName",
                table: "Game",
                columns: new[] { "PlayerId", "PlayerName" });

            migrationBuilder.CreateIndex(
                name: "IX_Question_GameEFId",
                table: "Question",
                column: "GameEFId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}
