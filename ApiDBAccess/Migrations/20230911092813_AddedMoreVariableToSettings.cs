using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDBAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreVariableToSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.RenameColumn(
                name: "HowManyNotifications",
                table: "Settings",
                newName: "Popularity");

            migrationBuilder.AddColumn<int>(
                name: "Danceability",
                table: "Settings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Energy",
                table: "Settings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NotificationsAmount",
                table: "Settings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Danceability",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Energy",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "NotificationsAmount",
                table: "Settings");

            migrationBuilder.RenameColumn(
                name: "Popularity",
                table: "Settings",
                newName: "HowManyNotifications");

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    BlackListId = table.Column<int>(type: "int", nullable: false),
                    WhiteListId = table.Column<int>(type: "int", nullable: false),
                    AlbumImage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    URLPreview = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
        }
    }
}
