using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGApp.Data.Migrations
{
    public partial class SessionChangesUserSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "c624adf5-4d19-45ea-9b52-29f1a4484f17", "c7a285a3-e8e9-41a0-a391-c97b73d05f71", "Player", "PLAYER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "edd7bb4a-46c2-487c-aaa3-ff7efe0b5ace", "8fad8932-2937-4b41-a002-87b4c9e2dfce", "GameMaster", "GAMEMASTER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c624adf5-4d19-45ea-9b52-29f1a4484f17");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edd7bb4a-46c2-487c-aaa3-ff7efe0b5ace");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7bfd2c7e-c311-4ba9-854b-2fac2f0590a5", "edf6112a-6ab6-4e08-bad6-8fce70269b81", "Player", "PLAYER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "af403712-d7a3-47c3-92d5-9ef7c55ddb07", "c8239a93-ac73-459a-aa09-210e86a5fadd", "GameMaster", "GAMEMASTER" });
        }
    }
}
