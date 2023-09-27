using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherRepository.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityEntities",
                columns: table => new
                {
                    IdCity = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityEntities", x => x.IdCity);
                });

            migrationBuilder.CreateTable(
                name: "WeatherDataEntities",
                columns: table => new
                {
                    IdWeather = table.Column<Guid>(type: "uuid", nullable: false),
                    CityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DayTimeEnum = table.Column<int>(type: "integer", nullable: false),
                    NightTimeEnum = table.Column<int>(type: "integer", nullable: false),
                    MaxTemperature = table.Column<int>(type: "integer", nullable: false),
                    MinTemperature = table.Column<int>(type: "integer", nullable: false),
                    Precipitation = table.Column<int>(type: "integer", nullable: false),
                    Humidity = table.Column<int>(type: "integer", nullable: false),
                    WindSpeed = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherDataEntities", x => x.IdWeather);
                    table.ForeignKey(
                        name: "FK_WeatherDataEntities_CityEntities_CityId",
                        column: x => x.CityId,
                        principalTable: "CityEntities",
                        principalColumn: "IdCity",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityEntities_Name",
                table: "CityEntities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherDataEntities_CityId",
                table: "WeatherDataEntities",
                column: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherDataEntities");

            migrationBuilder.DropTable(
                name: "CityEntities");
        }
    }
}
