using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDBAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixWhiteListUserKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArtistPayments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 9, 12, 11, 6, 47, 98, DateTimeKind.Local).AddTicks(6321), new DateTime(2023, 9, 12, 11, 6, 47, 98, DateTimeKind.Local).AddTicks(6262) });

            migrationBuilder.UpdateData(
                table: "Premia",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NextTransactionDay", "TransactionDay" },
                values: new object[] { new DateTime(2023, 9, 12, 11, 6, 47, 98, DateTimeKind.Local).AddTicks(6412), new DateTime(2023, 9, 12, 11, 6, 47, 98, DateTimeKind.Local).AddTicks(6414) });

            migrationBuilder.UpdateData(
                table: "Premia",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NextTransactionDay", "TransactionDay" },
                values: new object[] { new DateTime(2023, 9, 12, 11, 6, 47, 98, DateTimeKind.Local).AddTicks(6415), new DateTime(2023, 9, 12, 11, 6, 47, 98, DateTimeKind.Local).AddTicks(6416) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArtistPayments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 9, 12, 10, 45, 4, 904, DateTimeKind.Local).AddTicks(4814), new DateTime(2023, 9, 12, 10, 45, 4, 904, DateTimeKind.Local).AddTicks(4758) });

            migrationBuilder.UpdateData(
                table: "Premia",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NextTransactionDay", "TransactionDay" },
                values: new object[] { new DateTime(2023, 9, 12, 10, 45, 4, 904, DateTimeKind.Local).AddTicks(4892), new DateTime(2023, 9, 12, 10, 45, 4, 904, DateTimeKind.Local).AddTicks(4894) });

            migrationBuilder.UpdateData(
                table: "Premia",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NextTransactionDay", "TransactionDay" },
                values: new object[] { new DateTime(2023, 9, 12, 10, 45, 4, 904, DateTimeKind.Local).AddTicks(4896), new DateTime(2023, 9, 12, 10, 45, 4, 904, DateTimeKind.Local).AddTicks(4898) });
        }
    }
}
