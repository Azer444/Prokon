using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContentAccessComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Page = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Access1_AZ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Access1_RU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Access1_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Access1_TR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Access2_AZ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Access2_RU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Access2_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Access2_TR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Access3_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Access3_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Access3_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Access3_TR = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentAccessComponents", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "1a006d44-1c7e-4a38-ae16-15a822e28857");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "21a38ec2-0736-4b48-b97e-787817e26e91");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "513f7957-8869-4481-96f4-f4f83926cf84", "AQAAAAEAACcQAAAAEMsSEg5zgQk0oP5K2Z4w64ZEsO0KIWSKEBt0kTiOdDtS0Jb6qQ/iIlen/9yAOrMzzg==", "ae887f35-c529-4877-a02b-036d297887d3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentAccessComponents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "d45fe554-2768-4e9c-8588-8ee3038f8cc6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "443d9ae9-bf61-4d14-a7c6-927815a49861");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c28e1b6-38fd-4f1a-bd6c-b9d1200087b6", "AQAAAAEAACcQAAAAEHQIQAy9MMwRYuX1rjX22yQdGtLDxHjoJiIxpGkJHH0hFeszraAFEuKJ5W/52ukDGw==", "f284b17e-35a8-4418-87ae-64e8419bfea1" });
        }
    }
}
