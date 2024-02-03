using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SuccessMessage_AZ",
                table: "EthicsHotlineFormComponent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SuccessMessage_EN",
                table: "EthicsHotlineFormComponent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SuccessMessage_RU",
                table: "EthicsHotlineFormComponent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SuccessMessage_TR",
                table: "EthicsHotlineFormComponent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "2227b1b6-f074-4c20-bca2-ac038feb4b49");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "165634fe-2c8f-4cbf-9f00-bcaecac724d7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe5e633d-9eb4-41fd-8144-69feaee656ee", "AQAAAAEAACcQAAAAEGdBYMqz/nktdUV4R/0TrKG8sbrOXDXRQjc9j2XhnJCnwwKxfL0+7jHPxxNQKSUdJQ==", "f2329a20-58ec-482d-a700-7d6b5edad5bf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SuccessMessage_AZ",
                table: "EthicsHotlineFormComponent");

            migrationBuilder.DropColumn(
                name: "SuccessMessage_EN",
                table: "EthicsHotlineFormComponent");

            migrationBuilder.DropColumn(
                name: "SuccessMessage_RU",
                table: "EthicsHotlineFormComponent");

            migrationBuilder.DropColumn(
                name: "SuccessMessage_TR",
                table: "EthicsHotlineFormComponent");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "4e5671f6-57aa-473b-bc0d-ccf54a29d971");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "6d896179-74d2-49ac-845c-6e0db9b64a1f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29abd24b-b945-4937-862d-c0885a8e1dcd", "AQAAAAEAACcQAAAAEB5tFUycXRgT2wGVJWAZ6OLFSjuCu4yLXU7nyh1hIMfzxpPDfwy7kL9TyUKRn7sR7A==", "1bebcd2c-b38b-4851-bb74-a4502ef349d8" });
        }
    }
}
