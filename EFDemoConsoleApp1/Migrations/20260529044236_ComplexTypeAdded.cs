using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDemoConsoleApp1.Migrations
{
    /// <inheritdoc />
    public partial class ComplexTypeAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_emp_Addresses_AddressID",
                table: "tbl_emp");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_tbl_emp_AddressID",
                table: "tbl_emp");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "tbl_emp");

            migrationBuilder.AddColumn<string>(
                name: "Address_Area",
                table: "tbl_emp",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "tbl_emp",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                table: "tbl_emp",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Line1",
                table: "tbl_emp",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Line2",
                table: "tbl_emp",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Pincode",
                table: "tbl_emp",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_Area",
                table: "tbl_emp");

            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "tbl_emp");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                table: "tbl_emp");

            migrationBuilder.DropColumn(
                name: "Address_Line1",
                table: "tbl_emp");

            migrationBuilder.DropColumn(
                name: "Address_Line2",
                table: "tbl_emp");

            migrationBuilder.DropColumn(
                name: "Address_Pincode",
                table: "tbl_emp");

            migrationBuilder.AddColumn<int>(
                name: "AddressID",
                table: "tbl_emp",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_emp_AddressID",
                table: "tbl_emp",
                column: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_emp_Addresses_AddressID",
                table: "tbl_emp",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
