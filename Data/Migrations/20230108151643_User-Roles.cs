using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGApp.Data.Migrations
{
    public partial class UserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b38e7747-f52a-4118-a37c-11ab7082725a", "6ecf3c3d-6824-454d-8084-d98fd3884c79", "Player", "PLAYER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fdc65f88-7c77-4a98-8e49-f861e022507a", "b0cde007-a196-4156-83f9-cc3b9fe75ca0", "GameMaster", "GAMEMASTER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b38e7747-f52a-4118-a37c-11ab7082725a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdc65f88-7c77-4a98-8e49-f861e022507a");
        }
    }
}
