﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Neerogilksample.Data;

namespace Neerogilksample.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220809092226_addedDescriptionProptoPharmacyModel")]
    partial class addedDescriptionProptoPharmacyModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Neerogilksample.Models.DeliveryPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("EmergencyContactNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("IdpicturebackURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdpicturefrontURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LicenseBackPictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicenseFrontPictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIC")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("PoliceReportsURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReceivedDateLicense")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("DeliveryPersons");
                });

            modelBuilder.Entity("Neerogilksample.Models.DeliveryPerson_Pharmacy", b =>
                {
                    b.Property<int>("DeliveryPersonId")
                        .HasColumnType("int");

                    b.Property<int>("PharmacyId")
                        .HasColumnType("int");

                    b.HasKey("DeliveryPersonId", "PharmacyId");

                    b.HasIndex("PharmacyId");

                    b.ToTable("DeliveryPersonsPharmacies");
                });

            modelBuilder.Entity("Neerogilksample.Models.DigitalPrescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Dateofissue")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("DrugProductCategory")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mealperiod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Seal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Signature")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("DigitalPrescriptions");
                });

            modelBuilder.Entity("Neerogilksample.Models.DigitalPrescription_Pharmacy", b =>
                {
                    b.Property<int>("DigitalPrescriptionId")
                        .HasColumnType("int");

                    b.Property<int>("PharmacyId")
                        .HasColumnType("int");

                    b.HasKey("DigitalPrescriptionId", "PharmacyId");

                    b.HasIndex("PharmacyId");

                    b.ToTable("DigitalPrescriptionsPharmacies");
                });

            modelBuilder.Entity("Neerogilksample.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Degree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DegreeSpecialization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmergencyContactNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GraduatedUniversity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GraduatedYear")
                        .HasColumnType("int");

                    b.Property<string>("IdpicturebackURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdpicturefrontURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NIC")
                        .HasColumnType("int");

                    b.Property<string>("OfficialIDBackPictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfficialIDFrontPictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SpecialReportsURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VerifiedCertificateURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Neerogilksample.Models.Doctor_Pharmacy", b =>
                {
                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PharmacyId")
                        .HasColumnType("int");

                    b.HasKey("DoctorId", "PharmacyId");

                    b.HasIndex("PharmacyId");

                    b.ToTable("DoctorsPharmacies");
                });

            modelBuilder.Entity("Neerogilksample.Models.GeneralMedicineProducts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DigitalPrescriptionId")
                        .HasColumnType("int");

                    b.Property<int>("DrugProductCategory")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ManufacturedCompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ManufacturedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProductPictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DigitalPrescriptionId");

                    b.ToTable("GeneralMedicineProducts");
                });

            modelBuilder.Entity("Neerogilksample.Models.GeneralMedicines", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrugProductCategory")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ManufacturedCompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ManufacturedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProductPictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GeneralMedicines");
                });

            modelBuilder.Entity("Neerogilksample.Models.Pharmacy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmergencyContactNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("GeoCoordinatesGoogleLocation")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OwnerFullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OwnerIdpicturebackURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerIdpicturefrontURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OwnersLicenseIDPicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnersNIC")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PharmacyAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PharmacyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PharmacyRegisteredNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PharmacyRegistrationCertificatePicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PharmacyRegistrationNumber")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationDate")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Pharmacies");
                });

            modelBuilder.Entity("Neerogilksample.Models.DeliveryPerson_Pharmacy", b =>
                {
                    b.HasOne("Neerogilksample.Models.DeliveryPerson", "DeliveryPerson")
                        .WithMany("DeliveryPersons_Pharmacies")
                        .HasForeignKey("DeliveryPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Neerogilksample.Models.Pharmacy", "Pharmacy")
                        .WithMany("DeliveryPersons_Pharmacies")
                        .HasForeignKey("PharmacyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryPerson");

                    b.Navigation("Pharmacy");
                });

            modelBuilder.Entity("Neerogilksample.Models.DigitalPrescription", b =>
                {
                    b.HasOne("Neerogilksample.Models.Doctor", "Doctor")
                        .WithMany("DigitalPrescriptions")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Neerogilksample.Models.DigitalPrescription_Pharmacy", b =>
                {
                    b.HasOne("Neerogilksample.Models.DigitalPrescription", "DigitalPrescription")
                        .WithMany("DigitalPrescriptons_Pharmacies")
                        .HasForeignKey("DigitalPrescriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Neerogilksample.Models.Pharmacy", "Pharmacy")
                        .WithMany("DigitalPrescriptons_Pharmacies")
                        .HasForeignKey("PharmacyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DigitalPrescription");

                    b.Navigation("Pharmacy");
                });

            modelBuilder.Entity("Neerogilksample.Models.Doctor_Pharmacy", b =>
                {
                    b.HasOne("Neerogilksample.Models.Doctor", "Doctor")
                        .WithMany("Doctors_Pharmacies")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Neerogilksample.Models.Pharmacy", "Pharmacy")
                        .WithMany("Doctors_Pharmacies")
                        .HasForeignKey("PharmacyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Pharmacy");
                });

            modelBuilder.Entity("Neerogilksample.Models.GeneralMedicineProducts", b =>
                {
                    b.HasOne("Neerogilksample.Models.DigitalPrescription", "DigitalPrescription")
                        .WithMany("GeneralMedicinesProducts")
                        .HasForeignKey("DigitalPrescriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DigitalPrescription");
                });

            modelBuilder.Entity("Neerogilksample.Models.DeliveryPerson", b =>
                {
                    b.Navigation("DeliveryPersons_Pharmacies");
                });

            modelBuilder.Entity("Neerogilksample.Models.DigitalPrescription", b =>
                {
                    b.Navigation("DigitalPrescriptons_Pharmacies");

                    b.Navigation("GeneralMedicinesProducts");
                });

            modelBuilder.Entity("Neerogilksample.Models.Doctor", b =>
                {
                    b.Navigation("DigitalPrescriptions");

                    b.Navigation("Doctors_Pharmacies");
                });

            modelBuilder.Entity("Neerogilksample.Models.Pharmacy", b =>
                {
                    b.Navigation("DeliveryPersons_Pharmacies");

                    b.Navigation("DigitalPrescriptons_Pharmacies");

                    b.Navigation("Doctors_Pharmacies");
                });
#pragma warning restore 612, 618
        }
    }
}
