using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class reconvention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "my_Plane",
                columns: table => new
                {
                    Planeid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanCapacity = table.Column<int>(type: "int", nullable: false),
                    ManufactureDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Planetyp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_my_Plane", x => x.Planeid);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Passportnumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Emailadress = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PassengerName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Telnumber = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    Discriminator = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    EmployeementDate = table.Column<DateTime>(type: "Date", nullable: true),
                    Function = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: true),
                    Healthinformations = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Nationality = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Passportnumber);
                });

            migrationBuilder.CreateTable(
                name: "myflight",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destination = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Departure = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FlightDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EffectiveArrival = table.Column<DateTime>(type: "Date", nullable: false),
                    planefk = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myflight", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_myflight_my_Plane_planefk",
                        column: x => x.planefk,
                        principalTable: "my_Plane",
                        principalColumn: "Planeid",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "table_passenger_flights",
                columns: table => new
                {
                    FlightsFlightId = table.Column<int>(type: "int", nullable: false),
                    PassengersPassportnumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_passenger_flights", x => new { x.FlightsFlightId, x.PassengersPassportnumber });
                    table.ForeignKey(
                        name: "FK_table_passenger_flights_Passengers_PassengersPassportnumber",
                        column: x => x.PassengersPassportnumber,
                        principalTable: "Passengers",
                        principalColumn: "Passportnumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_table_passenger_flights_myflight_FlightsFlightId",
                        column: x => x.FlightsFlightId,
                        principalTable: "myflight",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_myflight_planefk",
                table: "myflight",
                column: "planefk");

            migrationBuilder.CreateIndex(
                name: "IX_table_passenger_flights_PassengersPassportnumber",
                table: "table_passenger_flights",
                column: "PassengersPassportnumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "table_passenger_flights");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "myflight");

            migrationBuilder.DropTable(
                name: "my_Plane");
        }
    }
}
