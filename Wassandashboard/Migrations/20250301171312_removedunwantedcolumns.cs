using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wassandashboard.Migrations
{
    /// <inheritdoc />
    public partial class removedunwantedcolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "ContactPersonName",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "DonorName",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "LocationType",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "NoofTargetBeneficiaries",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "projects");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "projects",
                type: "varchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ContactPersonName",
                table: "projects",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DonorName",
                table: "projects",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "projects",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "projects",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LocationType",
                table: "projects",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "NoofTargetBeneficiaries",
                table: "projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "projects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
