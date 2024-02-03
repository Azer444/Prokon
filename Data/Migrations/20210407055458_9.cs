using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CareerAppContent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content_AZ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content_RU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content_TR = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerAppContent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CareerFormComponent",
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
                    Field5_AZ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field5_RU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field5_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field5_TR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonText_AZ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonText_RU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonText_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonText_TR = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerFormComponent", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "9aa97501-838b-4cb0-9786-ec5506581460");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "9293a424-d2f3-4fa0-b520-b2b23213db12");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afbb0744-3ebd-43f3-8513-2f739cec620c", "AQAAAAEAACcQAAAAEMer5CrRQpNJqvD2+7MybvBS0IvGMcCuoKiMWrJt32lusAgNe/GGRD6/ZF8fU2iWSQ==", "45c194dc-99ae-4a7a-a3c3-f15587857592" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CareerAppContent");

            migrationBuilder.DropTable(
                name: "CareerFormComponent");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "a2261541-ad68-48f5-b33c-89bad5dcfe2f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "5ab7a6b3-81e2-4d33-b109-3039965e3f74");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1087f61a-dd9f-4b89-afc0-bc7ac5266a3d", "AQAAAAEAACcQAAAAEB0uu3ILOpFwplUObmAc7DgsFMsRBhHnCNwf4+bQUJvgVniAn07oPgFZV+hRlD9hEA==", "19bcb1e8-bba2-4c27-a3f8-0c114e6cb81e" });
        }
    }
}
