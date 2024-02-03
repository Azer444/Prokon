using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServicesComponentPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServicesComponentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesComponentPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicesComponentPhotos_ServicesComponents_ServicesComponentId",
                        column: x => x.ServicesComponentId,
                        principalTable: "ServicesComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ServicesComponentPhotos_ServicesComponentId",
                table: "ServicesComponentPhotos",
                column: "ServicesComponentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicesComponentPhotos");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "3b02a0e0-99dd-4f6a-ae19-f32fd6d91638");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "5263a0da-74b0-4109-8e18-88bd806136e0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04afbf41-6d94-4f0f-9532-04c153f64541", "AQAAAAEAACcQAAAAEKoMizCZL8wLi3Sxi/FZuZmTyt0ENwZZ5AtxiXegcnjxgfYsO445y+fgQVwLpS84zA==", "d87af792-f9bb-4b59-b5d9-53b9cf51a6c4" });
        }
    }
}
