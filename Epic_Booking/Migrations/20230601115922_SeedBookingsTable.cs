using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Epic_Booking.Migrations
{
    /// <inheritdoc />
    public partial class SeedBookingsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "End", "Start", "Title" },
                values: new object[,]
                {
                    { 123, new DateTime(2023, 6, 1, 15, 59, 22, 307, DateTimeKind.Local).AddTicks(3680), new DateTime(2023, 6, 1, 13, 59, 22, 307, DateTimeKind.Local).AddTicks(3300), "Booking 1" },
                    { 456, new DateTime(2023, 6, 2, 15, 59, 22, 307, DateTimeKind.Local).AddTicks(3780), new DateTime(2023, 6, 2, 13, 59, 22, 307, DateTimeKind.Local).AddTicks(3770), "Booking 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 456);
        }
    }
}
