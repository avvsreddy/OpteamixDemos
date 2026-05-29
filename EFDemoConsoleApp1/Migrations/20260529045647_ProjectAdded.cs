using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDemoConsoleApp1.Migrations
{
    /// <inheritdoc />
    public partial class ProjectAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectID",
                table: "tbl_emp",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Client = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_emp_ProjectID",
                table: "tbl_emp",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_emp_Projects_ProjectID",
                table: "tbl_emp",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_emp_Projects_ProjectID",
                table: "tbl_emp");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_tbl_emp_ProjectID",
                table: "tbl_emp");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "tbl_emp");
        }
    }
}
