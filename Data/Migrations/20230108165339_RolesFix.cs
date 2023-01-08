using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGApp.Data.Migrations
{
    public partial class RolesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b38e7747-f52a-4118-a37c-11ab7082725a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdc65f88-7c77-4a98-8e49-f861e022507a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d9b6151-d062-4fc1-a510-7b8a0bfe5365", "b088b3df-6158-4143-8c46-e515ca51a319", "GameMaster", "GAMEMASTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7ce35595-8d01-4fcc-a62a-0ee788d265d7", "addb9f6c-6c5c-4b73-a842-86851c185812", "Player", "PLAYER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d9b6151-d062-4fc1-a510-7b8a0bfe5365");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ce35595-8d01-4fcc-a62a-0ee788d265d7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b38e7747-f52a-4118-a37c-11ab7082725a", "6ecf3c3d-6824-454d-8084-d98fd3884c79", "Player", "PLAYER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fdc65f88-7c77-4a98-8e49-f861e022507a", "b0cde007-a196-4156-83f9-cc3b9fe75ca0", "GameMaster", "GAMEMASTER" });
        }
    }
}
