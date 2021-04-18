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
                    FuelCategory = table.Column<int>(type: "int", nullable: false),
                    RompetrolPrice = table.Column<double>(type: "float", nullable: false),
                    GulfPrice = table.Column<double>(type: "float", nullable: false),
                    PortalPrice = table.Column<double>(type: "float", nullable: false),
                    OptimaPrice = table.Column<double>(type: "float", nullable: false),
                    SocarPrice = table.Column<double>(type: "float", nullable: false),
                    LukoilPrice = table.Column<double>(type: "float", nullable: false)
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
