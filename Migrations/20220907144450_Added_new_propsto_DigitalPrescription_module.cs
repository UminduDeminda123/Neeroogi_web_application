using Microsoft.EntityFrameworkCore.Migrations;

namespace Neerogilksample.Migrations
{
    public partial class Added_new_propsto_DigitalPrescription_module : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "DigitalPrescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserDoctorId",
                table: "DigitalPrescriptions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DigitalPrescriptions_UserDoctorId",
                table: "DigitalPrescriptions",
                column: "UserDoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DigitalPrescriptions_AspNetUsers_UserDoctorId",
                table: "DigitalPrescriptions",
                column: "UserDoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DigitalPrescriptions_AspNetUsers_UserDoctorId",
                table: "DigitalPrescriptions");

            migrationBuilder.DropIndex(
                name: "IX_DigitalPrescriptions_UserDoctorId",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "DigitalPrescriptions");

            migrationBuilder.DropColumn(
                name: "UserDoctorId",
                table: "DigitalPrescriptions");
        }
    }
}
