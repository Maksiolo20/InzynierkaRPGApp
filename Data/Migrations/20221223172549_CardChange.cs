using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGApp.Data.Migrations
{
    public partial class CardChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HeroCardName",
                table: "HeroCards",
                newName: "CardName");

            migrationBuilder.RenameColumn(
                name: "HeroCardId",
                table: "HeroCards",
                newName: "CardId");

            migrationBuilder.CreateTable(
                name: "BestiaryCards",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BestiaryCards", x => x.CardId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BestiaryCards");

            migrationBuilder.RenameColumn(
                name: "CardName",
                table: "HeroCards",
                newName: "HeroCardName");

            migrationBuilder.RenameColumn(
                name: "CardId",
                table: "HeroCards",
                newName: "HeroCardId");
        }
    }
}
