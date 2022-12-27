using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGApp.Data.Migrations
{
    public partial class Update_of_Cards_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeroCards_Sessions_SessionId",
                table: "HeroCards");

            migrationBuilder.DropTable(
                name: "BestiaryCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HeroCards",
                table: "HeroCards");

            migrationBuilder.RenameTable(
                name: "HeroCards",
                newName: "Cards");

            migrationBuilder.RenameColumn(
                name: "CardName",
                table: "Cards",
                newName: "Title");

            migrationBuilder.RenameIndex(
                name: "IX_HeroCards_SessionId",
                table: "Cards",
                newName: "IX_Cards_SessionId");

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CardPath",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ChosenCardType",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Sessions_SessionId",
                table: "Cards",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Sessions_SessionId",
                table: "Cards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Body",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardPath",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ChosenCardType",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Cards");

            migrationBuilder.RenameTable(
                name: "Cards",
                newName: "HeroCards");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "HeroCards",
                newName: "CardName");

            migrationBuilder.RenameIndex(
                name: "IX_Cards_SessionId",
                table: "HeroCards",
                newName: "IX_HeroCards_SessionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HeroCards",
                table: "HeroCards",
                column: "CardId");

            migrationBuilder.CreateTable(
                name: "BestiaryCards",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    CardName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BestiaryCards", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_BestiaryCards_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BestiaryCards_SessionId",
                table: "BestiaryCards",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_HeroCards_Sessions_SessionId",
                table: "HeroCards",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
