using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ButtonText_AZ",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ButtonText_EN",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ButtonText_RU",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ButtonText_TR",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Client_AZ",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Client_EN",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Client_RU",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Client_TR",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Contractor_AZ",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Contractor_EN",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Contractor_RU",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Contractor_TR",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Owner_AZ",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Owner_EN",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Owner_RU",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Owner_TR",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "SubContractor_AZ",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "SubContractor_EN",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "SubContractor_RU",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "SubContractor_TR",
                table: "Projects");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "08a6ede5-a840-4c3a-a4d0-a3a72c9b6eb1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "80ed3f94-ff71-4f4f-8c75-c1f8c2b05d54");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f064622-7fdc-4da3-9e93-2ae6b2cf9586", "AQAAAAEAACcQAAAAELEq9Kd3PMRnr38i2DTQO2zTUlsnFFTosm3fW77iFM84NBQJJGN90L12dimKAHOnUg==", "86a8a20d-ebc8-40f2-846c-f265f1ae77ca" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ButtonText_AZ",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ButtonText_EN",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ButtonText_RU",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ButtonText_TR",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Client_AZ",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Client_EN",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Client_RU",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Client_TR",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contractor_AZ",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contractor_EN",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contractor_RU",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contractor_TR",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Owner_AZ",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Owner_EN",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Owner_RU",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Owner_TR",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubContractor_AZ",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubContractor_EN",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubContractor_RU",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubContractor_TR",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "194e46d6-46d1-4a13-8d50-53cac9535a8a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "cbf773c5-8fea-4b42-80b7-17f6c83859dd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e64f67ff-efc9-462c-a510-4de8831378e0", "AQAAAAEAACcQAAAAEJNXwUJFZfk0r6V5tkhlCjgre6Z3q8+DpkNNrHVYKevP4SHIkj/EcnKsMTjH/wCpRw==", "78ea3682-65ac-4601-ac28-0c816467bbf8" });
        }
    }
}
