using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDemoConsoleApp1.Migrations
{
    /// <inheritdoc />
    public partial class TPT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "OS",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Plotform",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "WebUrl",
                table: "Projects");

            migrationBuilder.CreateTable(
                name: "DesktopProjects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    OS = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesktopProjects", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_DesktopProjects_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MobileProjects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    Plotform = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileProjects", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_MobileProjects_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WebProjects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    WebUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebProjects", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_WebProjects_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesktopProjects");

            migrationBuilder.DropTable(
                name: "MobileProjects");

            migrationBuilder.DropTable(
                name: "WebProjects");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Projects",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OS",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plotform",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebUrl",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
