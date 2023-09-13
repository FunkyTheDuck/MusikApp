using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDBAccess.Migrations
{
    /// <inheritdoc />
    public partial class tilføjeLastOnline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastOnline",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ArtistPayments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 9, 13, 13, 24, 57, 899, DateTimeKind.Local).AddTicks(5180), new DateTime(2023, 9, 13, 13, 24, 57, 899, DateTimeKind.Local).AddTicks(5178) });

            migrationBuilder.UpdateData(
                table: "Premia",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NextTransactionDay", "TransactionDay" },
                values: new object[] { new DateTime(2023, 9, 13, 13, 24, 57, 899, DateTimeKind.Local).AddTicks(5227), new DateTime(2023, 9, 13, 13, 24, 57, 899, DateTimeKind.Local).AddTicks(5231) });

            migrationBuilder.UpdateData(
                table: "Premia",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NextTransactionDay", "TransactionDay" },
                values: new object[] { new DateTime(2023, 9, 13, 13, 24, 57, 899, DateTimeKind.Local).AddTicks(5233), new DateTime(2023, 9, 13, 13, 24, 57, 899, DateTimeKind.Local).AddTicks(5234) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastOnline",
                value: new DateTime(2023, 9, 14, 13, 24, 57, 899, DateTimeKind.Local).AddTicks(4974));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastOnline",
                value: new DateTime(2023, 9, 13, 14, 24, 57, 899, DateTimeKind.Local).AddTicks(5041));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastOnline",
                value: new DateTime(2023, 9, 13, 13, 24, 57, 899, DateTimeKind.Local).AddTicks(5045));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastOnline",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "ArtistPayments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 9, 12, 11, 8, 2, 549, DateTimeKind.Local).AddTicks(5285), new DateTime(2023, 9, 12, 11, 8, 2, 549, DateTimeKind.Local).AddTicks(5230) });

            migrationBuilder.UpdateData(
                table: "Premia",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NextTransactionDay", "TransactionDay" },
                values: new object[] { new DateTime(2023, 9, 12, 11, 8, 2, 549, DateTimeKind.Local).AddTicks(5348), new DateTime(2023, 9, 12, 11, 8, 2, 549, DateTimeKind.Local).AddTicks(5350) });

            migrationBuilder.UpdateData(
                table: "Premia",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NextTransactionDay", "TransactionDay" },
                values: new object[] { new DateTime(2023, 9, 12, 11, 8, 2, 549, DateTimeKind.Local).AddTicks(5352), new DateTime(2023, 9, 12, 11, 8, 2, 549, DateTimeKind.Local).AddTicks(5353) });
        }
    }
}
