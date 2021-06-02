using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vkaudioposter_ef.Migrations
{
    public partial class InitMsSQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Playlists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 2, 23, 46, 25, 918, DateTimeKind.Local).AddTicks(5363),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 2, 23, 40, 4, 88, DateTimeKind.Local).AddTicks(2897),
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
                oldDefaultValue: new DateTime(2021, 6, 2, 23, 40, 4, 89, DateTimeKind.Local).AddTicks(7594),
                oldComment: "Update Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Playlists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 2, 23, 40, 4, 88, DateTimeKind.Local).AddTicks(2897),
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
                defaultValue: new DateTime(2021, 6, 2, 23, 40, 4, 89, DateTimeKind.Local).AddTicks(7594),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 2, 23, 46, 25, 920, DateTimeKind.Local).AddTicks(1006),
                oldComment: "Update Date");
        }
    }
}
