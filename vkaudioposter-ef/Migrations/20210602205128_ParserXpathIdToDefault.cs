using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vkaudioposter_ef.Migrations
{
    public partial class ParserXpathIdToDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "ParserXpaths",
                newName: "Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Playlists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 2, 23, 51, 28, 98, DateTimeKind.Local).AddTicks(1479),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 2, 23, 46, 25, 918, DateTimeKind.Local).AddTicks(5363),
                oldComment: "Update Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "console_Photostocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 2, 23, 51, 28, 99, DateTimeKind.Local).AddTicks(6509),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 2, 23, 46, 25, 920, DateTimeKind.Local).AddTicks(1006),
                oldComment: "Update Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ParserXpaths",
                newName: "id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Playlists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 2, 23, 46, 25, 918, DateTimeKind.Local).AddTicks(5363),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 2, 23, 51, 28, 98, DateTimeKind.Local).AddTicks(1479),
                oldComment: "Update Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "console_Photostocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 2, 23, 46, 25, 920, DateTimeKind.Local).AddTicks(1006),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 2, 23, 51, 28, 99, DateTimeKind.Local).AddTicks(6509),
                oldComment: "Update Date");
        }
    }
}
