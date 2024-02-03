using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "efd0191d-c034-4b47-b2f0-b3da5b71648b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "2e6e0260-caac-481f-8fe9-bee723658f13");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d4f9a06-c6c7-44a4-baf0-30937f9e709a", "AQAAAAEAACcQAAAAEDM8RCZqTahDuC7u40t/cjZFqBRyxpZbMuwHkYsKguQ+N7QRFqxtDEeoFsIYQr0goA==", "b370d30e-95dd-4f75-acce-91113d830293" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "7d6e2a3a-3c3c-432e-8726-733ec60145f6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "e9d9336c-1e68-4116-8d63-8bfb1865b6f5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed0c3e94-a03b-429b-933a-9b47fde57904", "AQAAAAEAACcQAAAAEF077ZChueBUrrP4Q/PwQc6q6ojCXyEii4TjuBtWq5UIMjAIRyfGgOW022v54FrGuw==", "cb0a6d4e-b76a-4155-a2a0-3dbc84bb26f7" });
        }
    }
}
