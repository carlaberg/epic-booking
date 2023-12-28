using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Epic_Booking.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingUserRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "CreatorId", "End", "Start" },
                values: new object[] { 0, new DateTime(2023, 12, 26, 23, 24, 33, 74, DateTimeKind.Local).AddTicks(5780), new DateTime(2023, 12, 26, 21, 24, 33, 74, DateTimeKind.Local).AddTicks(5750) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 456,
                columns: new[] { "CreatorId", "End", "Start" },
                values: new object[] { 0, new DateTime(2023, 12, 27, 23, 24, 33, 74, DateTimeKind.Local).AddTicks(5790), new DateTime(2023, 12, 27, 21, 24, 33, 74, DateTimeKind.Local).AddTicks(5790) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2023, 12, 26, 0, 45, 52, 98, DateTimeKind.Local).AddTicks(1920), new DateTime(2023, 12, 25, 22, 45, 52, 98, DateTimeKind.Local).AddTicks(1880) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 456,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2023, 12, 27, 0, 45, 52, 98, DateTimeKind.Local).AddTicks(1930), new DateTime(2023, 12, 26, 22, 45, 52, 98, DateTimeKind.Local).AddTicks(1920) });
        }
    }
}
