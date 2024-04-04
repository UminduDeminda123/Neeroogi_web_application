using Microsoft.EntityFrameworkCore.Migrations;

namespace Neerogilksample.Migrations
{
    public partial class added_Props_to_DigitalPrescriptions_PharmacyUseremail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PharmacyUserEmail",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PharmacyUserEmail",
                table: "DigitalPrescriptions");
        }
    }
}
