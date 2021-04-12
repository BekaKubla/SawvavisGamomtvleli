using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FuelProject.Migrations
{
    public partial class FuelPriceInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuelPrices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTimeNow = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriceCategory = table.Column<int>(type: "int", nullable: false),
                    RompetrolPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GulfPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortalPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptimaPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocarPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LukoilPrice = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelPrices", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuelPrices");
        }
    }
}
