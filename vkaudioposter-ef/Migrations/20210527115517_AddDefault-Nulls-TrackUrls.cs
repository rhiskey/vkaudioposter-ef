using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace vkaudioposter_ef.Migrations
{
    public partial class AddDefaultNullsTrackUrls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Playlists",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 27, 14, 55, 17, 541, DateTimeKind.Local).AddTicks(4943),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 5, 27, 14, 44, 1, 967, DateTimeKind.Local).AddTicks(6731),
                oldComment: "Update Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "console_Photostocks",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 27, 14, 55, 17, 543, DateTimeKind.Local).AddTicks(1411),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 5, 27, 14, 44, 1, 969, DateTimeKind.Local).AddTicks(2500),
                oldComment: "Update Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Playlists",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 27, 14, 44, 1, 967, DateTimeKind.Local).AddTicks(6731),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 5, 27, 14, 55, 17, 541, DateTimeKind.Local).AddTicks(4943),
                oldComment: "Update Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "console_Photostocks",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 27, 14, 44, 1, 969, DateTimeKind.Local).AddTicks(2500),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 5, 27, 14, 55, 17, 543, DateTimeKind.Local).AddTicks(1411),
                oldComment: "Update Date");
        }
    }
}
