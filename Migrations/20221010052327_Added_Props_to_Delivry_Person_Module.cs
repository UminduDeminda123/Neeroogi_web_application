using Microsoft.EntityFrameworkCore.Migrations;

namespace Neerogilksample.Migrations
{
    public partial class Added_Props_to_Delivry_Person_Module : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WhatsAppNumber",
                table: "DeliveryPersons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "appointedPharmacyEmail",
                table: "DeliveryPersons",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WhatsAppNumber",
                table: "DeliveryPersons");

            migrationBuilder.DropColumn(
                name: "appointedPharmacyEmail",
                table: "DeliveryPersons");
        }
    }
}
