using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Epic_Booking.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCreatorIdToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 456);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Bookings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CreatorId", "End", "Start", "Title" },
                values: new object[,]
                {
                    { 123, 0, new DateTime(2023, 12, 28, 14, 11, 56, 965, DateTimeKind.Local).AddTicks(7550), new DateTime(2023, 12, 28, 12, 11, 56, 965, DateTimeKind.Local).AddTicks(7500), "Booking 1" },
                    { 456, 0, new DateTime(2023, 12, 29, 14, 11, 56, 965, DateTimeKind.Local).AddTicks(7560), new DateTime(2023, 12, 29, 12, 11, 56, 965, DateTimeKind.Local).AddTicks(7560), "Booking 2" }
                });
        }
    }
}
