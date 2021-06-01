using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;
using System;

namespace vkaudioposter_ef.Migrations
{
    public partial class RemoveXpath2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_console_Photostocks_ParserXpaths_ParserXpathId",
                table: "console_Photostocks");

            migrationBuilder.DropTable(
                name: "ParserXpaths");

            migrationBuilder.DropIndex(
                name: "IX_console_Photostocks_ParserXpathId",
                table: "console_Photostocks");

            migrationBuilder.DropColumn(
                name: "ParserXpathId",
                table: "console_Photostocks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Playlists",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 1, 22, 48, 48, 778, DateTimeKind.Local).AddTicks(2612),
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
                defaultValue: new DateTime(2021, 6, 1, 22, 48, 48, 779, DateTimeKind.Local).AddTicks(7419),
                comment: "Update Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 1, 22, 48, 9, 220, DateTimeKind.Local).AddTicks(954),
                oldComment: "Update Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2021, 6, 1, 22, 48, 48, 778, DateTimeKind.Local).AddTicks(2612),
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
                oldDefaultValue: new DateTime(2021, 6, 1, 22, 48, 48, 779, DateTimeKind.Local).AddTicks(7419),
                oldComment: "Update Date");

            migrationBuilder.AddColumn<int>(
                name: "ParserXpathId",
                table: "console_Photostocks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ParserXpaths",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Xpath = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true, comment: "nodContainer for parsing (outer)"),
                    XpathInner = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true, comment: "nodContainer for parsing (inner if need to go inside)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParserXpaths", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_console_Photostocks_ParserXpathId",
                table: "console_Photostocks",
                column: "ParserXpathId");

            migrationBuilder.AddForeignKey(
                name: "FK_console_Photostocks_ParserXpaths_ParserXpathId",
                table: "console_Photostocks",
                column: "ParserXpathId",
                principalTable: "ParserXpaths",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
