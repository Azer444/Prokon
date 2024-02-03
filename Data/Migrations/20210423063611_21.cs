using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "GalleryComponents",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_GalleryComponents_ProjectId",
                table: "GalleryComponents",
                column: "ProjectId",
                unique: true,
                filter: "[ProjectId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryComponents_Projects_ProjectId",
                table: "GalleryComponents",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GalleryComponents_Projects_ProjectId",
                table: "GalleryComponents");

            migrationBuilder.DropIndex(
                name: "IX_GalleryComponents_ProjectId",
                table: "GalleryComponents");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "GalleryComponents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "0839840b-a510-4cbd-b745-2264772ecf65");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "0911c2f9-c393-4fe9-847d-c0ea92fd26c6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf15693a-7167-4ca1-86c0-6a919815e514", "AQAAAAEAACcQAAAAEMuUjsaIAgFMpCxJdpa2Hkx5hhMFWjCAjgYIQOxnZ81QjEwuYYgHBQMLyyDcuUoLWg==", "a166b316-c258-4a79-a783-3955e1ba8ce9" });
        }
    }
}
