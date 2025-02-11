using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wassandashboard.Migrations
{
    /// <inheritdoc />
    public partial class Intial_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Regions_projects_ProjectId",
                table: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Regions_ProjectId",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Regions");

            migrationBuilder.AddColumn<long>(
                name: "RegionID",
                table: "projects",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegionID",
                table: "projects");

            migrationBuilder.AddColumn<long>(
                name: "ProjectId",
                table: "Regions",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_ProjectId",
                table: "Regions",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_projects_ProjectId",
                table: "Regions",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id");
        }
    }
}
