using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Epic_Booking.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDuplicateUserIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2023, 12, 28, 13, 49, 48, 109, DateTimeKind.Local).AddTicks(5230), new DateTime(2023, 12, 28, 11, 49, 48, 109, DateTimeKind.Local).AddTicks(5180) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 456,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2023, 12, 29, 13, 49, 48, 109, DateTimeKind.Local).AddTicks(5240), new DateTime(2023, 12, 29, 11, 49, 48, 109, DateTimeKind.Local).AddTicks(5240) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2023, 12, 26, 23, 24, 33, 74, DateTimeKind.Local).AddTicks(5780), new DateTime(2023, 12, 26, 21, 24, 33, 74, DateTimeKind.Local).AddTicks(5750) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 456,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2023, 12, 27, 23, 24, 33, 74, DateTimeKind.Local).AddTicks(5790), new DateTime(2023, 12, 27, 21, 24, 33, 74, DateTimeKind.Local).AddTicks(5790) });
        }
    }
}
