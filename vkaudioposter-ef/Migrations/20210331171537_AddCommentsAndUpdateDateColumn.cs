using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vkaudioposter_ef.Migrations
{
    public partial class AddCommentsAndUpdateDateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Playlists",
                type: "int",
                nullable: false,
                defaultValue: 1,
                comment: "Enabled status. If = 0 - not included, if = 1 - included in parsing",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Playlists",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 31, 20, 15, 37, 101, DateTimeKind.Local).AddTicks(7846),
                comment: "Update Date");

            migrationBuilder.AlterColumn<string>(
                name: "XpathInner",
                table: "ParserXpaths",
                type: "varchar(1024)",
                maxLength: 1024,
                nullable: true,
                comment: "nodContainer for parsing (inner if need to go inside)",
                oldClrType: typeof(string),
                oldType: "varchar(1024)",
                oldMaxLength: 1024,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Xpath",
                table: "ParserXpaths",
                type: "varchar(1024)",
                maxLength: 1024,
                nullable: true,
                comment: "nodContainer for parsing (outer)",
                oldClrType: typeof(string),
                oldType: "varchar(1024)",
                oldMaxLength: 1024,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "console_Photostocks",
                type: "int",
                nullable: false,
                defaultValue: 1,
                comment: "Enabled status. If = 0 - not included, if = 1 - included in parsing",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "console_Photostocks",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 31, 20, 15, 37, 103, DateTimeKind.Local).AddTicks(7299),
                comment: "Update Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "console_Photostocks");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Playlists",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1,
                oldComment: "Enabled status. If = 0 - not included, if = 1 - included in parsing");

            migrationBuilder.AlterColumn<string>(
                name: "XpathInner",
                table: "ParserXpaths",
                type: "varchar(1024)",
                maxLength: 1024,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1024)",
                oldMaxLength: 1024,
                oldNullable: true,
                oldComment: "nodContainer for parsing (inner if need to go inside)");

            migrationBuilder.AlterColumn<string>(
                name: "Xpath",
                table: "ParserXpaths",
                type: "varchar(1024)",
                maxLength: 1024,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1024)",
                oldMaxLength: 1024,
                oldNullable: true,
                oldComment: "nodContainer for parsing (outer)");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "console_Photostocks",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1,
                oldComment: "Enabled status. If = 0 - not included, if = 1 - included in parsing");
        }
    }
}
