using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class hrUserAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "1d4f819a-566e-489f-909c-b4b84205f829");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "e44f3382-d333-4559-9b7f-0b85657f9bc8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "48jw043d-53ke-d830-dk21-394fje93jd92", "2eb06bce-d45f-42f1-8544-ef753f50a56b", "HR", "HR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7a06cc1-f71c-4f9c-9bd8-cc393f4395c8", "AQAAAAEAACcQAAAAEE19prI/RGhpdXLk/2kUOcU66jdhsr8EoPGJxDN/P3Xnc2DNZ4W9UlhPsfXpamBHYg==", "7fce09e8-7df4-448e-9c2f-f5957136a27e" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3ekc3dr5-3kds-3910-93js-49d4kw024kd9", 0, "b3a3a2e0-82da-41e1-aef4-b103e86bb3d6", null, false, false, null, null, "PROKON_HR", "AQAAAAEAACcQAAAAEGAwr57LdAjSebfR3ca4bkworlCTGdn3Zj/JGyMU2eLdKUg0KmUFr6u8dG/Ic+DNTA==", null, false, "1c79dc52-fd7f-43ed-a0f3-709c552c894f", false, "prokon_hr" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48jw043d-53ke-d830-dk21-394fje93jd92");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ekc3dr5-3kds-3910-93js-49d4kw024kd9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "187a88df-5058-4bf9-9d2d-10c207d0dc8d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "c647ce8f-f8fe-4454-a128-a2af9d088914");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9559ce15-829c-411f-8c97-8261c7808c8d", "AQAAAAEAACcQAAAAEHmfcFngYl/XZtoBrsFp5MOP5+IWhNKFwxlKAS2M9So7ecgS71i5M7FuRHeDK1uh7Q==", "1ecb5ceb-442a-4ca3-9c54-2d6d71ee63d7" });
        }
    }
}
