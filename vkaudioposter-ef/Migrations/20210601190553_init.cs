using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vkaudioposter_ef.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Playlists",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 1, 22, 5, 53, 66, DateTimeKind.Local).AddTicks(2541),
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
                defaultValue: new DateTime(2021, 6, 1, 22, 5, 53, 68, DateTimeKind.Local).AddTicks(308),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 5, 27, 14, 55, 17, 543, DateTimeKind.Local).AddTicks(1411),
                oldComment: "Update Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2021, 6, 1, 22, 5, 53, 66, DateTimeKind.Local).AddTicks(2541),
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
                oldDefaultValue: new DateTime(2021, 6, 1, 22, 5, 53, 68, DateTimeKind.Local).AddTicks(308),
                oldComment: "Update Date");
        }
    }
}
