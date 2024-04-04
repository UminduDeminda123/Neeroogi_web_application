using Microsoft.EntityFrameworkCore.Migrations;

namespace Neerogilksample.Migrations
{
    public partial class AddednewPropstoAppliationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DPersonConfirmEmail",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DPersonConfirmPassword",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DPersonEmailAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DPersonPassword",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryPersonFirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryPersonLastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorConfirmEmail",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorConfirmPassword",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorEmailAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorFirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorLastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorPassword",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PharamcyEmailAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PharmacyConfirmEmail",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PharmacyConfirmPassword",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PharmacyName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PharmacyOwnerName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PharmacyPassword",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DPersonConfirmEmail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DPersonConfirmPassword",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DPersonEmailAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DPersonPassword",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeliveryPersonFirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeliveryPersonLastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DoctorConfirmEmail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DoctorConfirmPassword",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DoctorEmailAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DoctorFirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DoctorLastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DoctorPassword",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PharamcyEmailAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PharmacyConfirmEmail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PharmacyConfirmPassword",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PharmacyName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PharmacyOwnerName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PharmacyPassword",
                table: "AspNetUsers");
        }
    }
}
