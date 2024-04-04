using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Neerogilksample.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryPersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePictureURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdpicturefrontURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdpicturebackURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseFrontPictureURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseBackPictureURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliceReportsURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    EmergencyContactNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    NIC = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ReceivedDateLicense = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryPersons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePictureURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdpicturefrontURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdpicturebackURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficialIDFrontPictureURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficialIDBackPictureURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedCertificateURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialReportsURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    EmergencyContactNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NIC = table.Column<int>(type: "int", nullable: false),
                    GraduatedUniversity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GraduatedYear = table.Column<int>(type: "int", nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DegreeSpecialization = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PharmacyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PharmacyRegistrationNumber = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    OwnerFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OwnerLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OwnerFullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OwnersNIC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PharmacyRegisteredNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    District = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GeoCoordinatesGoogleLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    EmergencyContactNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DigitalPrescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Dateofissue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DigitalPrescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DigitalPrescriptions_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryPersonsPharmacies",
                columns: table => new
                {
                    DeliveryPersonId = table.Column<int>(type: "int", nullable: false),
                    PharmacyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryPersonsPharmacies", x => new { x.DeliveryPersonId, x.PharmacyId });
                    table.ForeignKey(
                        name: "FK_DeliveryPersonsPharmacies_DeliveryPersons_DeliveryPersonId",
                        column: x => x.DeliveryPersonId,
                        principalTable: "DeliveryPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryPersonsPharmacies_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorsPharmacies",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PharmacyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorsPharmacies", x => new { x.DoctorId, x.PharmacyId });
                    table.ForeignKey(
                        name: "FK_DoctorsPharmacies_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorsPharmacies_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DigitalPrescriptionsPharmacies",
                columns: table => new
                {
                    DigitalPrescriptionId = table.Column<int>(type: "int", nullable: false),
                    PharmacyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DigitalPrescriptionsPharmacies", x => new { x.DigitalPrescriptionId, x.PharmacyId });
                    table.ForeignKey(
                        name: "FK_DigitalPrescriptionsPharmacies_DigitalPrescriptions_DigitalPrescriptionId",
                        column: x => x.DigitalPrescriptionId,
                        principalTable: "DigitalPrescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DigitalPrescriptionsPharmacies_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneralMedicineProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductPictureURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ManufacturedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ManufacturedCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrugProductCategory = table.Column<int>(type: "int", nullable: false),
                    DigitalPrescriptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralMedicineProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralMedicineProducts_DigitalPrescriptions_DigitalPrescriptionId",
                        column: x => x.DigitalPrescriptionId,
                        principalTable: "DigitalPrescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryPersonsPharmacies_PharmacyId",
                table: "DeliveryPersonsPharmacies",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_DigitalPrescriptions_DoctorId",
                table: "DigitalPrescriptions",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DigitalPrescriptionsPharmacies_PharmacyId",
                table: "DigitalPrescriptionsPharmacies",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorsPharmacies_PharmacyId",
                table: "DoctorsPharmacies",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralMedicineProducts_DigitalPrescriptionId",
                table: "GeneralMedicineProducts",
                column: "DigitalPrescriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryPersonsPharmacies");

            migrationBuilder.DropTable(
                name: "DigitalPrescriptionsPharmacies");

            migrationBuilder.DropTable(
                name: "DoctorsPharmacies");

            migrationBuilder.DropTable(
                name: "GeneralMedicineProducts");

            migrationBuilder.DropTable(
                name: "DeliveryPersons");

            migrationBuilder.DropTable(
                name: "Pharmacies");

            migrationBuilder.DropTable(
                name: "DigitalPrescriptions");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
