using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDBAccess.Migrations
{
    /// <inheritdoc />
    public partial class MusicAppDatabase : Migration
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
                    IsArtist = table.Column<bool>(type: "bit", nullable: false),
                    WhiteListId = table.Column<int>(type: "int", nullable: false),
                    BlackListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_BlackLists_BlackListId",
                        column: x => x.BlackListId,
                        principalTable: "BlackLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_WhiteLists_WhiteListId",
                        column: x => x.WhiteListId,
                        principalTable: "WhiteLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    HighlightSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtistPaymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artists_ArtistPayments_ArtistPaymentId",
                        column: x => x.ArtistPaymentId,
                        principalTable: "ArtistPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Artists_Users_UserId",
                        column: x => x.UserId,
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
                    HowManyNotifications = table.Column<int>(type: "int", nullable: false)
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
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AlbumImage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AudioExample = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WhiteListId = table.Column<int>(type: "int", nullable: false),
                    BlackListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Songs_BlackLists_BlackListId",
                        column: x => x.BlackListId,
                        principalTable: "BlackLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Songs_WhiteLists_WhiteListId",
                        column: x => x.WhiteListId,
                        principalTable: "WhiteLists",
                        principalColumn: "Id");
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
                name: "IX_Songs_ArtistId",
                table: "Songs",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_BlackListId",
                table: "Songs",
                column: "BlackListId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_WhiteListId",
                table: "Songs",
                column: "WhiteListId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BlackListId",
                table: "Users",
                column: "BlackListId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_WhiteListId",
                table: "Users",
                column: "WhiteListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "Premia");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "ArtistPayments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BlackLists");

            migrationBuilder.DropTable(
                name: "WhiteLists");
        }
    }
}
