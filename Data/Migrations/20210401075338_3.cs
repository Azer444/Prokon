using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "ServicesComponents");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "ServicesComponents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "1a006d44-1c7e-4a38-ae16-15a822e28857");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "21a38ec2-0736-4b48-b97e-787817e26e91");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "513f7957-8869-4481-96f4-f4f83926cf84", "AQAAAAEAACcQAAAAEMsSEg5zgQk0oP5K2Z4w64ZEsO0KIWSKEBt0kTiOdDtS0Jb6qQ/iIlen/9yAOrMzzg==", "ae887f35-c529-4877-a02b-036d297887d3" });
        }
    }
}
