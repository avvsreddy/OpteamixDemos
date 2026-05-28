using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDemoConsoleApp1.Migrations
{
    /// <inheritdoc />
    public partial class TableNameChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "tbl_emp");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "tbl_emp",
                newName: "EmpId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "tbl_emp",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Designation",
                table: "tbl_emp",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_emp",
                table: "tbl_emp",
                column: "EmpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_emp",
                table: "tbl_emp");

            migrationBuilder.RenameTable(
                name: "tbl_emp",
                newName: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmpId",
                table: "Employees",
                newName: "EmployeeId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Designation",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeId");
        }
    }
}
