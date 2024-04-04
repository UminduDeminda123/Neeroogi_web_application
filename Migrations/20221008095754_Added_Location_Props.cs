using Microsoft.EntityFrameworkCore.Migrations;

namespace Neerogilksample.Migrations
{
    public partial class Added_Location_Props : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lattiude",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longtitude",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Lattiude",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Longtitude",
                table: "DigitalPrescriptions");
        }
    }
}
