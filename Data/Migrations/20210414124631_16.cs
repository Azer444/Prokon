using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneralApplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralApplies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneralApplyFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneralApplyId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralApplyFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralApplyFiles_GeneralApplies_GeneralApplyId",
                        column: x => x.GeneralApplyId,
                        principalTable: "GeneralApplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "d0865cdb-79ed-4482-9ddf-1ad96f6eba8c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "d03c8f03-fdcf-403f-b580-032712f864b9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "acb74036-e5ab-454d-afd6-7847d726fc0b", "AQAAAAEAACcQAAAAENpx2xLq24fvEt4V+ZxrMNmFUIGBO7+LGEGxZpEHaGlRzR9WIqOKYSymGJkzkkem/Q==", "74cc6013-9600-47f2-882c-212a5c4faa57" });

            migrationBuilder.CreateIndex(
                name: "IX_GeneralApplyFiles_GeneralApplyId",
                table: "GeneralApplyFiles",
                column: "GeneralApplyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralApplyFiles");

            migrationBuilder.DropTable(
                name: "GeneralApplies");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "3709a511-237e-44d1-b2b5-5cec7955f219");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "89e812fe-893e-42ee-ab4b-c368714a6454");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20844a37-2d4f-4434-bc06-4779837a85e5", "AQAAAAEAACcQAAAAEEV+Hx3ERpvOqz16Dw4THj1x5TjsS/XOGWrCe8CF0o5Fj3muad6pAnWZto9IYxsXQA==", "f5a3a610-d9f5-45fa-a42e-54c3abb19ae8" });
        }
    }
}
