using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDBAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemovedArtistInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtistInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpotifyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountOfSongsLiked = table.Column<int>(type: "int", nullable: false),
                    AmountOfSongSkipped = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistInfo", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ArtistPayments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 9, 18, 11, 28, 34, 440, DateTimeKind.Local).AddTicks(2704), new DateTime(2023, 9, 18, 11, 28, 34, 440, DateTimeKind.Local).AddTicks(2701) });

            migrationBuilder.UpdateData(
                table: "Premia",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NextTransactionDay", "TransactionDay" },
                values: new object[] { new DateTime(2023, 9, 18, 11, 28, 34, 440, DateTimeKind.Local).AddTicks(2759), new DateTime(2023, 9, 18, 11, 28, 34, 440, DateTimeKind.Local).AddTicks(2761) });

            migrationBuilder.UpdateData(
                table: "Premia",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NextTransactionDay", "TransactionDay" },
                values: new object[] { new DateTime(2023, 9, 18, 11, 28, 34, 440, DateTimeKind.Local).AddTicks(2763), new DateTime(2023, 9, 18, 11, 28, 34, 440, DateTimeKind.Local).AddTicks(2764) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastOnline",
                value: new DateTime(2023, 9, 19, 11, 28, 34, 440, DateTimeKind.Local).AddTicks(2511));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastOnline",
                value: new DateTime(2023, 9, 18, 12, 28, 34, 440, DateTimeKind.Local).AddTicks(2574));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastOnline",
                value: new DateTime(2023, 9, 18, 11, 28, 34, 440, DateTimeKind.Local).AddTicks(2577));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistInfo");

            migrationBuilder.UpdateData(
                table: "ArtistPayments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 9, 18, 11, 16, 19, 879, DateTimeKind.Local).AddTicks(9066), new DateTime(2023, 9, 18, 11, 16, 19, 879, DateTimeKind.Local).AddTicks(9063) });

            migrationBuilder.UpdateData(
                table: "Premia",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NextTransactionDay", "TransactionDay" },
                values: new object[] { new DateTime(2023, 9, 18, 11, 16, 19, 879, DateTimeKind.Local).AddTicks(9132), new DateTime(2023, 9, 18, 11, 16, 19, 879, DateTimeKind.Local).AddTicks(9134) });

            migrationBuilder.UpdateData(
                table: "Premia",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NextTransactionDay", "TransactionDay" },
                values: new object[] { new DateTime(2023, 9, 18, 11, 16, 19, 879, DateTimeKind.Local).AddTicks(9135), new DateTime(2023, 9, 18, 11, 16, 19, 879, DateTimeKind.Local).AddTicks(9137) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastOnline",
                value: new DateTime(2023, 9, 19, 11, 16, 19, 879, DateTimeKind.Local).AddTicks(8866));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastOnline",
                value: new DateTime(2023, 9, 18, 12, 16, 19, 879, DateTimeKind.Local).AddTicks(8929));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastOnline",
                value: new DateTime(2023, 9, 18, 11, 16, 19, 879, DateTimeKind.Local).AddTicks(8932));
        }
    }
}
