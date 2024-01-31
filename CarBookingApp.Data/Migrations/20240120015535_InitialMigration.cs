using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarBookingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        // Anything inside this file is a migration. A migration is a code file that represents a change to the database schema.
        // This method is called when the migration is applied to the database. It creates the Cars table and inserts data into it.
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
                    { new Guid("68a2010e-7f25-44af-8e4e-fa2458b17857"), "Toyota Corolla", 2020 },
                    { new Guid("998c183d-baaa-48a3-8fe7-73bde3297358"), "Nissan Sentra", 2017 },
                    { new Guid("c959f47d-ccc4-488d-950c-724c985b2ba5"), "Chevrolet Cruze", 2015 },
                    { new Guid("d120c20a-6a9d-49e3-982e-4c2178340add"), "Ford Focus", 2016 },
                    { new Guid("d1d14888-ca7c-4c65-8a44-30fa550d1f3c"), "Honda Civic", 2018 }
                });
        }

        /// <inheritdoc />
        
        // This method is called when the migration is rolled back. It drops the Cars table.
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
