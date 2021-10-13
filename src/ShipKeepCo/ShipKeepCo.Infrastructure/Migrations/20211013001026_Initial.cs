using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShipKeepCo.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "PricePerNights",
                columns: table => new
                {
                    PricePerNightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricePerNights", x => x.PricePerNightId);
                });

            migrationBuilder.CreateTable(
                name: "Voyages",
                columns: table => new
                {
                    VoyageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voyages", x => x.VoyageId);
                });

            migrationBuilder.CreateTable(
                name: "VoyagePoints",
                columns: table => new
                {
                    VoyagePointId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    VoyageId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoyagePoints", x => x.VoyagePointId);
                    table.ForeignKey(
                        name: "FK_VoyagePoints_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId");
                    table.ForeignKey(
                        name: "FK_VoyagePoints_Voyages_VoyageId",
                        column: x => x.VoyageId,
                        principalTable: "Voyages",
                        principalColumn: "VoyageId");
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureVoyagePointId = table.Column<int>(type: "int", nullable: false),
                    ArrivalVoyagePointId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_VoyagePoints_ArrivalVoyagePointId",
                        column: x => x.ArrivalVoyagePointId,
                        principalTable: "VoyagePoints",
                        principalColumn: "VoyagePointId");
                    table.ForeignKey(
                        name: "FK_Bookings_VoyagePoints_DepartureVoyagePointId",
                        column: x => x.DepartureVoyagePointId,
                        principalTable: "VoyagePoints",
                        principalColumn: "VoyagePointId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ArrivalVoyagePointId",
                table: "Bookings",
                column: "ArrivalVoyagePointId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DepartureVoyagePointId",
                table: "Bookings",
                column: "DepartureVoyagePointId");

            migrationBuilder.CreateIndex(
                name: "IX_VoyagePoints_LocationId",
                table: "VoyagePoints",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_VoyagePoints_VoyageId",
                table: "VoyagePoints",
                column: "VoyageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "PricePerNights");

            migrationBuilder.DropTable(
                name: "VoyagePoints");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Voyages");
        }
    }
}
