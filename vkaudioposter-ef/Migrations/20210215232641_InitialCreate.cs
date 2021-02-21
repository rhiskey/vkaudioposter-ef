using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;
using MySql.EntityFrameworkCore.Metadata;

namespace vkaudioposter_ef.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Playlist_ID = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, comment: "Spotify URI"),
                    Playlist_Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Name of playlist"),
                    Mood = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "console_Photostocks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    URL = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    PlaylistId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_console_Photostocks", x => x.id);
                    table.ForeignKey(
                        name: "FK_console_Photostocks_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "URL list of photostocks");

            migrationBuilder.CreateTable(
                name: "PostedTracks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Trackname = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Style = table.Column<string>(type: "varchar(45)", maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    PlaylistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostedTracks", x => x.id);
                    table.ForeignKey(
                        name: "FK_PostedTracks_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Published tracks info");

            migrationBuilder.CreateTable(
                name: "UnfoundTracks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    trackname = table.Column<string>(type: "varchar(150)", maxLength: 100, nullable: false),
                    style = table.Column<string>(type: "varchar(45)", maxLength: 50, nullable: true),
                    PlaylistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnfoundTracks", x => x.id);
                    table.ForeignKey(
                        name: "FK_UnfoundTracks_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_console_Photostocks_PlaylistId",
                table: "console_Photostocks",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "Playlist_Name",
                table: "Playlists",
                column: "Playlist_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostedTracks_PlaylistId",
                table: "PostedTracks",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_PostedTracks_Trackname",
                table: "PostedTracks",
                column: "Trackname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnfoundTracks_PlaylistId",
                table: "UnfoundTracks",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_UnfoundTracks_trackname",
                table: "UnfoundTracks",
                column: "trackname",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "console_Photostocks");

            migrationBuilder.DropTable(
                name: "PostedTracks");

            migrationBuilder.DropTable(
                name: "UnfoundTracks");

            migrationBuilder.DropTable(
                name: "Playlists");
        }
    }
}
