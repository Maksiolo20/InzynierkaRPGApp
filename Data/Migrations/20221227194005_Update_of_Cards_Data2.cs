using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGApp.Data.Migrations
{
    public partial class Update_of_Cards_Data2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HeroCard_SessionId1",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SessionId1",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_HeroCard_SessionId1",
                table: "Cards",
                column: "HeroCard_SessionId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_SessionId1",
                table: "Cards",
                column: "SessionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Sessions_HeroCard_SessionId1",
                table: "Cards",
                column: "HeroCard_SessionId1",
                principalTable: "Sessions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Sessions_SessionId1",
                table: "Cards",
                column: "SessionId1",
                principalTable: "Sessions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Sessions_HeroCard_SessionId1",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Sessions_SessionId1",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_HeroCard_SessionId1",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_SessionId1",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "HeroCard_SessionId1",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "SessionId1",
                table: "Cards");
        }
    }
}
