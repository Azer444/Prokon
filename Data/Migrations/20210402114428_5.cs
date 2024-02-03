using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug_AZ",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Slug_EN",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Slug_RU",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "Slug_TR",
                table: "Projects",
                newName: "Slug");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "5b45cc59-15ef-44ce-9a12-58c901dcc2a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "ef3d7229-abe3-45df-93da-a7770b94bd47");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59bbbb9c-973d-4a22-b981-c72f1785f11a", "AQAAAAEAACcQAAAAEFlwGMG8ovrx1o6jVNFSeJyrVW46dtZenKzMNjXr+NQD47Y5+gr+PcDn8erumcbfPA==", "66c5798f-a9be-4f5b-84ad-742792840043" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "Projects",
                newName: "Slug_TR");

            migrationBuilder.AddColumn<string>(
                name: "Slug_AZ",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Slug_EN",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Slug_RU",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "News",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
