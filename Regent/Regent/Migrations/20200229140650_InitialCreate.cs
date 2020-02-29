using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Regent.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    comPort = table.Column<string>(nullable: true),
                    deviceCategory = table.Column<string>(nullable: true),
                    deviceName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Errors",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dateTime = table.Column<DateTime>(nullable: false),
                    _error = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Errors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Telemetry",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    temperature = table.Column<int>(nullable: false),
                    illumination = table.Column<int>(nullable: false),
                    humidity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telemetry", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dateTime = table.Column<DateTime>(nullable: false),
                    cathegory = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true),
                    _event = table.Column<string>(nullable: true),
                    telemetryid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.id);
                    table.ForeignKey(
                        name: "FK_Events_Telemetry_telemetryid",
                        column: x => x.telemetryid,
                        principalTable: "Telemetry",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_telemetryid",
                table: "Events",
                column: "telemetryid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Errors");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Telemetry");
        }
    }
}
