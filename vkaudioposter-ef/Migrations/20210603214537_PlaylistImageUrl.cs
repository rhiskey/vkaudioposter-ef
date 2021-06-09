using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace vkaudioposter_ef.Migrations
{
    public partial class PlaylistImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Playlists",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 4, 0, 45, 37, 682, DateTimeKind.Local).AddTicks(9599),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 3, 0, 5, 15, 731, DateTimeKind.Local).AddTicks(8370),
                oldComment: "Update Date");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Playlists",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "console_Photostocks",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 4, 0, 45, 37, 684, DateTimeKind.Local).AddTicks(5046),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 3, 0, 5, 15, 733, DateTimeKind.Local).AddTicks(3607),
                oldComment: "Update Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Playlists");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Playlists",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 3, 0, 5, 15, 731, DateTimeKind.Local).AddTicks(8370),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 4, 0, 45, 37, 682, DateTimeKind.Local).AddTicks(9599),
                oldComment: "Update Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "console_Photostocks",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 3, 0, 5, 15, 733, DateTimeKind.Local).AddTicks(3607),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 4, 0, 45, 37, 684, DateTimeKind.Local).AddTicks(5046),
                oldComment: "Update Date");
        }
    }
}
