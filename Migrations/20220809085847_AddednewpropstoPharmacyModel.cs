using Microsoft.EntityFrameworkCore.Migrations;

namespace Neerogilksample.Migrations
{
    public partial class AddednewpropstoPharmacyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerIdpicturebackURL",
                table: "Pharmacies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnerIdpicturefrontURL",
                table: "Pharmacies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnersLicenseIDPicture",
                table: "Pharmacies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PharmacyRegistrationCertificatePicture",
                table: "Pharmacies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerIdpicturebackURL",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "OwnerIdpicturefrontURL",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "OwnersLicenseIDPicture",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "PharmacyRegistrationCertificatePicture",
                table: "Pharmacies");
        }
    }
}
