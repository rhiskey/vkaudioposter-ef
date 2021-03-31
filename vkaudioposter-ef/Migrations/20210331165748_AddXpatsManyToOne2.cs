using Microsoft.EntityFrameworkCore.Migrations;

namespace vkaudioposter_ef.Migrations
{
    public partial class AddXpatsManyToOne2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_console_Photostocks_ParserXpath_ParserXpathId",
                table: "console_Photostocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParserXpath",
                table: "ParserXpath");

            migrationBuilder.RenameTable(
                name: "ParserXpath",
                newName: "ParserXpaths");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParserXpaths",
                table: "ParserXpaths",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_console_Photostocks_ParserXpaths_ParserXpathId",
                table: "console_Photostocks",
                column: "ParserXpathId",
                principalTable: "ParserXpaths",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_console_Photostocks_ParserXpaths_ParserXpathId",
                table: "console_Photostocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParserXpaths",
                table: "ParserXpaths");

            migrationBuilder.RenameTable(
                name: "ParserXpaths",
                newName: "ParserXpath");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParserXpath",
                table: "ParserXpath",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_console_Photostocks_ParserXpath_ParserXpathId",
                table: "console_Photostocks",
                column: "ParserXpathId",
                principalTable: "ParserXpath",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
