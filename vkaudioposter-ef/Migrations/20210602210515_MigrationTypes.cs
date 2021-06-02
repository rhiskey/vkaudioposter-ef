using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vkaudioposter_ef.Migrations
{
    public partial class MigrationTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "trackname",
                table: "UnfoundTracks",
                type: "nvarchar(150)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Posts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "PostedTracks",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Trackname",
                table: "PostedTracks",
                type: "nvarchar(1024)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "PreviewUrl",
                table: "PostedTracks",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Playlists",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 3, 0, 5, 15, 731, DateTimeKind.Local).AddTicks(8370),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 2, 23, 51, 28, 98, DateTimeKind.Local).AddTicks(1479),
                oldComment: "Update Date");

            migrationBuilder.AlterColumn<string>(
                name: "XpathInner",
                table: "ParserXpaths",
                type: "varchar(1024)",
                maxLength: 1024,
                nullable: true,
                comment: "nodContainer for parsing (inner if need to go inside)",
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024,
                oldNullable: true,
                oldComment: "nodContainer for parsing (inner if need to go inside)");

            migrationBuilder.AlterColumn<string>(
                name: "Xpath",
                table: "ParserXpaths",
                type: "varchar(1024)",
                maxLength: 1024,
                nullable: true,
                comment: "nodContainer for parsing (outer)",
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024,
                oldNullable: true,
                oldComment: "nodContainer for parsing (outer)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "console_Photostocks",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 3, 0, 5, 15, 733, DateTimeKind.Local).AddTicks(3607),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 2, 23, 51, 28, 99, DateTimeKind.Local).AddTicks(6509),
                oldComment: "Update Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "trackname",
                table: "UnfoundTracks",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "PostedTracks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Trackname",
                table: "PostedTracks",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "PreviewUrl",
                table: "PostedTracks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Playlists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 2, 23, 51, 28, 98, DateTimeKind.Local).AddTicks(1479),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 3, 0, 5, 15, 731, DateTimeKind.Local).AddTicks(8370),
                oldComment: "Update Date");

            migrationBuilder.AlterColumn<string>(
                name: "XpathInner",
                table: "ParserXpaths",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: true,
                comment: "nodContainer for parsing (inner if need to go inside)",
                oldClrType: typeof(string),
                oldType: "varchar(1024)",
                oldMaxLength: 1024,
                oldNullable: true,
                oldComment: "nodContainer for parsing (inner if need to go inside)");

            migrationBuilder.AlterColumn<string>(
                name: "Xpath",
                table: "ParserXpaths",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: true,
                comment: "nodContainer for parsing (outer)",
                oldClrType: typeof(string),
                oldType: "varchar(1024)",
                oldMaxLength: 1024,
                oldNullable: true,
                oldComment: "nodContainer for parsing (outer)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "console_Photostocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 2, 23, 51, 28, 99, DateTimeKind.Local).AddTicks(6509),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 3, 0, 5, 15, 733, DateTimeKind.Local).AddTicks(3607),
                oldComment: "Update Date");
        }
    }
}
