using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vkaudioposter_ef.Migrations
{
    public partial class RemoveMapping2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrackUrls",
                table: "PostedTracks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Playlists",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 27, 13, 43, 2, 95, DateTimeKind.Local).AddTicks(9512),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 5, 27, 13, 40, 54, 438, DateTimeKind.Local).AddTicks(937),
                oldComment: "Update Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "console_Photostocks",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 27, 13, 43, 2, 97, DateTimeKind.Local).AddTicks(5703),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 5, 27, 13, 40, 54, 439, DateTimeKind.Local).AddTicks(7153),
                oldComment: "Update Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2021, 5, 27, 13, 40, 54, 438, DateTimeKind.Local).AddTicks(937),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 5, 27, 13, 43, 2, 95, DateTimeKind.Local).AddTicks(9512),
                oldComment: "Update Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "console_Photostocks",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 27, 13, 40, 54, 439, DateTimeKind.Local).AddTicks(7153),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 5, 27, 13, 43, 2, 97, DateTimeKind.Local).AddTicks(5703),
                oldComment: "Update Date");
        }
    }
}
