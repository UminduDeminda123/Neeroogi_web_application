using Microsoft.EntityFrameworkCore.Migrations;

namespace Neerogilksample.Migrations
{
    public partial class Added_Props_to_Orders_Model_Units : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "unit1",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "unit2",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "unit3",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "unit4",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "unit5",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "unit6",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "unit1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "unit2",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "unit3",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "unit4",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "unit5",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "unit6",
                table: "Orders");
        }
    }
}
