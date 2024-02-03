using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage_AZ",
                table: "CareerFormComponent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage_EN",
                table: "CareerFormComponent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage_RU",
                table: "CareerFormComponent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage_TR",
                table: "CareerFormComponent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SuccessMessage_AZ",
                table: "CareerFormComponent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SuccessMessage_EN",
                table: "CareerFormComponent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SuccessMessage_RU",
                table: "CareerFormComponent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SuccessMessage_TR",
                table: "CareerFormComponent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "OpportunityApplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpportunityId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpportunityApplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpportunityApplies_Opportunities_OpportunityId",
                        column: x => x.OpportunityId,
                        principalTable: "Opportunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpportunityApplyFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpportunityApplyId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpportunityApplyFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpportunityApplyFiles_OpportunityApplies_OpportunityApplyId",
                        column: x => x.OpportunityApplyId,
                        principalTable: "OpportunityApplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_OpportunityApplies_OpportunityId",
                table: "OpportunityApplies",
                column: "OpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_OpportunityApplyFiles_OpportunityApplyId",
                table: "OpportunityApplyFiles",
                column: "OpportunityApplyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpportunityApplyFiles");

            migrationBuilder.DropTable(
                name: "OpportunityApplies");

            migrationBuilder.DropColumn(
                name: "ErrorMessage_AZ",
                table: "CareerFormComponent");

            migrationBuilder.DropColumn(
                name: "ErrorMessage_EN",
                table: "CareerFormComponent");

            migrationBuilder.DropColumn(
                name: "ErrorMessage_RU",
                table: "CareerFormComponent");

            migrationBuilder.DropColumn(
                name: "ErrorMessage_TR",
                table: "CareerFormComponent");

            migrationBuilder.DropColumn(
                name: "SuccessMessage_AZ",
                table: "CareerFormComponent");

            migrationBuilder.DropColumn(
                name: "SuccessMessage_EN",
                table: "CareerFormComponent");

            migrationBuilder.DropColumn(
                name: "SuccessMessage_RU",
                table: "CareerFormComponent");

            migrationBuilder.DropColumn(
                name: "SuccessMessage_TR",
                table: "CareerFormComponent");

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
    }
}
