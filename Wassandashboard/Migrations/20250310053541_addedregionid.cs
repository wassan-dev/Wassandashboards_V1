using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wassandashboard.Migrations
{
    /// <inheritdoc />
    public partial class addedregionid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectRegions_projects_ProjectId",
                table: "ProjectRegions");

            migrationBuilder.DropIndex(
                name: "IX_ProjectRegions_ProjectId",
                table: "ProjectRegions");

            migrationBuilder.AddColumn<long>(
                name: "RegionsId",
                table: "ProjectRegions",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRegions_RegionsId",
                table: "ProjectRegions",
                column: "RegionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectRegions_projects_RegionsId",
                table: "ProjectRegions",
                column: "RegionsId",
                principalTable: "projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectRegions_projects_RegionsId",
                table: "ProjectRegions");

            migrationBuilder.DropIndex(
                name: "IX_ProjectRegions_RegionsId",
                table: "ProjectRegions");

            migrationBuilder.DropColumn(
                name: "RegionsId",
                table: "ProjectRegions");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRegions_ProjectId",
                table: "ProjectRegions",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectRegions_projects_ProjectId",
                table: "ProjectRegions",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
