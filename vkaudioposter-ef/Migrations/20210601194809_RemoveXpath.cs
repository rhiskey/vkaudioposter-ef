using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace vkaudioposter_ef.Migrations
{
    public partial class RemoveXpath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Playlists",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 1, 22, 48, 9, 218, DateTimeKind.Local).AddTicks(3817),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 1, 22, 9, 35, 193, DateTimeKind.Local).AddTicks(6625),
                oldComment: "Update Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "console_Photostocks",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 1, 22, 48, 9, 220, DateTimeKind.Local).AddTicks(954),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 1, 22, 9, 35, 195, DateTimeKind.Local).AddTicks(2003),
                oldComment: "Update Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Playlists",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 1, 22, 9, 35, 193, DateTimeKind.Local).AddTicks(6625),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 1, 22, 48, 9, 218, DateTimeKind.Local).AddTicks(3817),
                oldComment: "Update Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "console_Photostocks",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 1, 22, 9, 35, 195, DateTimeKind.Local).AddTicks(2003),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 1, 22, 48, 9, 220, DateTimeKind.Local).AddTicks(954),
                oldComment: "Update Date");
        }
    }
}
