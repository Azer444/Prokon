using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class projectHomeOrderAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HomePageOrder",
                table: "Projects",
                type: "int",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomePageOrder",
                table: "Projects");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "d1ade149-81ab-48f4-a4c7-47a8f72e5df1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "0fa328d7-283d-4285-a192-92afb18af3d7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efb2a4c6-9a22-4aa7-9d41-f8abec184615", "AQAAAAEAACcQAAAAEFB+cuZHjwp/ckLanqY3vycGu2CyNNO5r/MDmGwoqr/o2+JTYM/2ZxI7cdCarTgg1Q==", "893f3303-ba38-480d-9984-9d2c1a15fd76" });
        }
    }
}
