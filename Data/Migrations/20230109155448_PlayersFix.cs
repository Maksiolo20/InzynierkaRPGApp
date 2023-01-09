using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGApp.Data.Migrations
{
    public partial class PlayersFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_AspNetUsers_GameMasterId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_GameMasterId",
                table: "Sessions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d9b6151-d062-4fc1-a510-7b8a0bfe5365");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ce35595-8d01-4fcc-a62a-0ee788d265d7");

            migrationBuilder.AlterColumn<string>(
                name: "GameMasterId",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "UserSessions",
                columns: table => new
                {
                    UserIdsFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SessionIdsFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessions", x => new { x.SessionIdsFK, x.UserIdsFK });
                    table.ForeignKey(
                        name: "FK_UserSessions_AspNetUsers_UserIdsFK",
                        column: x => x.UserIdsFK,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSessions_Sessions_SessionIdsFK",
                        column: x => x.SessionIdsFK,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6298938a-f8ee-431c-a42f-df5dae37b4d5", "f05f781d-8c36-442c-a0fb-e5236935372f", "Player", "PLAYER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6beadb14-35e8-4e6a-a02d-35603c9f38bd", "a6c7e7eb-5a46-491e-a5b8-abec122f2732", "GameMaster", "GAMEMASTER" });

            migrationBuilder.CreateIndex(
                name: "IX_UserSessions_UserIdsFK",
                table: "UserSessions",
                column: "UserIdsFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSessions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6298938a-f8ee-431c-a42f-df5dae37b4d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6beadb14-35e8-4e6a-a02d-35603c9f38bd");

            migrationBuilder.AlterColumn<string>(
                name: "GameMasterId",
                table: "Sessions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d9b6151-d062-4fc1-a510-7b8a0bfe5365", "b088b3df-6158-4143-8c46-e515ca51a319", "GameMaster", "GAMEMASTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7ce35595-8d01-4fcc-a62a-0ee788d265d7", "addb9f6c-6c5c-4b73-a842-86851c185812", "Player", "PLAYER" });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_GameMasterId",
                table: "Sessions",
                column: "GameMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_AspNetUsers_GameMasterId",
                table: "Sessions",
                column: "GameMasterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
