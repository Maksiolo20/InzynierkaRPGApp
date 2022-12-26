using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGApp.Data.Migrations
{
    public partial class HeroCardUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeroCards",
                columns: table => new
                {
                    HeroCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeroCardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroCards", x => x.HeroCardId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroCards");
        }
    }
}
