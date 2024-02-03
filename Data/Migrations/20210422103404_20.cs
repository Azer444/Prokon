using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "HomeSliderComponents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "0839840b-a510-4cbd-b745-2264772ecf65");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "0911c2f9-c393-4fe9-847d-c0ea92fd26c6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf15693a-7167-4ca1-86c0-6a919815e514", "AQAAAAEAACcQAAAAEMuUjsaIAgFMpCxJdpa2Hkx5hhMFWjCAjgYIQOxnZ81QjEwuYYgHBQMLyyDcuUoLWg==", "a166b316-c258-4a79-a783-3955e1ba8ce9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "HomeSliderComponents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "08a6ede5-a840-4c3a-a4d0-a3a72c9b6eb1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "80ed3f94-ff71-4f4f-8c75-c1f8c2b05d54");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f064622-7fdc-4da3-9e93-2ae6b2cf9586", "AQAAAAEAACcQAAAAELEq9Kd3PMRnr38i2DTQO2zTUlsnFFTosm3fW77iFM84NBQJJGN90L12dimKAHOnUg==", "86a8a20d-ebc8-40f2-846c-f265f1ae77ca" });
        }
    }
}
