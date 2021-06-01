using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace vkaudioposter_ef.Migrations
{
    public partial class UpdatePostedTrackWithSpotifyLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PreviewUrl",
                table: "PostedTracks",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Playlists",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 26, 22, 50, 3, 241, DateTimeKind.Local).AddTicks(4336),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 5, 11, 12, 2, 19, 342, DateTimeKind.Local).AddTicks(5475),
                oldComment: "Update Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "console_Photostocks",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 26, 22, 50, 3, 243, DateTimeKind.Local).AddTicks(150),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 5, 11, 12, 2, 19, 350, DateTimeKind.Local).AddTicks(4113),
                oldComment: "Update Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviewUrl",
                table: "PostedTracks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Playlists",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 11, 12, 2, 19, 342, DateTimeKind.Local).AddTicks(5475),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 5, 26, 22, 50, 3, 241, DateTimeKind.Local).AddTicks(4336),
                oldComment: "Update Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "console_Photostocks",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 11, 12, 2, 19, 350, DateTimeKind.Local).AddTicks(4113),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 5, 26, 22, 50, 3, 243, DateTimeKind.Local).AddTicks(150),
                oldComment: "Update Date");
        }
    }
}
