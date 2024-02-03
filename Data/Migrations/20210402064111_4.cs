using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "7f7b25f8-c30d-4b9d-8bcd-68461adb83ae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "abfa8624-7bab-4d68-a7ff-7b3a54f52e63");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "401166a7-03f2-4b8f-81bb-ac2882cb66ac", "AQAAAAEAACcQAAAAEHSXJO72yuW+ERVxx8WN53p+poHLgkuV1q6mXmfcbG5N0A0FWXnczykbFqZPLTUzdg==", "ff28a038-2f92-4387-a5a4-3b5f7dc613fc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "News");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "492f9794-994f-4bdc-b337-4c7bf61b20b8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "e0e1bc9f-a56f-4dc4-a69a-541dfb5b78c0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc1d9210-a451-4e01-a43e-f117f89a2cae", "AQAAAAEAACcQAAAAEGJS+LZgd76KpAI9WJxnMXF3H0HHooXdjKD6MqTaVMTnTFu933ehu3Wz8qrw5YIkkQ==", "a32b125c-5919-4aad-a9e8-c768c79ff824" });
        }
    }
}
