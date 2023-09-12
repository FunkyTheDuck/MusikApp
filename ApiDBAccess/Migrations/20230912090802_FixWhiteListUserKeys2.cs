using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDBAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixWhiteListUserKeys2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WhiteLists_UserID",
                table: "WhiteLists");

            migrationBuilder.DropIndex(
                name: "IX_BlackLists_UserID",
                table: "BlackLists");

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

            migrationBuilder.CreateIndex(
                name: "IX_WhiteLists_UserID",
                table: "WhiteLists",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_BlackLists_UserID",
                table: "BlackLists",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WhiteLists_UserID",
                table: "WhiteLists");

            migrationBuilder.DropIndex(
                name: "IX_BlackLists_UserID",
                table: "BlackLists");

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

            migrationBuilder.CreateIndex(
                name: "IX_WhiteLists_UserID",
                table: "WhiteLists",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlackLists_UserID",
                table: "BlackLists",
                column: "UserID",
                unique: true);
        }
    }
}
