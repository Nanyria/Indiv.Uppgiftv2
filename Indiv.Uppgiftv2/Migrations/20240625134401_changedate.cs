using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indiv.Uppgiftv2.Migrations
{
    /// <inheritdoc />
    public partial class changedate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 1001,
                columns: new[] { "Date", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 1002,
                columns: new[] { "Date", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 4, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 1003,
                columns: new[] { "Date", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 1004,
                columns: new[] { "Date", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 1005,
                columns: new[] { "Date", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 2, 13, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 1001,
                columns: new[] { "Date", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 1002,
                columns: new[] { "Date", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 4, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 1003,
                columns: new[] { "Date", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 1004,
                columns: new[] { "Date", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 1005,
                columns: new[] { "Date", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 2, 13, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
