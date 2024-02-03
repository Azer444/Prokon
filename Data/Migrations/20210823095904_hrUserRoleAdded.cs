using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class hrUserRoleAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "ab8ab642-885d-4370-ae76-fb7c5d225ae7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "b61aa323-6699-4b80-b2f6-0703834bfd21");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48jw043d-53ke-d830-dk21-394fje93jd92",
                column: "ConcurrencyStamp",
                value: "f02c1f79-8780-4945-9823-3f38fd7eae31");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "48jw043d-53ke-d830-dk21-394fje93jd92", "3ekc3dr5-3kds-3910-93js-49d4kw024kd9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ekc3dr5-3kds-3910-93js-49d4kw024kd9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c53f64e-57b5-46c4-b180-3602356cafaa", "AQAAAAEAACcQAAAAEGmqtacMKWDI7NIi0A0tuL5J8X910w0XZgjvPUiuwgezLmHevkJ/ZAv1Iaf9MHQ8dA==", "841d0c21-d92b-48bf-af54-84549626962d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed450715-3c78-47d4-9731-7844950edbcf", "AQAAAAEAACcQAAAAEH56uClMAHagTkg7sM/7yXIbIiTBU6JwWXleQFXaVloOLqAWiwV9hfik5qI3A/BNcA==", "662de239-ce4f-4e03-82d6-fa3efd3d13b4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "48jw043d-53ke-d830-dk21-394fje93jd92", "3ekc3dr5-3kds-3910-93js-49d4kw024kd9" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "1d4f819a-566e-489f-909c-b4b84205f829");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "e44f3382-d333-4559-9b7f-0b85657f9bc8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48jw043d-53ke-d830-dk21-394fje93jd92",
                column: "ConcurrencyStamp",
                value: "2eb06bce-d45f-42f1-8544-ef753f50a56b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ekc3dr5-3kds-3910-93js-49d4kw024kd9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3a3a2e0-82da-41e1-aef4-b103e86bb3d6", "AQAAAAEAACcQAAAAEGAwr57LdAjSebfR3ca4bkworlCTGdn3Zj/JGyMU2eLdKUg0KmUFr6u8dG/Ic+DNTA==", "1c79dc52-fd7f-43ed-a0f3-709c552c894f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7a06cc1-f71c-4f9c-9bd8-cc393f4395c8", "AQAAAAEAACcQAAAAEE19prI/RGhpdXLk/2kUOcU66jdhsr8EoPGJxDN/P3Xnc2DNZ4W9UlhPsfXpamBHYg==", "7fce09e8-7df4-448e-9c2f-f5957136a27e" });
        }
    }
}
