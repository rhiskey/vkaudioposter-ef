using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vkaudioposter_ef.Migrations
{
    public partial class ChangeTrackUrlsToListInsteadDictNormal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrackUrls",
                table: "PostedTracks",
                type: "text",
                maxLength: 5000,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Playlists",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 27, 1, 37, 21, 753, DateTimeKind.Local).AddTicks(157),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 5, 27, 1, 36, 16, 472, DateTimeKind.Local).AddTicks(1190),
                oldComment: "Update Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "console_Photostocks",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 27, 1, 37, 21, 754, DateTimeKind.Local).AddTicks(5742),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 5, 27, 1, 36, 16, 473, DateTimeKind.Local).AddTicks(7397),
                oldComment: "Update Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrackUrls",
                table: "PostedTracks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Playlists",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 27, 1, 36, 16, 472, DateTimeKind.Local).AddTicks(1190),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 5, 27, 1, 37, 21, 753, DateTimeKind.Local).AddTicks(157),
                oldComment: "Update Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "console_Photostocks",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 27, 1, 36, 16, 473, DateTimeKind.Local).AddTicks(7397),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 5, 27, 1, 37, 21, 754, DateTimeKind.Local).AddTicks(5742),
                oldComment: "Update Date");
        }
    }
}
