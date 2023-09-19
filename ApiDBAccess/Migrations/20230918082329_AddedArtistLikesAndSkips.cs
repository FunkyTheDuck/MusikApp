using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDBAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedArtistLikesAndSkips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SongArtistId",
                table: "WhiteLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SongArtistId",
                table: "BlackLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ArtistInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                values: new object[] { new DateTime(2023, 9, 18, 10, 23, 29, 431, DateTimeKind.Local).AddTicks(4946), new DateTime(2023, 9, 18, 10, 23, 29, 431, DateTimeKind.Local).AddTicks(4944) });

            migrationBuilder.UpdateData(
                table: "BlackLists",
                keyColumn: "Id",
                keyValue: 1,
                column: "SongArtistId",
                value: "1uNFoZAHBGtllmzznpCI3s");

            migrationBuilder.UpdateData(
                table: "BlackLists",
                keyColumn: "Id",
                keyValue: 2,
                column: "SongArtistId",
                value: "1uNFoZAHBGtllmzznpCI3s");

            migrationBuilder.UpdateData(
                table: "BlackLists",
                keyColumn: "Id",
                keyValue: 3,
                column: "SongArtistId",
                value: "1uNFoZAHBGtllmzznpCI3s");

            migrationBuilder.UpdateData(
                table: "Premia",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NextTransactionDay", "TransactionDay" },
                values: new object[] { new DateTime(2023, 9, 18, 10, 23, 29, 431, DateTimeKind.Local).AddTicks(5004), new DateTime(2023, 9, 18, 10, 23, 29, 431, DateTimeKind.Local).AddTicks(5005) });

            migrationBuilder.UpdateData(
                table: "Premia",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NextTransactionDay", "TransactionDay" },
                values: new object[] { new DateTime(2023, 9, 18, 10, 23, 29, 431, DateTimeKind.Local).AddTicks(5007), new DateTime(2023, 9, 18, 10, 23, 29, 431, DateTimeKind.Local).AddTicks(5008) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastOnline",
                value: new DateTime(2023, 9, 19, 10, 23, 29, 431, DateTimeKind.Local).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastOnline",
                value: new DateTime(2023, 9, 18, 11, 23, 29, 431, DateTimeKind.Local).AddTicks(4826));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastOnline",
                value: new DateTime(2023, 9, 18, 10, 23, 29, 431, DateTimeKind.Local).AddTicks(4829));

            migrationBuilder.UpdateData(
                table: "WhiteLists",
                keyColumn: "Id",
                keyValue: 1,
                column: "SongArtistId",
                value: "4V8Sr092TqfHkfAA5fXXqG");

            migrationBuilder.UpdateData(
                table: "WhiteLists",
                keyColumn: "Id",
                keyValue: 2,
                column: "SongArtistId",
                value: "4V8Sr092TqfHkfAA5fXXqG");

            migrationBuilder.UpdateData(
                table: "WhiteLists",
                keyColumn: "Id",
                keyValue: 3,
                column: "SongArtistId",
                value: "4V8Sr092TqfHkfAA5fXXqG");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistInfo");

            migrationBuilder.DropColumn(
                name: "SongArtistId",
                table: "WhiteLists");

            migrationBuilder.DropColumn(
                name: "SongArtistId",
                table: "BlackLists");

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
    }
}
