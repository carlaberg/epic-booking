using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Epic_Booking.Migrations
{
    /// <inheritdoc />
    public partial class AddNameIdentifier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameIdentifier",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2023, 12, 28, 14, 3, 2, 409, DateTimeKind.Local).AddTicks(830), new DateTime(2023, 12, 28, 12, 3, 2, 409, DateTimeKind.Local).AddTicks(790) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 456,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2023, 12, 29, 14, 3, 2, 409, DateTimeKind.Local).AddTicks(850), new DateTime(2023, 12, 29, 12, 3, 2, 409, DateTimeKind.Local).AddTicks(840) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameIdentifier",
                table: "AspNetUsers");

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
    }
}
