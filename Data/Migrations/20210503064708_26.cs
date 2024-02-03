using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoName",
                table: "ServicesComponents");

            migrationBuilder.AddColumn<int>(
                name: "CurrentOrder",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "d19777ca-3faf-469e-a2e1-606ac4ac09e9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "74b9f893-f4df-47b1-85c7-85c600a1853f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9996577-7e12-49e9-b3de-82e486e5ce9b", "AQAAAAEAACcQAAAAEEdX+R9NG78hoXrbjm3F03eVsJl5POc8IiF95ZPkIPBgbAliZZNiSFfcGNizYlw6bA==", "429db9bd-8242-44cd-b211-e52ed4fe1985" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentOrder",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "PhotoName",
                table: "ServicesComponents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "e7fa2b05-d422-419f-b3d3-46d0c6f840ec");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "b4494297-40e0-4186-a934-fbfdfc727096");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c637979-2119-4dfc-8484-cc0864164cde", "AQAAAAEAACcQAAAAEJ7PIvF2Hw8eWpMvMAXdKkfQHY3YM+bk7tZDJsGMblQHDmb2CXrabj3JrvUb/XiiHg==", "ef4823b4-c67a-44bf-95b9-78254e40e3ec" });
        }
    }
}
