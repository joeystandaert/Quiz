using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class questionsentencekey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Question_QuestionEFId_QuestionEFSentence",
                table: "Answer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Answer_QuestionEFId_QuestionEFSentence",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "QuestionEFSentence",
                table: "Answer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Question_Sentence",
                table: "Question",
                column: "Sentence",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionEFId",
                table: "Answer",
                column: "QuestionEFId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Question_QuestionEFId",
                table: "Answer",
                column: "QuestionEFId",
                principalTable: "Question",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Question_QuestionEFId",
                table: "Answer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_Sentence",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Answer_QuestionEFId",
                table: "Answer");

            migrationBuilder.AddColumn<string>(
                name: "QuestionEFSentence",
                table: "Answer",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                columns: new[] { "Id", "Sentence" });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionEFId_QuestionEFSentence",
                table: "Answer",
                columns: new[] { "QuestionEFId", "QuestionEFSentence" });

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Question_QuestionEFId_QuestionEFSentence",
                table: "Answer",
                columns: new[] { "QuestionEFId", "QuestionEFSentence" },
                principalTable: "Question",
                principalColumns: new[] { "Id", "Sentence" });
        }
    }
}
