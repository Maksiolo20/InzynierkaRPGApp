using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGApp.Data.Migrations
{
    public partial class CardChange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HeroCards_SessionId",
                table: "HeroCards",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_BestiaryCards_SessionId",
                table: "BestiaryCards",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_BestiaryCards_Sessions_SessionId",
                table: "BestiaryCards",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HeroCards_Sessions_SessionId",
                table: "HeroCards",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BestiaryCards_Sessions_SessionId",
                table: "BestiaryCards");

            migrationBuilder.DropForeignKey(
                name: "FK_HeroCards_Sessions_SessionId",
                table: "HeroCards");

            migrationBuilder.DropIndex(
                name: "IX_HeroCards_SessionId",
                table: "HeroCards");

            migrationBuilder.DropIndex(
                name: "IX_BestiaryCards_SessionId",
                table: "BestiaryCards");
        }
    }
}
