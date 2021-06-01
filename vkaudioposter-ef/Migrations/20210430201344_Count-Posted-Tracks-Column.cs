using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace vkaudioposter_ef.Migrations
{
    public partial class CountPostedTracksColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Playlists",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 23, 13, 43, 864, DateTimeKind.Local).AddTicks(5519),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 4, 30, 19, 53, 6, 245, DateTimeKind.Local).AddTicks(4901),
                oldComment: "Update Date");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Playlists",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "console_Photostocks",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 23, 13, 43, 869, DateTimeKind.Local).AddTicks(1764),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 4, 30, 19, 53, 6, 249, DateTimeKind.Local).AddTicks(111),
                oldComment: "Update Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Playlists");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Playlists",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 19, 53, 6, 245, DateTimeKind.Local).AddTicks(4901),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 4, 30, 23, 13, 43, 864, DateTimeKind.Local).AddTicks(5519),
                oldComment: "Update Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "console_Photostocks",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 19, 53, 6, 249, DateTimeKind.Local).AddTicks(111),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 4, 30, 23, 13, 43, 869, DateTimeKind.Local).AddTicks(1764),
                oldComment: "Update Date");
        }
    }
}
