using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "621876a0-158d-486f-afbe-4fa5d79575ce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "1f81195d-0a0c-4d11-88ff-9edd0838ab3d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48jw043d-53ke-d830-dk21-394fje93jd92",
                column: "ConcurrencyStamp",
                value: "1e288b23-d8ab-4610-a0d0-64920eb87b87");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ekc3dr5-3kds-3910-93js-49d4kw024kd9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6275c33d-8eb4-4b17-a781-78ff11e78140", "AQAAAAEAACcQAAAAEDRLR6zZ1+jOVViiZdfls9+wIGYGJwJjwK+EkrM4BWJmmjjadKXFLhmBArFHFkq8eg==", "85c4fb7a-2761-43c6-a05f-58084ca34a69" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af4314a3-fba5-42df-928e-42774f89c251", "AQAAAAEAACcQAAAAEKOe2dVCBs1mFmDjo3gSrmNdiELqrEzfSm+ooYhqEf7g/PgnC5EFLfMJNqp3V1cvyw==", "3f84da7c-d71b-437c-b2c1-5b648cada112" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
