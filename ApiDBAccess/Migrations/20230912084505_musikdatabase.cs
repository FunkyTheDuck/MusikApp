﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiDBAccess.Migrations
{
    /// <inheritdoc />
    public partial class musikdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtistPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsPremium = table.Column<bool>(type: "bit", nullable: false),
                    IsArtist = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    HighlightSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtistPaymentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artists_ArtistPayments_ArtistPaymentId",
                        column: x => x.ArtistPaymentId,
                        principalTable: "ArtistPayments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Artists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlackLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    SongID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlackLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlackLists_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FriendId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friends_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Premia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TransactionDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextTransactionDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Premia_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ChangeGenre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HowNewTheMusicIs = table.Column<int>(type: "int", nullable: false),
                    NotificationsAmount = table.Column<int>(type: "int", nullable: false),
                    Popularity = table.Column<int>(type: "int", nullable: false),
                    Energy = table.Column<int>(type: "int", nullable: false),
                    Danceability = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WhiteLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    SongID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhiteLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WhiteLists_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ArtistPayments",
                columns: new[] { "Id", "ArtistId", "EndDate", "StartDate" },
                values: new object[] { 1, 1, new DateTime(2023, 9, 12, 10, 45, 4, 904, DateTimeKind.Local).AddTicks(4814), new DateTime(2023, 9, 12, 10, 45, 4, 904, DateTimeKind.Local).AddTicks(4758) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsArtist", "IsPremium", "LastName", "Mail", "Name", "Password", "ProfilPicture", "UserName" },
                values: new object[,]
                {
                    { 1, true, true, "Bieber", "justinbieber@hotmail.com", "Justin", "Bruger123", "Billede", "JustinB" },
                    { 2, false, true, "Wayne", "batmanerbest@gmail.com", "Bruce", "Beuger123", "Billede1", "Batman" },
                    { 3, false, false, "Kent", "ilovelois@gmail.com", "Clark", "Bruger123", "Billede2", "Superman" }
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "ArtistPaymentId", "HighlightSong", "UserId" },
                values: new object[] { 1, null, null, 1 });

            migrationBuilder.InsertData(
                table: "BlackLists",
                columns: new[] { "Id", "SongID", "UserID" },
                values: new object[,]
                {
                    { 1, "7xapw9Oy21WpfEcib2ErSA", 1 },
                    { 2, "7xapw9Oy21WpfEcib2ErSA", 2 },
                    { 3, "7xapw9Oy21WpfEcib2ErSA", 3 }
                });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "FriendId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Premia",
                columns: new[] { "Id", "NextTransactionDay", "TransactionDay", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 12, 10, 45, 4, 904, DateTimeKind.Local).AddTicks(4892), new DateTime(2023, 9, 12, 10, 45, 4, 904, DateTimeKind.Local).AddTicks(4894), 1 },
                    { 2, new DateTime(2023, 9, 12, 10, 45, 4, 904, DateTimeKind.Local).AddTicks(4896), new DateTime(2023, 9, 12, 10, 45, 4, 904, DateTimeKind.Local).AddTicks(4898), 2 }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "ChangeGenre", "Danceability", "Energy", "HowNewTheMusicIs", "NotificationsAmount", "Popularity", "UserId" },
                values: new object[,]
                {
                    { 1, "k-pop", 0, 0, 10, 5, 0, 1 },
                    { 2, "rock", 0, 0, 5, 3, 0, 2 },
                    { 3, "pop", 0, 0, 20, 8, 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "WhiteLists",
                columns: new[] { "Id", "SongID", "UserID" },
                values: new object[,]
                {
                    { 1, "6habFhsOp2NvshLv26DqMb", 1 },
                    { 2, "6habFhsOp2NvshLv26DqMb", 2 },
                    { 3, "6habFhsOp2NvshLv26DqMb", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artists_ArtistPaymentId",
                table: "Artists",
                column: "ArtistPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_UserId",
                table: "Artists",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlackLists_UserID",
                table: "BlackLists",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserId",
                table: "Friends",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Premia_UserId",
                table: "Premia",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Settings_UserId",
                table: "Settings",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WhiteLists_UserID",
                table: "WhiteLists",
                column: "UserID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "BlackLists");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "Premia");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "WhiteLists");

            migrationBuilder.DropTable(
                name: "ArtistPayments");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
