using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage_AZ",
                table: "EthicsHotlineFormComponent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage_EN",
                table: "EthicsHotlineFormComponent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage_RU",
                table: "EthicsHotlineFormComponent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage_TR",
                table: "EthicsHotlineFormComponent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "04c6352e-ff07-4345-a641-0e0f61cbe13d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "9804836a-91be-4d03-99e0-4d8f284b6ae4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92b22082-7f62-4141-bccb-4f5dd585c48d", "AQAAAAEAACcQAAAAEM0zgjIJMzeWlSL7fSXszWxotuWrm92gRqjt2SIrZokUpuIad4SkzsWUkS7qFw+UMw==", "337a1c31-b6d3-4989-be91-aa6877cee091" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ErrorMessage_AZ",
                table: "EthicsHotlineFormComponent");

            migrationBuilder.DropColumn(
                name: "ErrorMessage_EN",
                table: "EthicsHotlineFormComponent");

            migrationBuilder.DropColumn(
                name: "ErrorMessage_RU",
                table: "EthicsHotlineFormComponent");

            migrationBuilder.DropColumn(
                name: "ErrorMessage_TR",
                table: "EthicsHotlineFormComponent");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "9042e2ee-0f7a-428f-a6d1-a4e5e52d6de3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "7f433d9b-4f22-4506-9a90-c33b46026188");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d14d22ca-1d52-41e4-86fa-0421eec4af30", "AQAAAAEAACcQAAAAEILBGD/MsOkD0a2E4L3FuU3Oer2ecOOn3GrnnuRDa6q8icRwCNruwray1F6Udy++FA==", "a057a20d-1392-42dc-bef5-80f0326d8667" });
        }
    }
}
