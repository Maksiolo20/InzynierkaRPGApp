using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGApp.Data.Migrations
{
    public partial class TestAfterReset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6298938a-f8ee-431c-a42f-df5dae37b4d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6beadb14-35e8-4e6a-a02d-35603c9f38bd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7bfd2c7e-c311-4ba9-854b-2fac2f0590a5", "edf6112a-6ab6-4e08-bad6-8fce70269b81", "Player", "PLAYER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "af403712-d7a3-47c3-92d5-9ef7c55ddb07", "c8239a93-ac73-459a-aa09-210e86a5fadd", "GameMaster", "GAMEMASTER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bfd2c7e-c311-4ba9-854b-2fac2f0590a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af403712-d7a3-47c3-92d5-9ef7c55ddb07");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6298938a-f8ee-431c-a42f-df5dae37b4d5", "f05f781d-8c36-442c-a0fb-e5236935372f", "Player", "PLAYER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6beadb14-35e8-4e6a-a02d-35603c9f38bd", "a6c7e7eb-5a46-491e-a5b8-abec122f2732", "GameMaster", "GAMEMASTER" });
        }
    }
}
