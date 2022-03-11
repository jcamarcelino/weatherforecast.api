using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherForecast.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    Local = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TemperatureC = table.Column<int>(type: "int", nullable: false),
                    TemperatureF = table.Column<int>(type: "int", nullable: false),
                    Rain = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Humidity = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Wind = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecasts");
        }
    }
}
