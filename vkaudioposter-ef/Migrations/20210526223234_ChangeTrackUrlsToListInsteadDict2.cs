using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vkaudioposter_ef.Migrations
{
    public partial class ChangeTrackUrlsToListInsteadDict2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Playlists",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 27, 1, 32, 34, 221, DateTimeKind.Local).AddTicks(3823),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 5, 27, 1, 30, 41, 68, DateTimeKind.Local).AddTicks(626),
                oldComment: "Update Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "console_Photostocks",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 27, 1, 32, 34, 222, DateTimeKind.Local).AddTicks(9294),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 5, 27, 1, 30, 41, 69, DateTimeKind.Local).AddTicks(6447),
                oldComment: "Update Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Playlists",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 27, 1, 30, 41, 68, DateTimeKind.Local).AddTicks(626),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 5, 27, 1, 32, 34, 221, DateTimeKind.Local).AddTicks(3823),
                oldComment: "Update Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "console_Photostocks",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 27, 1, 30, 41, 69, DateTimeKind.Local).AddTicks(6447),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 5, 27, 1, 32, 34, 222, DateTimeKind.Local).AddTicks(9294),
                oldComment: "Update Date");
        }
    }
}
