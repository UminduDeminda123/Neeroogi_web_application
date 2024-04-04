using Microsoft.EntityFrameworkCore.Migrations;

namespace Neerogilksample.Migrations
{
    public partial class AddedNewPropstoDigitalPrescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DrugProductCategory",
                table: "DigitalPrescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Mealperiod",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PatientAddress",
                table: "DigitalPrescriptions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PatientName",
                table: "DigitalPrescriptions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Seal",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Signature",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "DrugProductCategory",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Mealperiod",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "PatientAddress",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Seal",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Signature",
                table: "DigitalPrescriptions");
        }
    }
}
