using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDemoConsoleApp1.Migrations
{
    /// <inheritdoc />
    public partial class TPC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DesktopProjects_Projects_ProjectID",
                table: "DesktopProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_MobileProjects_Projects_ProjectID",
                table: "MobileProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_emp_Projects_ProjectID",
                table: "tbl_emp");

            migrationBuilder.DropForeignKey(
                name: "FK_WebProjects_Projects_ProjectID",
                table: "WebProjects");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.CreateSequence(
                name: "ProjectSequence");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "WebProjects",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR [ProjectSequence]",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "WebProjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "WebProjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "MobileProjects",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR [ProjectSequence]",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "MobileProjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MobileProjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "DesktopProjects",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR [ProjectSequence]",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "DesktopProjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DesktopProjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Client",
                table: "WebProjects");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "WebProjects");

            migrationBuilder.DropColumn(
                name: "Client",
                table: "MobileProjects");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MobileProjects");

            migrationBuilder.DropColumn(
                name: "Client",
                table: "DesktopProjects");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DesktopProjects");

            migrationBuilder.DropSequence(
                name: "ProjectSequence");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "WebProjects",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR [ProjectSequence]");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "MobileProjects",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR [ProjectSequence]");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "DesktopProjects",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR [ProjectSequence]");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DesktopProjects_Projects_ProjectID",
                table: "DesktopProjects",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MobileProjects_Projects_ProjectID",
                table: "MobileProjects",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_emp_Projects_ProjectID",
                table: "tbl_emp",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WebProjects_Projects_ProjectID",
                table: "WebProjects",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
