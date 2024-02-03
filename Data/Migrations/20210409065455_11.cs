using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "NavTitleComponents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "NavTitleComponents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "54fa6174-2ea9-4aad-bf77-d4c5d5370aee");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "91459a58-781a-45a4-abd3-68c37690457d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ac5107a-f38c-4604-bf29-e595f949cbd9", "AQAAAAEAACcQAAAAEHEF8yZRJpNeN6ZbKzUH0dvPmx2QEnlebP+IPdGO7PpgOs1Enmu9Q4L1cPEJSF2Zsg==", "c988a007-8fff-493b-b95d-0067412d1ba2" });
        }
    }
}
