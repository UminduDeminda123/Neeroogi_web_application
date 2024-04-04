using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Neerogilksample.Migrations
{
    public partial class Added_all_the_new_values_to_Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "unit6",
                table: "Orders",
                newName: "numberofUnits6");

            migrationBuilder.RenameColumn(
                name: "unit5",
                table: "Orders",
                newName: "numberofUnits5");

            migrationBuilder.RenameColumn(
                name: "unit4",
                table: "Orders",
                newName: "numberofUnits4");

            migrationBuilder.RenameColumn(
                name: "unit3",
                table: "Orders",
                newName: "numberofUnits3");

            migrationBuilder.RenameColumn(
                name: "unit2",
                table: "Orders",
                newName: "numberofUnits2");

            migrationBuilder.RenameColumn(
                name: "unit1",
                table: "Orders",
                newName: "numberofUnits1");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateofIssue",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GrandTotal",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "unitPrice1",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "unitPrice2",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "unitPrice3",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "unitPrice4",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "unitPrice5",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "unitPrice6",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateofIssue",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "GrandTotal",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "unitPrice1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "unitPrice2",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "unitPrice3",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "unitPrice4",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "unitPrice5",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "unitPrice6",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "numberofUnits6",
                table: "Orders",
                newName: "unit6");

            migrationBuilder.RenameColumn(
                name: "numberofUnits5",
                table: "Orders",
                newName: "unit5");

            migrationBuilder.RenameColumn(
                name: "numberofUnits4",
                table: "Orders",
                newName: "unit4");

            migrationBuilder.RenameColumn(
                name: "numberofUnits3",
                table: "Orders",
                newName: "unit3");

            migrationBuilder.RenameColumn(
                name: "numberofUnits2",
                table: "Orders",
                newName: "unit2");

            migrationBuilder.RenameColumn(
                name: "numberofUnits1",
                table: "Orders",
                newName: "unit1");
        }
    }
}
