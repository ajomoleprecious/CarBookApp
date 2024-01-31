using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarBookingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("19723339-1eae-4cad-bc45-8736234d8768"), "Toyota Corolla", 2020 },
                    { new Guid("2a06d250-fba0-4606-8b3b-bce0dddc2ccc"), "Honda Civic", 2018 },
                    { new Guid("7242fc72-dd55-462e-b16b-c4915b81629d"), "Nissan Sentra", 2017 },
                    { new Guid("829ba0e3-19d2-482f-ba88-37f00d9dab5e"), "Ford Focus", 2016 },
                    { new Guid("fe8d2ab1-db2e-40e8-a049-1f50a9f1f347"), "Chevrolet Cruze", 2015 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
