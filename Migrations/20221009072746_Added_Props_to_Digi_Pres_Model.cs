using Microsoft.EntityFrameworkCore.Migrations;

namespace Neerogilksample.Migrations
{
    public partial class Added_Props_to_Digi_Pres_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Dosage1",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dosage2",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dosage3",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dosage4",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dosage5",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dosage6",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medicine1",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medicine2",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medicine3",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medicine4",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medicine5",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medicine6",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medides1",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medides2",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medides3",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medides4",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medides5",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medides6",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dosage1",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Dosage2",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Dosage3",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Dosage4",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Dosage5",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Dosage6",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Medicine1",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Medicine2",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Medicine3",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Medicine4",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Medicine5",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Medicine6",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Medides1",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Medides2",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Medides3",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Medides4",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Medides5",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Medides6",
                table: "DigitalPrescriptions");
        }
    }
}
