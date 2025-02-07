using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wassandashboard.Migrations
{
    /// <inheritdoc />
    public partial class intial_2 : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Regions_ProjectId",
                table: "Regions",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_projects_ProjectId",
                table: "Regions",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
