using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirPort.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirCraftTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    Seats = table.Column<int>(nullable: false),
                    LoadCapacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirCraftTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departures",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FlightNumber = table.Column<int>(nullable: false),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    CrewId = table.Column<Guid>(nullable: false),
                    AirCraftId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    DeparturePoint = table.Column<string>(nullable: true),
                    DepartureTime = table.Column<DateTime>(nullable: false),
                    Destination = table.Column<string>(nullable: true),
                    TimeOfArrival = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pilots",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Experience = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirCrafts",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: true),
                    TypeId = table.Column<Guid>(nullable: false),
                    AirCraftTypeId = table.Column<Guid>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    TimeSpan = table.Column<DateTime>(nullable: false),
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirCrafts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirCrafts_AirCraftTypes_AirCraftTypeId",
                        column: x => x.AirCraftTypeId,
                        principalTable: "AirCraftTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    FlightNumber = table.Column<int>(nullable: false),
                    FlightId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Crews",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PilotId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crews_Pilots_PilotId",
                        column: x => x.PilotId,
                        principalTable: "Pilots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stewardesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    CrewId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stewardesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stewardesses_Crews_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirCrafts_AirCraftTypeId",
                table: "AirCrafts",
                column: "AirCraftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Crews_PilotId",
                table: "Crews",
                column: "PilotId");

            migrationBuilder.CreateIndex(
                name: "IX_Stewardesses_CrewId",
                table: "Stewardesses",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FlightId",
                table: "Tickets",
                column: "FlightId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirCrafts");

            migrationBuilder.DropTable(
                name: "Departures");

            migrationBuilder.DropTable(
                name: "Stewardesses");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "AirCraftTypes");

            migrationBuilder.DropTable(
                name: "Crews");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Pilots");
        }
    }
}
