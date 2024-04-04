using Microsoft.EntityFrameworkCore.Migrations;

namespace Neerogilksample.Migrations
{
    public partial class Added_New_Model_Orders_Added_to_AppDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerUserEmailTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryPersonUserEmailTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landmark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    item1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price1 = table.Column<double>(type: "float", nullable: false),
                    item2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price2 = table.Column<double>(type: "float", nullable: false),
                    item3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price3 = table.Column<double>(type: "float", nullable: false),
                    item4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price4 = table.Column<double>(type: "float", nullable: false),
                    item5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price5 = table.Column<double>(type: "float", nullable: false),
                    item6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price6 = table.Column<double>(type: "float", nullable: false),
                    customerNametoDeliver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerDeliveryContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AppUserId",
                table: "Orders",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
