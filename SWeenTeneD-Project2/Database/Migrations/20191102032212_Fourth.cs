using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Flight_FlightID",
                table: "Flight",
                column: "FlightID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustomerID",
                table: "Customer",
                column: "CustomerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Airport_AirportID",
                table: "Airport",
                column: "AirportID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Flight_FlightID",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Customer_CustomerID",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Airport_AirportID",
                table: "Airport");
        }
    }
}
