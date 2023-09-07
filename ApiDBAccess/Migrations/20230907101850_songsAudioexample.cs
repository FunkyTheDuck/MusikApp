using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDBAccess.Migrations
{
    /// <inheritdoc />
    public partial class songsAudioexample : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AudioExample",
                table: "Songs");

            migrationBuilder.AddColumn<string>(
                name: "URLPreview",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URLPreview",
                table: "Songs");

            migrationBuilder.AddColumn<byte[]>(
                name: "AudioExample",
                table: "Songs",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
