using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indiv.Uppgiftv2.Migrations
{
    /// <inheritdoc />
    public partial class removerole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Customers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 1001,
                column: "Username",
                value: "AA1001");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 1002,
                column: "Username",
                value: "BA1002");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "EFirstName", "ELastName", "EPassWord", "UserName" },
                values: new object[] { 1001, "Admin", "AdminLastName", "123Password", "Admin1001" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1001);

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Customers");
        }
    }
}
