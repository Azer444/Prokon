using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EthicsHotlineFormComponent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_AZ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_RU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_TR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field1_AZ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field1_RU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field1_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field1_TR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field2_AZ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field2_RU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field2_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field2_TR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field3_AZ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field3_RU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field3_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field3_TR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field4_AZ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field4_RU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field4_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field4_TR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonText_AZ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonText_RU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonText_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonText_TR = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EthicsHotlineFormComponent", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "235b064d-71a2-46c5-a914-c4c33385671b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "2fb8bb24-e662-465a-852d-0fe8e1364357");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1158ca0b-dbba-4b6b-b9a6-61a54e8ff7a9", "AQAAAAEAACcQAAAAEJ1+8Qc0CG4YW2VLFuaNjT4fNlsCnuafDs2O1uV5DMLbmeZE5qL+aru/b6/tEEw7kQ==", "84ff3476-4701-42ed-b6d6-9457c61d0483" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EthicsHotlineFormComponent");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "d5644de0-7c6e-4555-af92-3a2a7fc24e5b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "9e36f91c-693f-487d-bd59-c76ce61e0221");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7b04d49-e28f-4f9a-b5b2-231115082e69", "AQAAAAEAACcQAAAAED9yBkxayhY4hZVHuM1e7+vg0RTeSiNHesGmMq5u6lpBcVALlIZwRNZI6HGhZ/+BPw==", "bf3721fe-c2a2-41e7-8fc2-efa759961c92" });
        }
    }
}
